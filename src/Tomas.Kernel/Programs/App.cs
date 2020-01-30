// TOMAS is licensed under the MPL 2.0 license.
// See the LICENSE file in the project root for more information.

namespace Tomas.Kernel.Programs
{
    /// <summary>
    /// Basic framework for building terminal applications.
    /// </summary>
    public abstract class App
    {
        protected App(Kernel system)
        {
            System = system;
        }

        Kernel System { get; set; }

        /// <summary>
        /// Main entry point of the program
        /// </summary>
        public virtual void Start()
        {
            System.InApp = true;

        }

    }
}
