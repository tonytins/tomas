// I license this project under the BSD 3-Clause license.
// See the LICENSE file in the project root for more information.
using Tomas.Common;

namespace Tomas.Terminal.Programs;

public class About : IProgram
{
    public bool Run(IShell shell)
    {
        Console.WriteLine($"{TermMeta.NAME} Terminal Emulator v{TermMeta.VERSION}");
        return true;
    }
}