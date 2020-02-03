// TOMAS is licensed under the MPL 2.0 license.
// See the LICENSE file in the project root for more information.
using System;
using Tomas.Kernel.Programs;
using Sys = Cosmos.System;

namespace Tomas.Kernel
{
    public class Kernel : Sys.Kernel
    {
        public bool InApp { get; set; }

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
            var input = Terminal.ReadLine("1) About");

            switch (input.ToLowerInvariant())
            {
                case "1":
                    var basic = new AboutApp(this);
                    basic.Start();
                    break;
                default:
                    break;
            }
        }

        protected override void AfterRun()
        {
            if (!InApp)
                Console.WriteLine($"{OSConsts.NAME} is shutting down.");
        }
    }
}
