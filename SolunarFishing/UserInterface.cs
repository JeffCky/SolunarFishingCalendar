﻿using SolunarFishing.Enums;
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

        public static void AskAndRetrieveUserInput()
        {
            if (OperatingSystem.IsWindows())
            {
                Console.SetWindowSize(120, 40);
            }

            AnsiConsole.Write(
                new FigletText("Welcome to our Fishing Forecaster.")
                .Centered()
                .Color(Color.Yellow));
            var rule = new Rule();
            rule.Style = Style.Parse("yellow");
            
            AnsiConsole.Write(rule);

            Console.WriteLine();
            centerText("We can show you a 1 day, 7 day, or 30 day fishing forecast.");
            Console.WriteLine();
            centerText("We will need a date and a zipcode to get started.");
            Console.WriteLine();
            AnsiConsole.Write(rule);
            Console.WriteLine();
            Console.WriteLine("Please enter the starting date for your forecast in mm/dd/yyyy format, or 'q' to quit.");
            inputValue = Console.ReadLine();
            GetCorrectDataInput(InputType.DateInput, inputValue); 
                
            Date = inputValue;
            
            Console.WriteLine("Thank you.");
            Console.WriteLine();
            AnsiConsole.Write(rule);
            Console.WriteLine();
            Console.WriteLine("Now please enter the 5 digit zip code of your fishing destination. This");
            Console.WriteLine("zip code just needs to be near the water where you will be fishing, or 'q' to quit.");
            inputValue = Console.ReadLine();
            GetCorrectDataInput(InputType.ZipcodeInput, inputValue);
            
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
            GetCorrectDataInput(InputType.ForecastTypeInput, inputValue);
            
            ForecastType = inputValue;
            Console.WriteLine("Thank you. Please wait while we create your fishing forecast for xx day(s).");
            Console.WriteLine();
            AnsiConsole.Write(rule);
            centerText("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            AnsiConsole.Write(rule);
            Console.WriteLine("\n\n");
        }
        public static string output = " ";
        private static bool VerifyInput(InputType inputType, string input)
        {
            if (input == "q" || input == "'q'") Environment.Exit(0);
            
            switch ((int)inputType) 
            {
                case 1:
                    if (validateDate(input)) 
                    {
                        inputValue = input;
                        return true;
                    }
                    else
                    {
                        output = "Wrong date input, Please enter the starting date for your forecast in mm/dd/yyyy format, or 'q' to quit.";
                        return false;
                    }
               case 2:
                    if (validateZip(input))
                    {
                        inputValue = input;
                        if (GetLongitudeLatitude.SetLongitudeLatitude(input))
                            return true;
                        else
                        {
                            output = "This zip code not found, enter another to retry or 'q' to quit.";
                            return false;
                        }

                        
                    }
                    else
                    {
                        output = "Wrong zipcode input, Wrong Please enter the 5 digit zip code of your fishing destination, or 'q' to quit.";
                        return false;
                    }
               case 3:
                    if (input == "1" || input == "7" || input == "30")
                    {
                        inputValue = input;
                        return true;
                    }
                    else
                    {
                        output = "Wrong forecast type input, Please enter the number of days in your forecast(1, 7, or 30), or 'q' to quit.";
                        return false;
                    }
            };
            return true;
        }

        private static void GetCorrectDataInput(InputType value, string input)
        {
            
            while (!VerifyInput(value, input))
            {
                Console.WriteLine(output);
                input = Console.ReadLine();
            }
        }

        private static bool validateDate(string testdate)
        {
            Regex regex = new Regex(@"/ ^(0[1 - 9] | 1[012])[- /.](0[1 - 9] |[12][0 - 9] | 3[01])[- /.](19 | 20)\d\d +$/");
            
            //Verify whether date entered in mm/dd/yyyy format.
            bool isValid = regex.IsMatch(testdate);

            //Verify whether entered date is Valid date.
            DateTime dt;
            isValid = DateTime.TryParseExact(testdate, "MM/dd/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);

            return isValid;

        }

        private static bool validateZip(string testzip)

        {
            Regex validateZipRegex = new Regex(@"^[0-9]{5}$");
            return validateZipRegex.IsMatch(testzip); 
        }

        private static void centerText(String text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }


    }
}
