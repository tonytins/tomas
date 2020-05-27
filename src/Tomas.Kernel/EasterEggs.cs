// TOMAS is licensed under the MPL 2.0 license.
// See the LICENSE file in the project root for more information.
using System;

namespace Tomas.Kernel
{
    internal class EasterEggs
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

        static readonly string[] _fenPhrases = { "Screams in fennec!", "Some people call me a coffee fox." };

        public static string FenSay
        {
            get
            {
                var rng = new Random();
                var phrases = _fenPhrases[rng.Next(0, _fenPhrases.Length)];
                return $"{phrases}{Environment.NewLine}{FENNEC}";
            }
        }
    }
}
