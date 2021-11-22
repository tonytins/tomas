// I license this project under the GPL 3.0 license.
// See the LICENSE file in the project root for more information.
using Tomas.Terminal;

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