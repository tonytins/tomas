/*
In jurisdictions that recognize copyright waivers, I've waived all copyright
and related or neighboring rights for to this project. In areas where these
waivers are not recognized, BSD-3-Clause is enforced.
See the (UN)LICENSE file in the project root for more information.
*/
namespace Tomas.Interface.Globalization;

public interface IUIText
{
    /// <summary>
    /// The base directory for the language files.
    /// </summary>
    string[] BasePath { get; set; }

    /// <summary>
    /// Get the text for the given id and key.
    /// </summary>
    /// <param name="id">The id of the text.</param>
    /// <param name="key">The key of the text.</param>
    /// <returns>The text for the given id and key.</returns>
    string GetText(int id, int key);
}
