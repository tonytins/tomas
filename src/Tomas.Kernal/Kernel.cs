// I license this project under the BSD 3-Clause license.
// See the LICENSE file in the project root for more information.
using System;

namespace Tomas.Kernal
{
    public class Kernel : Os.Kernel
    {

        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully. Type a line of text to get it echoed back.");
        }

        protected override void Run()
        {
            Console.Write("$");
            var input = Console.ReadLine();
            Console.Write("Text typed: ");
            Console.WriteLine(input);
        }
    }
}
