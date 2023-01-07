/*
In jurisdictions that recognize copyright waivers, I've waived all copyright
and related or neighboring rights for to this project. In areas where these
waivers are not recognized, BSD-3-Clause is enforced.
See the (UN)LICENSE file in the project root for more information.
*/
namespace Tomas.Terminal.Programs;

public class About : IProgram
{
 public bool Run(IShell shell)
 {
  Console.WriteLine($"{TermMeta.NAME} Terminal Emulator v{TermMeta.VERSION}");
  return true;
 }
}