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
                    MoonPhase = data.MoonPhase,
                    MoonRise = data.MoonRise,
                    MoonSet = data.MoonSet,
                    DayRating = data.DayRating,
                    HourlyRating = data.HourlyRating,
                 
                }); 
                apiDate = endDate.AddDays(i).Date.ToString("yyyyMMdd");

            }

            var table = new Table();
            table.AddColumn("Fishing Date");
            table.AddColumn("Hourly Rating Chart");
            table.AddColumn(new TableColumn("Fishing Quality").Centered());
            table.AddColumn(new TableColumn("Sunrise").Centered());
            table.AddColumn(new TableColumn("Sunset").Centered());
            table.AddColumn(new TableColumn("Moon Phase").Centered());
            table.AddColumn(new TableColumn("Moonrise").Centered());
            table.AddColumn(new TableColumn("Moonset").Centered());

            foreach (var item in forecast)
            {
                // Add some rows
                //table.AddRow(item.Date.ToString("d"), $"[white]{item.DayRating}[/]", $"[white]{item.SunRise}[/]", $"[white]{item.SunSet}[/]", $"[white]{item.MoonPhase}[/]", $"[white]{item.MoonRise}[/]", $"[white]{item.MoonSet}[/]");
                table.AddRow(
                    new Markup(item.Date.ToString("d")), 
                    new BarChart()
                       .Width(60)
                       .Label($"[yellow bold underline]{item.Date.ToString("d")}[/]")
                       .CenterLabel()
                       .AddItem("1:00 AM", item.HourlyRating.Zero, Color.Yellow)
                       .AddItem("2:00 AM", item.HourlyRating.One, Color.Green)
                       .AddItem("3:00 AM", item.HourlyRating.Two, Color.Red)
                       .AddItem("4:00 AM", item.HourlyRating.Three, Color.Blue)
                       .AddItem("5:00 AM", item.HourlyRating.Four, Color.Pink1)
                       .AddItem("6:00 AM", item.HourlyRating.Five, Color.Orange1)
                       .AddItem("7:00 AM", item.HourlyRating.Six, Color.Yellow)
                       .AddItem("8:00 AM", item.HourlyRating.Seven, Color.Green)
                       .AddItem("9:00 AM", item.HourlyRating.Eight, Color.Red)
                       .AddItem("10:00 AM", item.HourlyRating.Nine, Color.Blue)
                       .AddItem("11:00 AM", item.HourlyRating.Ten, Color.Pink1)
                       .AddItem("12:00 AM", item.HourlyRating.Eleven, Color.Orange1),
                    new Markup($"[white]{item.DayRating}[/]"), 
                    new Markup($"[white]{item.SunRise}[/]"),
                    new Markup($"[white]{item.SunSet}[/]"),
                    new Markup($"[white]{item.MoonPhase}[/]"),
                    new Markup($"[white]{item.MoonRise}[/]"),
                    new Markup($"[white]{item.MoonSet}[/]"));
                

            }
            Console.SetWindowSize(200, 40);
            AnsiConsole.Write(table);
            
 
        

            return forecast;
        }
    }
}
