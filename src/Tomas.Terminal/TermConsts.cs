using System.Collections.Generic;
using Tomas.Interface.Shell;
using Tomas.Kernel.Programs;
using Tomas.Terminal.Programs;

namespace Tomas.Terminal
{
    public struct TermConsts
    {
        public static Dictionary<string, IProgram> Programs => new Dictionary<string, IProgram>()
        {
            {"about", new About()},
            {"fensay", new FenSay()},
            {"clear", new Clear()}
        };
    }
}