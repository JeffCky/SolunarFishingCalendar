using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolunarFishing
{
    internal class SolunarForecast
    {
        public static async Task<SolunarForecastModel> LoadSolunarData(float latitude, float longitude, string date = "20220620", int timeZone = -4)
        {

            string url = $"https://api.solunar.org/solunar/{latitude},{longitude},{date},{timeZone}";
            var solunar = await ApiDataProcessor<SolunarForecastModel>.LoadApiData(url);
            DateTime correctDate = Convert.ToDateTime("06/16/2022");
            solunar.Date = correctDate;
            //Console.WriteLine($"Sunrise is at: {solunar.SunRise} and sunset is at: {solunar.SunSet}. Date: {solunar.Date}");
            return solunar;
        }

        public static async Task<List<SolunarForecastModel>> Forecast(int numberOfDays)
        {
            List<SolunarForecastModel> forecast = new List<SolunarForecastModel>();
            //DateTime startDate = DateTime.Parse("02/28/2022");
            DateTime endDate = DateTime.Parse(UserInterface.Date);
            GetLongitudeLatitude.ReturnLongitudeLatitude(UserInterface.ZipCode);
            for (int i = 0; i < numberOfDays; i++)
            {
                var line = await LoadSolunarData(GetLongitudeLatitude.Latitude, GetLongitudeLatitude.Longitude);
                //Console.WriteLine($"New Date is: {endDate.AddDays(i).Date.ToString("d")}");
                forecast.Add(new SolunarForecastModel()
                {
                    Date = endDate.AddDays(i).Date,
                    SunRise = line.SunRise,
                    SunSet = line.SunSet,
                    DayRating = line.DayRating
                });
            }

            foreach (var item in forecast)
            {
                Console.WriteLine($"Today's date is {item.Date.ToString("d")} and sunrise is at {item.SunRise}, sunset is at {item.SunSet}.");
                Console.WriteLine($"Today's fishing quality is {item.DayRating}.");
            }
            return forecast;
        }
    }
}
