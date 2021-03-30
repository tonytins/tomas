// TOMAS is licensed under the MPL 2.0 license.
// See the LICENSE file in the project root for more information.
using System;
using System.Collections.Generic;
using Tomas.Common;
using Tomas.Interface.Shell;
using Tomas.Kernel.Programs;
using Tomas.Terminal.Programs;
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


            Console.WriteLine("Booted successfully. Type a line of text to get it echoed back.");
        }

        protected override void Run()
        {
            while (true)
            {
                var shell = new Shell();
                var command = shell.ReadLine;
                OSConsts.Programs.TryGetValue(command, out var program);
                var isRun = program.Start();

                if (isRun) continue;
                break;
            }
        }

        protected override void AfterRun()
        {
            Console.WriteLine($"{ComConsts.NAME} is shutting down.");
        }
    }
}
