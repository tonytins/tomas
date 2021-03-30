using System;
using Tomas.Interface.Shell;

namespace Tomas.Kernel.Programs
{
    public class Clear : IProgram
    {
        public bool Start()
        {
            Console.Clear();
            return true;
        }
    }
}