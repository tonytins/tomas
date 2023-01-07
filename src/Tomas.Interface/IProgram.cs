/*
In jurisdictions that recognize copyright waivers, I've waived all copyright
and related or neighboring rights for to this project. In areas where these
waivers are not recognized, BSD-3-Clause is enforced.
See the (UN)LICENSE file in the project root for more information.
*/
namespace Tomas.Interface;

public interface IProgram
{
 /// <summary>
 /// The program's main entry point. Boolean behaves as an exit point.
 /// True and False are the equivalent to C's 0 and 1, i.e. "Success" and "Failure," respectfully.
 /// </summary>
 /// <param name="shell">Allows the program to interact with the shell.</param>
 /// <returns>Exit back to shell.</returns>
 bool Run(IShell shell);
}