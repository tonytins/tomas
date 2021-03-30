// I license this project under the GPL 3.0 license.
// See the LICENSE file in the project root for more information.
using System;
using Tomas.Common;
using Tomas.Interface.Shell;
using Tomas.Kernel;

namespace Tomas.Terminal.Programs
{
    public class About : IProgram
    {
        public bool Start()
        {
            Console.WriteLine($"{ComConsts.NAME} v{ComConsts.VersionGit}");

            var progs = OSConsts.Programs;
            foreach (var commands in  progs.Keys)
                Console.WriteLine(commands);

            return true;
        }
    }
}