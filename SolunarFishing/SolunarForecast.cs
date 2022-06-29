using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using static SolunarForecastModel;
using Newtonsoft.Json;

namespace SolunarFishing
{
    internal class SolunarForecast
    {
        public static async Task<string> LoadSolunarData(float latitude, float longitude, string date, int timeZone = -4)
        {

            string url = $"https://api.solunar.org/solunar/{latitude},{longitude},{date},{timeZone}";
            var solunar = await ApiDataProcessor.LoadApiData(url);
            //DateTime correctDate = Convert.ToDateTime("06/16/2022");
            //solunar.Date = correctDate;
            return solunar;
        }

        public static async Task<List<SolunarForecastModel>> Forecast(int numberOfDays)
        {
            List<SolunarForecastModel> forecast = new List<SolunarForecastModel>();

            
            DateTime endDate = DateTime.Parse(UserInterface.Date);
            string apiDate = endDate.ToString("yyyyMMdd");
           
            for (int i = 0; i < numberOfDays; i++)
            {
                var line = await LoadSolunarData(GetLongitudeLatitude.Latitude, GetLongitudeLatitude.Longitude, apiDate);
                var options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                SolunarForecastModel data = System.Text.Json.JsonSerializer.Deserialize<SolunarForecastModel>(line, options);
               

                forecast.Add(new SolunarForecastModel()
                {
                    Date = endDate.AddDays(i).Date,
                    SunRise = data.SunRise,
                    SunSet = data.SunSet,
                    DayRating = data.DayRating,
                    HourlyRating = data.HourlyRating,
                 
                }); 
                apiDate = endDate.AddDays(i).Date.ToString("yyyyMMdd");

            }

            var table = new Table();
            table.AddColumn("Today's Date");
            table.AddColumn(new TableColumn("Sunrise").Centered());
            table.AddColumn(new TableColumn("Sunset").Centered());
            table.AddColumn(new TableColumn("Fishing Quality").Centered());
            
            foreach (var item in forecast)
            {
                // Add some rows
                table.AddRow(item.Date.ToString("d"), $"[green]{item.SunRise}[/]", $"[#ff00ff]{item.SunSet}[/]", $"[yellow]{item.DayRating}[/]");
                //table.AddRow($"[green]{item.hourlyRating._0}[/]", $"[green]{item.hourlyRating._1}[/]", $"[green]{item.hourlyRating._2}[/]", $"[green]{item.hourlyRating._3}[/]");
                 

                table.AddRow(new BarChart()
                   .Width(60)
                   .Label("[green bold underline]Hourly Rating[/]")
                   .CenterLabel()
                   .AddItem("1:00 AM", item.HourlyRating._0, Color.Yellow)
                   .AddItem("2:00 AM", item.HourlyRating._1, Color.Green)
                   .AddItem("3:00 AM", item.HourlyRating._2, Color.Red));

            }
            
            AnsiConsole.Write(table);
            

            return forecast;
        }
    }
}
