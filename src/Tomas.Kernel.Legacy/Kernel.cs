// I license this project under the GPL 3.0 license.
// See the LICENSE file in the project root for more information.
using System;
using System.Collections.Generic;
using Tomas.Common;
using Sys = Cosmos.System;

namespace Tomas.Kernel
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            try
            {
                Sys.PCSpeaker.Beep();
                TomFS.Initialize();
            }
            catch
            {
                Sys.PCSpeaker.Beep();
                Console.WriteLine("File system failed to load! Not all functions will work.");
            }


            Console.WriteLine($"{ComConsts.NAME} v{ComConsts.VersionGit} Booted successfully.");
        }

        protected override void Run()
        {
            while (true)
            {
                var shell = new Shell();
                var command = shell.ReadLine;

                if (!OSConsts.Programs.TryGetValue(command, out var program))
                {
                    Console.WriteLine("Command Unknown.");
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

        protected override void AfterRun()
        {
            Console.WriteLine($"{ComConsts.NAME} is shutting down.");
        }
    }
}
