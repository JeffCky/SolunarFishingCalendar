using System;

namespace SolunarFishing
{
    internal static class UserInterface
    {
        public static string ZipCode { get; set; }
        public static string Date { get; set; }
        public static string ForecastType { get; set; }

        public static void AskAndRetrieveUserInput()
        {
            Console.WriteLine("Welcome to our Fishing Forecaster. We can show you a ");
            Console.WriteLine("1 day,");
            Console.WriteLine("7 day,");
            Console.WriteLine("0r 30 day");
            Console.WriteLine("fishing forecast. We will need a start");
            Console.WriteLine("date and a zipcode to get started.");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Please enter the starting date for your forecast in mm/dd/yyyy format.");
            Date = Console.ReadLine();
            int i = 3;
            while (!VerifyDate(Date)) 
            {
                Console.WriteLine($"Wrong input, ({i-1}) more chances to enter the starting date for your forecast in mm/dd/yyyy format.");
                Date = Console.ReadLine();
                i--;
                if (i == 0) Environment.Exit(0);
                else continue;

            }
            
            
            Console.WriteLine("Thank you.");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Now please enter the 5 digit zip code of your fishing destination. This");
            Console.WriteLine("zip code just needs to be near the water where you will be fishing.");
            ZipCode = Console.ReadLine();
            Console.WriteLine("Thank you.");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Finaly, we need to know which forecast you would like.");
            Console.WriteLine("Type 1 for a 1 day report.");
            Console.WriteLine("Type 2 for a 7 day report.");
            Console.WriteLine("Type 3 for a 30 day report.");
            ForecastType = Console.ReadLine();
            Console.WriteLine("Thank you. Please wait while we create your fishing forecast for xx day(s).");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("-------------------------------------------------------------------------\n\n");
         }
        private static bool VerifyDate(string date)
        {
            return true;
        }

        private static bool VerifyZip(string zipcode)
        {
            return true;
        }

        private static bool VerifyForecastType(string forecastType)
        {
            return true;
        }

    }
}
