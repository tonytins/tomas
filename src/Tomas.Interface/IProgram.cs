// I license this project under the GPL 3.0 license.
// See the LICENSE file in the project root for more information.
namespace Tomas.Interface
{
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
}