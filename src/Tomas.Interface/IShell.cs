// I license this project under the GPL 3.0 license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace Tomas.Interface
{
    public interface IShell
    {
        string ReadLine { get; }

        Dictionary<string, IProgram> Programs { get; }
    }
}