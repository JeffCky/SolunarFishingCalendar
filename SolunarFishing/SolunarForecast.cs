using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace SolunarFishing
{
    internal class SolunarForecast
    {
        public static async Task<string> LoadSolunarData(float latitude, float longitude, string date, int timeZone = -4)
        {

            string url = $"https://api.solunar.org/solunar/{latitude},{longitude},{date},{timeZone}";
            try
            {
                var solunar = await ApiDataProcessor.LoadApiData(url);

                return solunar;
            }
            catch (Exception)
            {
                Console.Write("Error occurred.No data retrieved from the api website.");
                return "00";
                
            }
            
        }

        public static async Task<List<SolunarForecastModel>> Forecast(int numberOfDays)
        {
            List<SolunarForecastModel> forecast = new List<SolunarForecastModel>();

            
            DateTime userDateInput = DateTime.Parse(UserInterface.Date);
            string dateForAPI = userDateInput.ToString("yyyyMMdd");
           
            for (int i = 0; i < numberOfDays; i++)
            {
                var line = await LoadSolunarData(GetLongitudeLatitude.Latitude, GetLongitudeLatitude.Longitude, dateForAPI);
                var options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                SolunarForecastModel data = System.Text.Json.JsonSerializer.Deserialize<SolunarForecastModel>(line, options);
               

                forecast.Add(new SolunarForecastModel()
                {
                    Date = userDateInput.AddDays(i).Date,
                    SunRise = Utilities.TwentyFourToTwelveHour(data.SunRise),
                    SunSet = Utilities.TwentyFourToTwelveHour(data.SunSet),
                    MoonPhase = data.MoonPhase,
                    MoonRise = Utilities.TwentyFourToTwelveHour(data.MoonRise),
                    MoonSet = Utilities.TwentyFourToTwelveHour(data.MoonSet),
                    DayRating = data.DayRating,
                    HourlyRating = data.HourlyRating,
                    Minor1Start = Utilities.TwentyFourToTwelveHour(data.Minor1Start),
                    Minor1Stop = Utilities.TwentyFourToTwelveHour(data.Minor1Stop),
                    Minor2Start = Utilities.TwentyFourToTwelveHour(data.Minor2Start),
                    Minor2Stop = Utilities.TwentyFourToTwelveHour(data.Minor2Stop),
                    Major1Start = Utilities.TwentyFourToTwelveHour(data.Major1Start),
                    Major1Stop = Utilities.TwentyFourToTwelveHour(data.Major1Stop),
                    Major2Start = Utilities.TwentyFourToTwelveHour(data.Major2Start),
                    Major2Stop = Utilities.TwentyFourToTwelveHour(data.Minor2Stop),



                }); 
                dateForAPI = userDateInput.AddDays(i).Date.ToString("yyyyMMdd");

            }

            userScreenOutput.WriteForeCastToScreen(forecast);

            return forecast;
        }
    }
}
