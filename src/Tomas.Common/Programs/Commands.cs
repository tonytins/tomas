using System;
using Tomas.Interface;

namespace Tomas.Common.Programs
{
    public class Commands : IProgram
    {
        public bool Run(IShell shell)
        {
            Console.WriteLine($"Commands:");
            var progs = shell.Programs;
            foreach (var commands in  progs.Keys)
                Console.WriteLine(commands);
            return true;
        }
    }
}