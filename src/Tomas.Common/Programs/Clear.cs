// I license this project under the BSD 3-Clause license.
// See the LICENSE file in the project root for more information.
using System;
using Tomas.Interface;

namespace Tomas.Common.Programs
{
 public class Clear : IProgram
 {
  public bool Run(IShell shell)
  {
   Console.Clear();
   return true;
  }
 }
}