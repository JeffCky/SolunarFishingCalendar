using System;
using System.Threading.Tasks;
using static SolunarFishing.ApiConnector;
using static SolunarFishing.UserInterface;
using static SolunarFishing.SolunarForecast;

namespace SolunarFishing
{
    internal class Program
    {
        private static bool quit = false;
        static async Task Main(string[] args)
        {
            //Console.WriteLine(ConvertTime.TwentyFourToTwelveHour("12:04"));

            while (!quit)
            {

                int errorFlag = 0; try
                {
                    
                    InitializeClient();
                    errorFlag = 1;
                    AskAndRetrieveUserInput();
                    errorFlag = 2;
                    await Forecast(int.Parse(UserInterface.ForecastType));

                }
                catch (Exception)
                {
                    if (errorFlag == 0)
                    {
                        Console.WriteLine("Sorry there was an error initializing.");
                    }
                    else if(errorFlag == 1)
                    {
                        Console.WriteLine("Sorry there was an error collecting input.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry there was an error with data from the api.");
                    }
                   
                }
               

                Console.WriteLine("Do you want to try another date and/or zip code? Type 'y' to continue or 'q' to quit...");
                string userInput = Console.ReadLine();
                if (userInput == "q" || userInput == "'q'") 
                {
                    quit = true;
                }
                else
                {
                    quit = false;
                }

            }


        }

       

                
            

            
            
        

            
    }



}

    


