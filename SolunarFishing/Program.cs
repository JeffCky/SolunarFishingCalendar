



using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static SolunarFishing.UserInterface;

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
            await SolunarForecast.Forecast(7);
            




        }

        private static async Task LoadLongLat(string zipCode = "40047")
        {

            string url = $"https://www.zipcodeapi.com/rest/vA74qRCnakSGxJjOWfz8Rjarf9P429dXeWf0s137ye7dMdlvg7QOK7K62hSPLMVs/info.json/{zipCode}/degrees";
            var longlat = await ApiDataProcessor<ZipCodeToLongitudeLatitudeModel>.LoadApiData(url);
            Console.WriteLine(longlat.Lng + " " + longlat.Lat);
        }

        
    }

    

}
