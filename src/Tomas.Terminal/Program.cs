/*
In jurisdictions that recognize copyright waivers, I've waived all copyright
and related or neighboring rights for to this project. In areas where these
waivers are not recognized, BSD-3-Clause is enforced.
See the (UN)LICENSE file in the project root for more information.
*/
namespace Tomas.Terminal;

class Program
{
 static void Main()
 {
  while (true)
  {
   var shell = new Shell();
   var command = shell.ReadLine;
   var programs = shell.Programs;

   if (!programs.TryGetValue(command, out var program))
   {
    Console.WriteLine("Command Not Found.");
    continue;
   }

   try
   {
    var start = program.Run(shell);
    switch (start)
    {
     case true:
      continue;
     case false:
      Console.WriteLine("Program closed unexpectedly.");
      continue;
    }
   }
   catch (Exception err)
   {
    Console.WriteLine(err.Message);
   }
  }
 }
}