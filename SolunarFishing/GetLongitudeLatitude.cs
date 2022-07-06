using System;
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

        public static bool SetLongitudeLatitude(string zipCode)
        {
            List<ZipCodeToLongitudeLatitudeModel> zipsToLongLat = new List<ZipCodeToLongitudeLatitudeModel>();
            
            var jsonText = File.ReadAllText(@"..\..\..\Resource\US_Zips.json");
            zipsToLongLat = JsonSerializer.Deserialize<List<ZipCodeToLongitudeLatitudeModel>>(jsonText);

            var newResult = zipsToLongLat.Where(n => n.Zip == zipCode);

            if (newResult.Any())
            {
                Longitude = newResult.First().Longitude;
                Latitude = newResult.First().Latitude;
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
