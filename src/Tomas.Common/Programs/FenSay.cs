// I license this project under the GPL 3.0 license.
// See the LICENSE file in the project root for more information.
using System;
using Tomas.Interface.Shell;

namespace Tomas.Kernel.Programs
{
    public class FenSay : IProgram
    {

        /// <summary>
        /// Fennec art by Todd Vargo
        /// </summary>
        const string FENNEC = @"                \/
   /\   /\
  //\\_//\\     ____
  \_     _/    /   /
   / * * \    /^^^]
   \_\O/_/    [   ]
    /   \_    [   /
    \     \_  /  /
     [ [ /  \/ _/
    _[ [ \  /_/";

         readonly string[] _fenPhrases =
         {
             "[Screams in Fennec]",
             "Some people call me a coffee fox.",
             "Drink Soda. It makes you see faster.",
             "10/10, Wouldn't Recommend."
         };

        public bool Start()
        {
            var rng = new Random();
            var phrases = _fenPhrases[rng.Next(_fenPhrases.Length)];
            Console.WriteLine($"{phrases}{Environment.NewLine}{FENNEC}");
            return true;
        }
    }
}