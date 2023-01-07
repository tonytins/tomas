// I license this project under the BSD 3-Clause license.
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