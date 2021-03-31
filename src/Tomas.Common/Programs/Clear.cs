using System;
using Tomas.Interface;

namespace Tomas.Common.Programs
{
    public class Clear : IProgram
    {
        public bool Run(IShell shell)
        {
            Console.Clear();
            return true;
        }
    }
}