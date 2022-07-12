using System;
using System.Threading.Tasks;
using static SolunarFishing.ApiConnector;
using static SolunarFishing.UserInterface;
using static SolunarFishing.SolunarForecast;

namespace SolunarFishing
{
    internal class Program
    {
        public static bool quit = false;
        static async Task Main(string[] args)
        {
            ProgramStart(); 
            while (!quit)
            {

                int errorFlag = 0; 
                try
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
                Utilities.DoItAgainLoop();

                
            }


        }

       

                
            

            
            
        

            
    }



}

    


