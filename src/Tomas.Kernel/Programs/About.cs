// I license this project under the BSD 3-Clause license.
// See the LICENSE file in the project root for more information.

namespace Tomas.Kernel.Programs;

public class About : IProgram
{
    public bool Run(IShell shell)
    {
        Console.WriteLine($"TOMAS v{SysMeta.VERSION} ({SysMeta.BuildNumber}) is a hobby operating system written in C# using the COSMOS framework.{Environment.NewLine}Commands:");
        var progs = shell.Programs;
        foreach (var commands in progs.Keys)
            Console.WriteLine(commands);

        return true;
    }
}