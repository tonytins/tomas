/*
In jurisdictions that recognize copyright waivers, I've waived all copyright
and related or neighboring rights for to this project. In areas where these
waivers are not recognized, BSD-3-Clause is enforced.
See the (UN)LICENSE file in the project root for more information.
*/
namespace Tomas.Kernel;

public class Shell : IShell
{
    // The symbol to display before the cursor when the shell is waiting for user input
    const char SYMBOL = '$';

    // A dictionary containing the programs available to the shell, with the keys being the program names
    // and the values being the program objects
    public Dictionary<string, IProgram> Programs { get; }

    public Shell()
    {
        Programs = new Dictionary<string, IProgram>
        {
            {"about", new About() },
            {"fensay", new FenSay() },
            {"clear", new Clear() },
            {"commands", new Commands() }
        };
    }

    // A property that allows the shell to read a line of input from the user
    public string ReadLine
    {
        get
        {
            // Write the SYMBOL character to the console
            Console.Write(SYMBOL);

            // Read a line of input from the user
            var readl = Console.ReadLine();

            // Return the line of input
            return readl;
        }
    }

    public void Run()
    {
        while (true)
        {
            // Read a line of input from the user
            var input = ReadLine;

            // Split the input into words
            var words = input.Split(' ');

            // If there are no words, skip this iteration
            if (words.Length == 0)
                continue;

            // Get the program name
            var programName = words[0];

            // Get the arguments
            var arguments = words.Skip(1).ToArray();

            // Check if the program exists
            if (!Programs.TryGetValue(programName, out var program))
            {
                // If the program doesn't exist, display an error message
                Console.WriteLine($"{programName}: command not found");
                continue;
            }

            // Parse and validate the arguments
            var parsedArguments = ParseArguments(program, arguments);
            if (parsedArguments == null)
            {
                // If the arguments are invalid, display an error message
                Console.WriteLine($"{programName}: invalid arguments");
                continue;
            }

            // Run the program
            var result = program.Entry(this, parsedArguments);

            // Handle the result
            if (result)
            {
                // If the program was successful, display a success message
                Console.WriteLine($"{programName}: success");
            }
            else
            {
                // If the program failed, display a failure message
                Console.WriteLine($"{programName}: failure");
            }
        }
    }

    public IEnumerable<KeyValuePair<string, object>>? ParseArguments(IProgram program, string[] arguments)
    {
        // Create a dictionary to store the parsed arguments
        var parsedArguments = new Dictionary<string, object>();

        // Create a list of required arguments
        var requiredArguments = program.Arguments.Where(x => x.IsRequired).ToList();

        // Iterate over the arguments
        for (int i = 0; i < arguments.Length; i++)
        {
            // Get the current argument
            var argument = arguments[i];

            // Check if the argument is a flag or a value
            if (argument.StartsWith("-"))
            {
                // If it's a flag, get the flag name and value
                var flagName = argument.Substring(1);
                object flagValue = true;
                if (flagName.EndsWith("="))
                {
                    // If the flag has a value, extract it
                    var flagNameValue = flagName.Split('=');
                    flagName = flagNameValue[0];
                    flagValue = flagNameValue[1];
                }

                // Get the argument definition
                var argumentDefinition = program.Arguments.FirstOrDefault(x => x.Name == flagName);
                if (argumentDefinition == null)
                {
                    // If the argument is not defined, return null
                    return null;
                }

                // Add the argument to the dictionary
                parsedArguments[flagName] = flagValue;

                // Remove the argument from the required arguments list
                requiredArguments.Remove(argumentDefinition);
            }
            else
            {
                // If it's a value, check if there are any required arguments left
                if (requiredArguments.Count == 0)
                {
                    // If there are no required arguments left, return null
                    return null;
                }

                // Get the next required argument
                var requiredArgument = requiredArguments[0];

                // Convert the value to the correct type
                var value = Convert.ChangeType(argument, requiredArgument.Type);

                // Add the argument to the dictionary
                parsedArguments[requiredArgument.Name] = value;

                // Remove the argument from the required arguments list
                requiredArguments.RemoveAt(0);
            }
        }

        // If there are any required arguments left, return null
        if (requiredArguments.Count > 0)
            return null;

        // Return the parsed arguments
        return parsedArguments;
    }

}