using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace SolunarFishing
{
    internal class GetLongitudeLatitude
    {
        public static float Longitude { get; set; }
        public static float Latitude { get; set; }

        public static void ReturnLongitudeLatitude(string zipCode)
        {
            List<ZipCodeToLongitudeLatitudeModel> zipsToLongLat = new List<ZipCodeToLongitudeLatitudeModel>();
            string path = Directory.GetCurrentDirectory();

            string fileName = Path.GetFullPath(Path.Combine(path, @"..\..\..\Resource\\US_Zips.json"));
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                zipsToLongLat = JsonSerializer.Deserialize<List<ZipCodeToLongitudeLatitudeModel>>(json);
            }
            var newResult = zipsToLongLat.Where(n => n.Zip == "37076");
            Longitude = newResult.First().Longitude;
            Latitude = newResult.First().Latitude;
            // Console.WriteLine(newResult.First().City);

            
        }
    }
}
