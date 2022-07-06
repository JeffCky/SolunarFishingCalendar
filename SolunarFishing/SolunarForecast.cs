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
            var solunar = await ApiDataProcessor.LoadApiData(url);
            //DateTime correctDate = Convert.ToDateTime("06/16/2022");
            //solunar.Date = correctDate;
            return solunar;
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
                    .AddItem($"[{barColor1} bold underline]12:00 AM[/]", item.HourlyRating.MidNightHour == 0 ? 10 : item.HourlyRating.MidNightHour, barColor1)
                    .AddItem($"[{barColor2} bold underline]1:00 AM[/]", item.HourlyRating.OneAMHour == 0 ? 10 : item.HourlyRating.OneAMHour, barColor2)
                    .AddItem($"[{barColor1} bold underline]2:00 AM[/]", item.HourlyRating.TwoAMHour == 0 ? 10 : item.HourlyRating.TwoAMHour, barColor1)
                    .AddItem($"[{barColor2} bold underline]3:00 AM[/]", item.HourlyRating.ThreeAMHour == 0 ? 10 : item.HourlyRating.ThreeAMHour, barColor2)
                    .AddItem($"[{barColor1} bold underline]4:00 AM[/]", item.HourlyRating.FourAMHour == 0 ? 10 : item.HourlyRating.FourAMHour, barColor1)
                    .AddItem($"[{barColor2} bold underline]5:00 AM[/]", item.HourlyRating.FiveAMHour == 0 ? 10 : item.HourlyRating.FiveAMHour, barColor2)
                    .AddItem($"[{barColor1} bold underline]6:00 AM[/]", item.HourlyRating.SixAMHour == 0 ? 10 : item.HourlyRating.SixAMHour, barColor1)
                    .AddItem($"[{barColor2} bold underline]7:00 AM[/]", item.HourlyRating.SevenAMHour == 0 ? 10 : item.HourlyRating.SevenAMHour, barColor2)
                    .AddItem($"[{barColor1} bold underline]8:00 AM[/]", item.HourlyRating.EightAMHour == 0 ? 10 : item.HourlyRating.EightAMHour, barColor1)
                    .AddItem($"[{barColor2} bold underline]9:00 AM[/]", item.HourlyRating.NineAMHour == 0 ? 10 : item.HourlyRating.NineAMHour, barColor2)
                    .AddItem($"[{barColor1} bold underline]10:00 AM[/]", item.HourlyRating.TenAMHour == 0 ? 10 : item.HourlyRating.TenAMHour, barColor1)
                    .AddItem($"[{barColor2} bold underline]11:00 AM[/]", item.HourlyRating.ElevenAMHour == 0 ? 10 : item.HourlyRating.ElevenAMHour, barColor2)
                    .AddItem($"[{barColor1} bold underline]Noon[/]", item.HourlyRating.NoonHour == 0 ? 10 : item.HourlyRating.NoonHour, barColor1)
                    .AddItem($"[{barColor2} bold underline]1:00 PM[/]", item.HourlyRating.OnePMHour == 0 ? 10 : item.HourlyRating.OnePMHour, barColor2)
                    .AddItem($"[{barColor1} bold underline]2:00 PM[/]", item.HourlyRating.TwoPMHour == 0 ? 10 : item.HourlyRating.TwoPMHour, barColor1)
                    .AddItem($"[{barColor2} bold underline]3:00 PM[/]", item.HourlyRating.ThreePMHour == 0 ? 10 : item.HourlyRating.ThreePMHour, barColor2)
                    .AddItem($"[{barColor1} bold underline]4:00 PM[/]", item.HourlyRating.FourPMHour == 0 ? 10 : item.HourlyRating.FourPMHour, barColor1)
                    .AddItem($"[{barColor2} bold underline]5:00 PM[/]", item.HourlyRating.FivePMHour == 0 ? 10 : item.HourlyRating.FivePMHour, barColor2)
                    .AddItem($"[{barColor1} bold underline]6:00 PM[/]", item.HourlyRating.SixPMHour == 0 ? 10 : item.HourlyRating.SixPMHour, barColor1)
                    .AddItem($"[{barColor2} bold underline]7:00 PM[/]", item.HourlyRating.SevenPMHour == 0 ? 10 : item.HourlyRating.SevenPMHour, barColor2)
                    .AddItem($"[{barColor1} bold underline]8:00 PM[/]", item.HourlyRating.EightPMHour == 0 ? 10 : item.HourlyRating.EightPMHour, barColor1)
                    .AddItem($"[{barColor2} bold underline]9:00 PM[/]", item.HourlyRating.NinePMHour == 0 ? 10 : item.HourlyRating.NinePMHour, barColor2)
                    .AddItem($"[{barColor1} bold underline]10:00 PM[/]", item.HourlyRating.TenPMHour == 0 ? 10 : item.HourlyRating.TenPMHour, barColor1)
                    .AddItem($"[{barColor2} bold underline]11:00 PM[/]", item.HourlyRating.ElevenPMHour == 0 ? 10 : item.HourlyRating.ElevenPMHour, barColor2);
                    

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

            Console.WriteLine("Would you like to write your forecast to a CSV file to your desktop?");
            Console.WriteLine("Enter 'y' to write a file to your desktop,");
            Console.WriteLine("press the enter key to continue without writing a file, ");
            Console.WriteLine("or 'q' to quit");
            string userInput = Console.ReadLine();
            if(userInput == "y" || userInput == "'y'")
            {
                Console.WriteLine(Utilities.WriteCsvFile(forecast)); 
            } 
            else if(userInput == "q" || userInput == "'q'")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("No file was written.");
            }

            return forecast;
        }
    }
}
