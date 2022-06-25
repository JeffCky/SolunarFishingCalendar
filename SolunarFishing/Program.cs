




using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace SolunarFishing
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ApiConnector.InitializeClient();
            UserInterface.AskAndRetrieveUserInput();

            //await LoadLongLat();


            //await LoadSolunarData();

            //Environment.Exit(0);
            await SolunarForecast.Forecast(int.Parse(UserInterface.ForecastType));

            
            
            


            
        }

        private static void LoadLongLat(string zipCode = "40047")
        {
        }

                
            

            
            
        

            
    }



}

    


