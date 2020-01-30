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
            Console.WriteLine($"{OSConsts.Name} booted successfully. Type a line of text to get it echoed back.");
        }

        protected override void Run()
        {
            var input = Terminal.ReadLine("1) Basic App");

            switch (input.ToLowerInvariant())
            {
                case "1":
                    var basic = new BasicApp(this);
                    basic.Start();
                    break;
                default:
                    break;
            }
        }

        protected override void AfterRun()
        {
            if (!InApp)
                Console.WriteLine($"{OSConsts.Name} is shutting down.");
        }
    }
}
