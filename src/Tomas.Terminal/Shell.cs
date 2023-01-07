/*
In jurisdictions that recognize copyright waivers, I've waived all copyright
and related or neighboring rights for to this project. In areas where these
waivers are not recognized, BSD-3-Clause is enforced.
See the (UN)LICENSE file in the project root for more information.
*/
using Tomas.Terminal.Programs;

namespace Tomas.Terminal;

public class Shell : IShell
{
 const char SYMBOL = '$';

 public Dictionary<string, IProgram> Programs => new()
    {
        {"about", new About()},
        {"fensay", new FenSay()},
        {"clear", new Clear()},
        {"commands", new Commands()}
    };

 public string ReadLine
 {
  get
  {
   Console.Write(SYMBOL);
   var readl = Console.ReadLine();
   return readl;
  }
 }
}