using SolunarFishing.Enums;
using Spectre.Console;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SolunarFishing
{
    internal static class UserInterface
    {
        public static string ZipCode { get; set; }
        public static string Date { get; set; }
        public static string ForecastType { get; set; }



        public static string inputValue;
        public static string output = " ";
        private static Rule rule = new Rule();

        public static void ProgramStart()
        {
            if (OperatingSystem.IsWindows())
            {
                Console.SetBufferSize(120, 1600); 
                Console.SetWindowSize(120, 40);
            }

            AnsiConsole.Write(
                new FigletText("Welcome to our Fishing Forecaster.")
                .Centered()
                .Color(Color.Yellow));
            rule.Style = Style.Parse("yellow");


            AnsiConsole.Write(rule);

            Console.WriteLine();
            Utilities.centerText("We can show you a 1 day, 7 day, or 30 day fishing forecast.");
            Console.WriteLine();
            Utilities.centerText("We will need a date and a zipcode to get started.");
            Console.WriteLine();
        }

        public static void AskAndRetrieveUserInput()
        {

            AnsiConsole.Write(rule);
            Console.WriteLine();
            Console.WriteLine("Please enter the starting date for your forecast in mm/dd/yyyy format, or 'q' to quit.");
            inputValue = Console.ReadLine();
            Utilities.GetCorrectDataInput(InputType.DateInput, inputValue);

            Date = inputValue;

            Console.WriteLine("Thank you.");
            Console.WriteLine();
            AnsiConsole.Write(rule);
            Console.WriteLine();
            Console.WriteLine("Now please enter the 5 digit zip code of your fishing destination. This");
            Console.WriteLine("zip code just needs to be near the water where you will be fishing, or 'q' to quit.");
            inputValue = Console.ReadLine();
            Utilities.GetCorrectDataInput(InputType.ZipcodeInput, inputValue);

            ZipCode = inputValue;
            Console.WriteLine("Thank you.");
            Console.WriteLine();
            AnsiConsole.Write(rule);
            Console.WriteLine();
            Console.WriteLine("Finally, we need to know which forecast you would like.");
            Console.WriteLine("Enter 1 for a 1 day report.");
            Console.WriteLine("Enter 7 for a 7 day report.");
            Console.WriteLine("Enter 30 for a 30 day report.");
            Console.WriteLine("or 'q' to quit.");
            inputValue = Console.ReadLine();
            Utilities.GetCorrectDataInput(InputType.ForecastTypeInput, inputValue);

            ForecastType = inputValue;
            Console.WriteLine("Thank you. Please wait while we create your fishing forecast for xx day(s).");
            Console.WriteLine();
            AnsiConsole.Write(rule);
            Utilities.centerText("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            AnsiConsole.Write(rule);
            Console.WriteLine("\n\n");
        }
    }   
        
}
