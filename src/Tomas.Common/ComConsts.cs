// I license this project under the BSD 3-Clause license.
// See the LICENSE file in the project root for more information.
namespace Tomas.Common
{
 public struct ComConsts
 {
  /// <summary>
  /// Name of the operating system
  /// </summary>
  public const string NAME = "TOMAS";

  public static string Version = $"{ThisAssembly.Git.SemVer.Major}.{ThisAssembly.Git.SemVer.Minor}.{ThisAssembly.Git.SemVer.Patch}";
  public static string VersionGit = $"{Version}-{ThisAssembly.Git.Commit}";
 }
}