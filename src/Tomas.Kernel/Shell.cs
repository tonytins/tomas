/*
In jurisdictions that recognize copyright waivers, I've waived all copyright
and related or neighboring rights for to this project. In areas where these
waivers are not recognized, BSD-3-Clause is enforced.
See the (UN)LICENSE file in the project root for more information.
*/
namespace Tomas.Kernel;

public class Shell : IShell
{
 // The symbol to display before the cursor when the shell is waiting for user input
 const char SYMBOL = '$';

 // A dictionary containing the programs available to the shell, with the keys being the program names
 // and the values being the program objects
 public Dictionary<string, IProgram> Programs => new()
    {
        {"about", new About() },
        {"fensay", new FenSay() },
        {"clear", new Clear() },
        {"commands", new Commands() }
    };

 // A property that allows the shell to read a line of input from the user
 public string ReadLine
 {
  get
  {
   // Write the SYMBOL character to the console
   Console.Write(SYMBOL);

   // Read a line of input from the user
   var readl = Console.ReadLine();

   // Return the line of input
   return readl;
  }
 }
}

