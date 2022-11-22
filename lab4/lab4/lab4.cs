using System;
using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using lab4.ClassLibrary;

namespace lab4
{
    public class Program
    {
        [Argument(0)]
        public static string? FirstArgument { get; set; }
        [Argument(1)]
        public static string? SecondArgument { get; set; }
        
        [Option("-i|--input <INPUT>", "Input file path", CommandOptionType.SingleValue)]
        public static string? Input { get; set; }
        [Option("-o|--output <OUTPUT>", "Output file path", CommandOptionType.SingleValue)]
        public static string? Output { get; set; }
        [Option("-p|--path <PATH>", "Working directory path", CommandOptionType.SingleValue)]
        public static string? Path { get; set; }



        public void OnExecute()
        {
            var LAB_PATH = Environment.GetEnvironmentVariable("LAB_PATH", EnvironmentVariableTarget.User);
            if (FirstArgument == "version")
            {
                Console.WriteLine("Ropalo Mykyta \n1.0.0");
            }
            else if (FirstArgument == "run" && Input != null && Output != null)
            {
                if (SecondArgument == null)
                {
                    Console.WriteLine("Error: no input file");
                }
                else if (SecondArgument == "lab1")
                {
                    Console.WriteLine("Lab1 Result:");
                    Lab1.Run(Input, Output);
                }
                else if (SecondArgument == "lab2")
                {
                    Console.WriteLine("Lab2 Result:");
                    Lab2.Run(Input, Output);
                }
                else if (SecondArgument == "lab3")
                {
                    Console.WriteLine("Lab3 Result:");
                    Lab3.Run(Input, Output);
                }
            }
            else if (FirstArgument == "run" && (Input == null || Output == null) && LAB_PATH != null)
            {
                if (SecondArgument == "lab1")
                {
                    Console.WriteLine("Lab1 Result:");
                    Lab1.Run(LAB_PATH + "\\INPUT.txt", LAB_PATH + "\\OUTPUT.txt");
                }
                else if (SecondArgument == "lab2")
                {
                    Console.WriteLine("Lab2 Result:");
                    Lab2.Run(LAB_PATH + "\\INPUT.txt", LAB_PATH + "\\OUTPUT.txt");
                }
                else if (SecondArgument == "lab3")
                {
                    Console.WriteLine("Lab3 Result:");
                    Lab3.Run(LAB_PATH + "\\INPUT.txt", LAB_PATH + "\\OUTPUT.txt");
                }
            }
            else if (FirstArgument == "run" && (Input == null || Output == null) && LAB_PATH == null)
            {
                string home_path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                if (SecondArgument == "lab1")
                {
                    Console.WriteLine("Lab1 Result:");
                    Lab1.Run(home_path + @"\INPUT.txt", home_path + @"\OUTPUT.txt");
                }
                else if (SecondArgument == "lab2")
                {
                    Console.WriteLine("Lab2 Result:");
                    Lab2.Run(home_path + @"\INPUT.txt", home_path + @"\OUTPUT.txt");
                }
                else if (SecondArgument == "lab3")
                {
                    Console.WriteLine("Lab3 Result:");
                    Lab3.Run(home_path + @"\INPUT.txt", home_path + @"\OUTPUT.txt");
                }
            }
            else if (FirstArgument == "set-path")
            {
                if (Path == null)
                {
                    Console.WriteLine("Error: no path");
                }
                else
                {
                    Environment.SetEnvironmentVariable("LAB_PATH", Path, EnvironmentVariableTarget.User);
                }

            }
            else
            {
                CommandLineApplication.Execute<Program>("--help");
            }
        }

        static void Main(string[] args)
        {
            CommandLineApplication.Execute<Program>("run", "lab1");

        }
    }
}

