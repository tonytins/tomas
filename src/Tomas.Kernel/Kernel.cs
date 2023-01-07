// I license this project under the BSD 3-Clause license.
// See the LICENSE file in the project root for more information.

namespace Tomas.Kernel;

public class Kernel : Os.Kernel
{
    // This method is called before the Run method
    protected override void BeforeRun()
    {
        // Initialize the file system
        SysFS.Initialize();

        // If the file system is not enabled, print an error message indicating that the system booted with errors
        if (!SysMeta.IsFSEnabled)
            Console.WriteLine($"{SysMeta.NAME} booted with errors.");
        // If the file system is enabled, print a message indicating that the system booted successfully
        else
            Console.WriteLine($"{SysMeta.NAME} booted successfully.");
    }

    // This method is the main loop of the kernel, which handles input and runs programs
    protected override void Run()
    {
        // Run the loop indefinitely
        while (true)
        {
            // Create a new instance of the Shell class
            var shell = new Shell();

            // Read a line of input from the user
            var command = shell.ReadLine;

            // Get the dictionary of programs from the shell
            var programs = shell.Programs;

            // If the command is not a key in the dictionary of programs, print an error message
            // and continue to the next iteration of the loop
            if (!programs.TryGetValue(command, out var program))
            {
                Console.WriteLine("Command Not Found.");
                continue;
            }

            // Try to run the program and handle any exceptions that may be thrown
            try
            {
                // Run the program and store the returned value in the 'start' variable
                var start = program.Run(shell);

                // Check the value of 'start' and take the appropriate action
                switch (start)
                {
                    case true:
                        // If 'start' is true, continue to the next iteration of the loop
                        continue;
                    case false:
                        // If 'start' is false, print an error message and continue to the next iteration of the loop
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
    }
}
