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