// I license this project under the GPL 3.0 license.
// See the LICENSE file in the project root for more information.
using Tomas.Common.Programs;
using Tomas.Interface;
using Tomas.Terminal.Programs;

namespace Tomas.Terminal;

public class Shell : IShell
{
    const char SYMBOL = '$';

    public Dictionary<string, IProgram> Programs => new()
    {
        { "about", new About() },
        { "fensay", new FenSay() },
        { "clear", new Clear() },
        { "commands", new Commands() }
     };

    public string ReadLine
    {
        get
        {
            Console.Write(SYMBOL);
            var readl = Console.ReadLine();
            return readl!;
        }
    }
}
