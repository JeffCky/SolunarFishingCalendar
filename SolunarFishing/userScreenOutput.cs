using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolunarFishing
{
    public class userScreenOutput
    {
        public static void WriteForeCastToScreen(List<SolunarForecastModel> forecast)
        {
            var userOutputTable = new Table();
            userOutputTable.AddColumn(new TableColumn("[bold]Best Daily Fishing Times Bar Chart[/]").Centered());
            userOutputTable.AddColumn(new TableColumn("[bold]Daily Fishing Events[/]").Centered());

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

                string dayRatingDescription = DayRatingDescription(item.DayRating);
                var insetTable = new Table();
                insetTable.AddColumn(new TableColumn("[bold]Daily Events[/]").Centered());
                insetTable.AddRow($"Date: {item.Date.ToString("d")}");
                insetTable.AddRow($"[bold]Rating out of 5: {item.DayRating}[/]");
                insetTable.AddRow(dayRatingDescription);
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


                userOutputTable.AddRow(hourlyBarChart, insetTable);
                userOutputTable.AddRow("");
                userOutputTable.AddRow("[yellow bold underline]--------------------------------------------------------------------------------[/]", "[yellow bold underline]---------------------------------[/]");
                userOutputTable.AddRow("");
            }


            AnsiConsole.Write(userOutputTable);
            
            Console.WriteLine("Would you like to write your forecast to a CSV file to your desktop?");
            Console.WriteLine("Enter 'y' to write a file to your desktop,");
            Console.WriteLine("'q' to quit,");
            Console.WriteLine("or press any other key to continue without writing a file.");
            
            string userInput = Console.ReadLine();
            if (userInput == "y" || userInput == "'y'")
            {
                Console.WriteLine(Utilities.WriteCsvFile(forecast));
            }
            else if (userInput == "q" || userInput == "'q'")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("No file was written.");
            }
        }
        private static string DayRatingDescription(int rating)
        {
            string description = "";
            switch (rating)
            {
                case 0:
                    description = "Bad";
                    break;
                case 1:
                    description = "Poor";
                    break;
                case 2:
                    description = "Fair";
                    break;
                case 3:
                    description = "Good";
                    break;
                case 4:
                    description = "Very good";
                    break;
                case 5:
                    description = "Excellent";
                    break;
            }
             return $"{description} day for fishing!";
                 
                    
        }
    }
}
