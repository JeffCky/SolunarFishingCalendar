



using System;
using System.Threading.Tasks;

namespace SolunarFishing
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ApiConnector.InitializeClient();
            await LoadLongLat();
            

        }

        private static async Task LoadLongLat(string zipCode = "40047")
        {
            var longlat = await LongitudeLatitudeProcessor.LoadLongitudeLatitude(zipCode);
            Console.WriteLine(longlat.Lng + " " + longlat.Lat);
        }
    }

    

}
