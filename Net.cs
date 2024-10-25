using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. View running processes");
            Console.WriteLine("2. Terminate specific process (permanently)");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();

            if (input == "1")
            {
                ShowRunningProcesses();
            }
            else if (input == "2")
            {
                Console.Write("Enter the name of the process to terminate (without extension): ");
                string processName = Console.ReadLine();
                KillProcessForever(processName);
            }
            else if (input == "3")
            {
                break; // Exit the program
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }

    static void ShowRunningProcesses()
    {
        Console.WriteLine("Currently running processes:");
        Process[] processes = Process.GetProcesses();
        foreach (var process in processes)
        {
            Console.WriteLine($"{process.Id}: {process.ProcessName}");
        }
    }

    static void KillProcessForever(string processName)
    {
        Console.WriteLine($"Permanently terminating the {processName} process. Press Ctrl+C to stop.");

        while (true)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            if (processes.Length > 0)
            {
                foreach (var process in processes)
                {
                    try
                    {
                        process.Kill();
                        process.WaitForExit();
                        Console.WriteLine($"{processName} process has been terminated.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error occurred while terminating the process: {ex.Message}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"{processName} process is not running.");
            }

            // Wait for 1 second before repeating
            Thread.Sleep(100);
        }
    }
}
