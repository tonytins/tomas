/*
In jurisdictions that recognize copyright waivers, I've waived all copyright
and related or neighboring rights for to this project. In areas where these
waivers are not recognized, BSD-3-Clause is enforced.
See the (UN)LICENSE file in the project root for more information.
*/

// Run the loop indefinitely
using Tomas.Terminal;

while (true)
{
    // Create a new instance of the Shell class
    var shell = new Shell();

    // Read a line of input from the user
    var command = shell.ReadLine;

    // Split the command into words
    var words = command.Split(' ');

    // If there are no words, skip this iteration
    if (words.Length == 0)
        continue;

    // Get the program name
    var programName = words[0];

    // Get the dictionary of programs from the shell
    var programs = shell.Programs;

    // If the program doesn't exist, display an error message
    if (!programs.TryGetValue(programName, out var program))
    {
        Console.WriteLine($"{programName}: command not found");
        continue;
    }

    // Get the arguments
    var arguments = words.Skip(1).ToArray();

    // Parse and validate the arguments
    var parsedArguments = shell.ParseArguments(program, arguments);
    if (parsedArguments == null)
    {
        // If the arguments are invalid, display an error message
        Console.WriteLine($"{programName}: invalid arguments");
        continue;
    }

    // Try to run the program and handle any exceptions that may be thrown
    try
    {
        // Run the program and store the returned value in the 'result' variable
        var result = program.Entry(shell, parsedArguments);

        switch (result)
        {
            case true:
                continue;
            case false:
                Console.WriteLine("Program closed unexpectedly.");
                continue;
        }

    }
    catch (Exception err)
    {
        // If an exception is caught, print the error message and continue to the next iteration of the loop
        Console.WriteLine(err.Message);
    }
}
