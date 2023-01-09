/*
In jurisdictions that recognize copyright waivers, I've waived all copyright
and related or neighboring rights for to this project. In areas where these
waivers are not recognized, BSD-3-Clause is enforced.
See the (UN)LICENSE file in the project root for more information.
*/
using System.Text.RegularExpressions;

namespace Tomas.Kernel.Globalization;

public class CST
{
    const char CARET = '^';
    const string LF = "\u000A";
    const string CR = "\u000D";
    const string CRLF = "\u000D\u000A";
    const string LS = "\u2028";

    /// <summary>
    /// Gets the value from the digit-based key.
    /// </summary>
    /// <returns>Returns the entry</returns>
    public static string Parse(string content, int key) => Parse(content, key.ToString());

    /// <summary>
    /// Gets the value from the string-based key.
    /// </summary>
    /// <returns>Returns the entry</returns>
    public static string Parse(string content, string key)
    {
        var entries = NormalizeEntries(content);
        return GetEntry(entries, key);
    }

    /// <summary>
    /// Replaces the document's line endings with the native system line endings.
    /// </summary>
    /// <remarks>This stage ensures there are no crashes during parsing.</remarks>
    /// <param name="content">The content of the document.</param>
    /// <returns>The document's content with native system line endings.</returns>
    static IEnumerable<string> NormalizeEntries(string content)
    {
        // Check if the document already uses native system line endings.
        if (!content.Contains(Environment.NewLine))
        {
            // If not, check for and replace other line ending types.
            if (content.Contains(LF))
                content = content.Replace(LF, Environment.NewLine);

            if (content.Contains(CR))
                content = content.Replace(CR, Environment.NewLine);

            if (content.Contains(CRLF))
                content = content.Replace(CRLF, Environment.NewLine);

            if (content.Contains(LS))
                content = content.Replace(LS, Environment.NewLine);
        }

        // Split the content by the caret and newline characters.
        var lines = content.Split(new[] { $"{CARET}{Environment.NewLine}" },
            StringSplitOptions.RemoveEmptyEntries);

        // Filter out any lines that start with "//", "#", "/*", or end with "*/".
        return lines.Where(line =>
            !line.StartsWith("//") &&
            !line.StartsWith("#") &&
            !line.StartsWith("/*") &&
            !line.EndsWith("*/"))
            .AsEnumerable();
    }

    // Retrieves the value for the specified key from the given entries.
    // Replaces any occurrences of % followed by a number with the corresponding argument value extracted from the entry string.
    static string GetEntry(IEnumerable<string> entries, string key)
    {
        // Iterate through the entries.
        foreach (var entry in entries)
        {
            // If the line doesn't start with the key, keep searching.
            if (!entry.StartsWith(key))
                continue;

            // Locate the index of the caret character.
            var startIndex = entry.IndexOf(CARET);
            // Get the line from the caret character to the end of the string.
            var line = entry[startIndex..];

            // Extract the arguments from the entry string using a regular expression
            var arguments = Regex.Matches(line, @"%(\d+)").Cast<Match>().Select(m => m.Groups[1].Value).ToArray();

            // Replace any occurrences of % followed by a number with the corresponding argument value
            for (int i = 0; i < arguments.Length; i++)
            {
                line = line.Replace($"%{arguments[i]}", GetArgumentValue(arguments[i]));
            }

            // Return the line with the caret characters trimmed.
            return line.TrimStart(CARET).TrimEnd(CARET);
        }

        // If no entry is found, return a default string.
        return "***MISSING***";
    }

    // Retrieves the value for the specified argument.
    static string GetArgumentValue(string argument)
    {
        // TODO: Implement logic to get the value for the specified argument.
        return "***ARGUMENT VALUE***";
    }


}


