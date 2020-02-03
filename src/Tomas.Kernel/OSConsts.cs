// TOMAS is licensed under the MPL 2.0 license.
// See the LICENSE file in the project root for more information.
namespace Tomas.Kernel
{
 public struct OSConsts
 {
  /// <summary>
  /// Name of the operating system
  /// </summary>
  public const string NAME = "TOMAS";

  public static string Version = $"{ThisAssembly.Git.SemVer.Major}.{ThisAssembly.Git.SemVer.Minor}.{ThisAssembly.Git.SemVer.Patch}";
  public static string VersionGit = $"{Version}-{ThisAssembly.Git.Commit}";
 }
}
