// I license this project under the BSD 3-Clause license.
// See the LICENSE file in the project root for more information.
using Tomas.Common;

namespace Tomas.Terminal.Programs;

public class About : IProgram
{
public bool Run(IShell shell)
{
Console.WriteLine($"{SysMeta.NAME} Terminal Emulator v{SysMeta.BuildNumber}{Environment.NewLine}"
                 + "TOMAS (Tony's Managed Operating System) is a operating system written in C# using the COSMOS framework.");
return true;
}
}