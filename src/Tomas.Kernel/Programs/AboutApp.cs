// TOMAS is licensed under the MPL 2.0 license.
// See the LICENSE file in the project root for more information.
using System;

namespace Tomas.Kernel.Programs
{
    class AboutApp : App
    {
        public AboutApp(Kernel system) : base(system)
        {
        }

        public override void Start()
        {
            Console.WriteLine($"{OSConsts.NAME} v{OSConsts.VersionGit}");
            Console.WriteLine("TOMAS, an abbreviation of Tony's Managed Operating System, is a operating system written in C# using the COSMOS framework.");

            base.Start();
        }
    }
}
