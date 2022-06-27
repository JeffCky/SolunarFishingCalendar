




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

            
            await SolunarForecast.Forecast(int.Parse(UserInterface.ForecastType));

        }

       

                
            

            
            
        

            
    }



}

    


