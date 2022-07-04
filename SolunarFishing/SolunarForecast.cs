using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Threading.Tasks;

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
                    Minor1Start = data.Minor1Start,
                    Minor1Stop = data.Minor1Stop,
                    Minor2Start = data.Minor2Start,
                    Minor2Stop = data.Minor2Stop,
                    Major1Start = data.Major1Start,
                    Major1Stop = data.Major1Stop,
                    Major2Start = data.Major2Start,
                    Major2Stop = data.Minor2Stop,



                }); 
                apiDate = endDate.AddDays(i).Date.ToString("yyyyMMdd");

            }

            var table = new Table();
            table.AddColumn(new TableColumn("[bold]Best Daily Fishing Times Bar Chart[/]").Centered());
            table.AddColumn(new TableColumn("[bold]Daily Fishing Events[/]").Centered());
            
            foreach (var item in forecast)
            {
                // Add some rows
                Color barColor1 = Color.Yellow;
                Color barColor2 = Color.SkyBlue1;
                var hourlyBarChart = new BarChart()
                    .Width(60)
                    .Label($"[bold underline]{item.Date.ToString("d")}[/]")
                    .CenterLabel()
                    .AddItem(" ", 100, Console.BackgroundColor)
                    .AddItem($"[{barColor1} bold underline]12:00 AM[/]", item.HourlyRating.Zero == 0 ? 10 : item.HourlyRating.Zero, barColor1)
                    .AddItem($"[{barColor2} bold underline]1:00 AM[/]", item.HourlyRating.One == 0 ? 10 : item.HourlyRating.One, barColor2)
                    .AddItem($"[{barColor1} bold underline]2:00 AM[/]", item.HourlyRating.Two == 0 ? 10 : item.HourlyRating.Two, barColor1)
                    .AddItem($"[{barColor2} bold underline]3:00 AM[/]", item.HourlyRating.Three == 0 ? 10 : item.HourlyRating.Three, barColor2)
                    .AddItem($"[{barColor1} bold underline]4:00 AM[/]", item.HourlyRating.Four == 0 ? 10 : item.HourlyRating.Four, barColor1)
                    .AddItem($"[{barColor2} bold underline]5:00 AM[/]", item.HourlyRating.Five == 0 ? 10 : item.HourlyRating.Five, barColor2)
                    .AddItem($"[{barColor1} bold underline]6:00 AM[/]", item.HourlyRating.Six == 0 ? 10 : item.HourlyRating.Six, barColor1)
                    .AddItem($"[{barColor2} bold underline]7:00 AM[/]", item.HourlyRating.Seven == 0 ? 10 : item.HourlyRating.Seven, barColor2)
                    .AddItem($"[{barColor1} bold underline]8:00 AM[/]", item.HourlyRating.Eight == 0 ? 10 : item.HourlyRating.Eight, barColor1)
                    .AddItem($"[{barColor2} bold underline]9:00 AM[/]", item.HourlyRating.Nine == 0 ? 10 : item.HourlyRating.Nine, barColor2)
                    .AddItem($"[{barColor1} bold underline]10:00 AM[/]", item.HourlyRating.Ten == 0 ? 10 : item.HourlyRating.Ten, barColor1)
                    .AddItem($"[{barColor2} bold underline]11:00 AM[/]", item.HourlyRating.Eleven == 0 ? 10 : item.HourlyRating.Eleven, barColor2)
                    .AddItem($"[{barColor1} bold underline]Noon[/]", item.HourlyRating.Twelve == 0 ? 10 : item.HourlyRating.Twelve, barColor1)
                    .AddItem($"[{barColor2} bold underline]1:00 PM[/]", item.HourlyRating.Thirteen == 0 ? 10 : item.HourlyRating.Thirteen, barColor2)
                    .AddItem($"[{barColor1} bold underline]2:00 PM[/]", item.HourlyRating.Fourteen == 0 ? 10 : item.HourlyRating.Fourteen, barColor1)
                    .AddItem($"[{barColor2} bold underline]3:00 PM[/]", item.HourlyRating.Fifteen == 0 ? 10 : item.HourlyRating.Fifteen, barColor2)
                    .AddItem($"[{barColor1} bold underline]4:00 PM[/]", item.HourlyRating.Sixteen == 0 ? 10 : item.HourlyRating.Sixteen, barColor1)
                    .AddItem($"[{barColor2} bold underline]5:00 PM[/]", item.HourlyRating.Seventeen == 0 ? 10 : item.HourlyRating.Seventeen, barColor2)
                    .AddItem($"[{barColor1} bold underline]6:00 PM[/]", item.HourlyRating.Eighteen == 0 ? 10 : item.HourlyRating.Eighteen, barColor1)
                    .AddItem($"[{barColor2} bold underline]7:00 PM[/]", item.HourlyRating.Nineteen == 0 ? 10 : item.HourlyRating.Nineteen, barColor2)
                    .AddItem($"[{barColor1} bold underline]8:00 PM[/]", item.HourlyRating.Twenty == 0 ? 10 : item.HourlyRating.Twenty, barColor1)
                    .AddItem($"[{barColor2} bold underline]9:00 PM[/]", item.HourlyRating.TwentyOne == 0 ? 10 : item.HourlyRating.TwentyOne, barColor2)
                    .AddItem($"[{barColor1} bold underline]10:00 PM[/]", item.HourlyRating.TwentyTwo == 0 ? 10 : item.HourlyRating.TwentyTwo, barColor1)
                    .AddItem($"[{barColor2} bold underline]11:00 PM[/]", item.HourlyRating.TwentyThree == 0 ? 10 : item.HourlyRating.TwentyThree, barColor2);
                    

                var insetTable = new Table();
                insetTable.AddColumn(new TableColumn("[bold]Daily Events[/]").Centered());
                insetTable.AddRow($"Date: {item.Date.ToString("d")}");
                insetTable.AddRow($"[bold]Rating out of 5: {item.DayRating}[/]");
                insetTable.AddRow("");
                insetTable.AddRow($"[bold]Sunrise: {item.SunRise}[/]");
                insetTable.AddRow($"[bold]Sunset: {item.SunSet}[/]");
                insetTable.AddRow("");
                insetTable.AddRow($"[bold]Moon Phase: {item.MoonPhase}[/]");
                insetTable.AddRow($"[bold]Moon Rise: {item.MoonRise}[/]");
                insetTable.AddRow($"[bold]Moon Set: {item.MoonSet}[/]");
                insetTable.AddRow("");
                insetTable.AddRow($"[bold]First Major Start: {item.Major1Start}[/]");
                insetTable.AddRow($"[bold]First Major Stop: {item.Major1Stop}[/]");
                insetTable.AddRow($"[bold]Second Major Start: {item.Major2Start}[/]");
                insetTable.AddRow($"[bold]Second Major Stop: {item.Major2Stop}[/]");
                insetTable.AddRow("");
                insetTable.AddRow($"[bold]First Minor Start: {item.Minor1Start}[/]");
                insetTable.AddRow($"[bold]First Minor Stop: {item.Minor1Stop}[/]");
                insetTable.AddRow($"[bold]Second Minor Start: {item.Minor2Start}[/]");
                insetTable.AddRow($"[bold]Second Minor Stop: {item.Minor2Stop}[/]");


                table.AddRow(hourlyBarChart, insetTable);
                table.AddRow("");
                table.AddRow("[yellow bold underline]--------------------------------------------------------------------------------[/]", "[yellow bold underline]---------------------------------[/]");
                table.AddRow("");
            }
            
            
            AnsiConsole.Write(table);
            
 
        

            return forecast;
        }
    }
}
