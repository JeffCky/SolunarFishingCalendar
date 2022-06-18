



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
            
            await LoadSolunarData();

            Environment.Exit(0);


        }

        private static async Task LoadLongLat(string zipCode = "40047")
        {

            string url = $"https://www.zipcodeapi.com/rest/vA74qRCnakSGxJjOWfz8Rjarf9P429dXeWf0s137ye7dMdlvg7QOK7K62hSPLMVs/info.json/{zipCode}/degrees";
            var longlat = await ApiDataProcessor<ZipCodeToLongitudeLatitudeModel>.LoadApiData(url);
            Console.WriteLine(longlat.Lng + " " + longlat.Lat);
        }

        private static async Task LoadSolunarData(float longitude = 38.042253f, float latitude = -85.5406209f, string date = "20220616", int timeZone = -4)
        {

            string url = $"https://api.solunar.org/solunar/{longitude},{latitude},{date},{timeZone}";
            var solunar = await ApiDataProcessor<DailySolunarModel>.LoadApiData(url);
            Console.WriteLine($"Sunrise is at: {solunar.SunRise} and sunset is at: {solunar.SunSet}.");
        }
    }

    

}
