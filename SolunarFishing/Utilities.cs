using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using SolunarFishing;
using SolunarFishing.Enums;
using System.Text.RegularExpressions;


namespace SolunarFishing
{
    internal class Utilities
    {
        public static string TwentyFourToTwelveHour(string time)
        {
            if (time == null)
            {
                return "No Time";
            }
            else
            {
                string[] timeParts;
                string hours;
                timeParts = time.Split(":");
                hours = timeParts[0];
                int hoursInteger = int.Parse(hours);
                if (hoursInteger < 12 || hoursInteger == 24)
                    return time + " AM";
                else
                {
                    hours = (hoursInteger - 12).ToString();
                    return hours + ":" + timeParts[1] + " PM";
                }
            }
            

        }

        public static string WriteCsvFile(List<SolunarForecastModel> forecast)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            try
            {
                using var writer = new StreamWriter($"{desktop}/forecast{timeStamp}.csv");
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecords(forecast);
                return "File written successfully.";
            }
            catch (Exception)
            {
                return "Sorry, there was a problem writing the file.";
            }

            
        }

        public static void DoItAgainLoop()
        {
            bool goodUserInput = true;
            while (goodUserInput)
            {
                Console.WriteLine("Do you want to try another date and/or zip code? Type 'y' to continue or 'q' to quit...");
                string userInput = Console.ReadLine();
                if (userInput == "q" || userInput == "'q'")
                {
                    Program.quit = true;
                    goodUserInput = false;
                    
                }
                else if (userInput == "y" || userInput == "'y'")
                {
                    Program.quit = false;
                    goodUserInput = false;
                    
                }
                else
                {
                    Console.WriteLine("That was not a 'y' or 'q' as input. Try again");
                    

                }
                
            }
            
        }
        public static bool VerifyInput(InputType inputType, string input)
        {
            if (input == "q" || input == "'q'") Environment.Exit(0);

            switch ((int)inputType)
            {
                case 1:
                    if (validateDate(input))
                    {
                        UserInterface.inputValue = input;
                        return true;
                    }
                    else
                    {
                        UserInterface.output = "Wrong date input, Please enter the starting date for your forecast in mm/dd/yyyy format, or 'q' to quit.";
                        return false;
                    }
                case 2:
                    if (validateZip(input))
                    {
                        UserInterface.inputValue = input;
                        if (GetLongitudeLatitude.SetLongitudeLatitude(input))
                            return true;
                        else
                        {
                            UserInterface.output = "This zip code not found, enter another to retry or 'q' to quit.";
                            return false;
                        }


                    }
                    else
                    {
                        UserInterface.output = "Wrong zipcode input, Wrong Please enter the 5 digit zip code of your fishing destination, or 'q' to quit.";
                        return false;
                    }
                case 3:
                    if (input == "1" || input == "7" || input == "30")
                    {
                        UserInterface.inputValue = input;
                        return true;
                    }
                    else
                    {
                        UserInterface.output = "Wrong forecast type input, Please enter the number of days in your forecast(1, 7, or 30), or 'q' to quit.";
                        return false;
                    }
            };
            return true;
        }

        public static void GetCorrectDataInput(InputType value, string input)
        {

            while (!VerifyInput(value, input))
            {
                Console.WriteLine(UserInterface.output);
                input = Console.ReadLine();
            }
        }

        public static bool validateDate(string testdate)
        {
            Regex regex = new Regex(@"/ ^(0[1 - 9] | 1[012])[- /.](0[1 - 9] |[12][0 - 9] | 3[01])[- /.](19 | 20)\d\d +$/");

            //Verify whether date entered in mm/dd/yyyy format.
            bool isValid = regex.IsMatch(testdate);

            //Verify whether entered date is Valid date.
            DateTime dt;
            isValid = DateTime.TryParseExact(testdate, "MM/dd/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);

            return isValid;

        }

        public static bool validateZip(string testzip)

        {
            Regex validateZipRegex = new Regex(@"^[0-9]{5}$");
            return validateZipRegex.IsMatch(testzip);
        }

        public static void centerText(String text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }


    }
}

