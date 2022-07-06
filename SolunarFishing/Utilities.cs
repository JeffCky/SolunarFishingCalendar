using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace SolunarFishing
{
    internal class Utilities
    {
        public static string TwentyFourToTwelveHour(string time)
        {
            if (time == null)
            {
                return "No Time";
            }
            else
            {
                string[] timeParts;
                string hours;
                timeParts = time.Split(":");
                hours = timeParts[0];
                int hoursInteger = int.Parse(hours);
                if (hoursInteger < 12 || hoursInteger == 24)
                    return time + " AM";
                else
                {
                    hours = (hoursInteger - 12).ToString();
                    return hours + ":" + timeParts[1] + " PM";
                }
            }
            

        }

        public static string WriteCsvFile(List<SolunarForecastModel> forecast)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            try
            {
                using var writer = new StreamWriter($"{desktop}/forecast{timeStamp}.csv");
                using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csv.WriteRecords(forecast);
                return "File written successfully.";
            }
            catch (Exception)
            {
                return "Sorry, there was a problem writing the file.";
            }

            
        }
    }
}
