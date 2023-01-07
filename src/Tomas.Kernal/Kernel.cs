// I license this project under the BSD 3-Clause license.
// See the LICENSE file in the project root for more information.

namespace Tomas.Kernel;

public class Kernel : Os.Kernel
{

    protected override void BeforeRun()
    {
        SysFS.Initialize();

        if (!SysMeta.IsFSActive)
            Console.WriteLine($"{SysMeta.NAME} booted with errors.");
        else
            Console.WriteLine($"{SysMeta.NAME} booted successfully.");
    }

    protected override void Run()
    {
        while (true)
        {
            var shell = new Shell();
            var command = shell.ReadLine;
            var programs = shell.Programs;

            if (!programs.TryGetValue(command, out var program))
            {
                Console.WriteLine("Command Not Found.");
                continue;
            }

            try
            {
                var start = program.Run(shell);
                switch (start)
                {
                    case true:
                        continue;
                    case false:
                        Console.WriteLine("Program closed unexpectedly.");
                        continue;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
