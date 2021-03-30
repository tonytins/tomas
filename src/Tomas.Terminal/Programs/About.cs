// I license this project under the GPL 3.0 license.
// See the LICENSE file in the project root for more information.
using System;
using Tomas.Common;
using Tomas.Interface.Shell;

namespace Tomas.Terminal.Programs
{
    public class About : IProgram
    {
        public bool Start()
        {
            Console.WriteLine($"{ComConsts.NAME} v{ComConsts.VersionGit}{Environment.NewLine}");

            Console.WriteLine("Commands:");
            var progs = TermConsts.Programs;
            foreach (var commands in  progs.Keys)
                Console.WriteLine(commands);

            return true;
        }
    }
}