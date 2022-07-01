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
            while (!quit)
            {
                InitializeClient();
                AskAndRetrieveUserInput();

                await Forecast(int.Parse(UserInterface.ForecastType));

                Console.WriteLine("Do you want to try another date and/or zip code? Type y to continue or q to quit");
                if(Console.ReadLine().Equals("q"))
                {
                    quit = true;
                }else
                {
                    quit = false;
                }

            }
            

        }

       

                
            

            
            
        

            
    }



}

    


