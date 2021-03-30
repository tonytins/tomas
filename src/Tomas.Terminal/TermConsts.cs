// I license this project under the GPL 3.0 license.
// See the LICENSE file in the project root for more information.
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