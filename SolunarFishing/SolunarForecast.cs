using SolunarFishing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SolunarForecast
{
    public DateTime Date { get; set; }
    public string SunRise { get; set; }
    public string SunSet { get; set; }
    public string MoonRise { get; set; }
    public string MoonSet { get; set; }
    public string MoonPhase { get; set; }
    public string Minor1Start { get; set; }
    public string Minor1Stop { get; set; }
    public string Minor2Start { get; set; }
    public string Minor2Stop { get; set; }
    public string Major1Start { get; set; }
    public string Major1Stop { get; set; }
    public string Major2Start { get; set; }
    public string Major2Stop { get; set; }
    public int DayRating { get; set; }

    public HourlyRating hourlyRating { get; set; }

    public class HourlyRating
    {
        public int _0 { get; set; }
        public int _1 { get; set; }
        public int _2 { get; set; }
        public int _3 { get; set; }
        public int _4 { get; set; }
        public int _5 { get; set; }
        public int _6 { get; set; }
        public int _7 { get; set; }
        public int _8 { get; set; }
        public int _9 { get; set; }
        public int _10 { get; set; }
        public int _11 { get; set; }
        public int _12 { get; set; }
        public int _13 { get; set; }
        public int _14 { get; set; }
        public int _15 { get; set; }
        public int _16 { get; set; }
        public int _17 { get; set; }
        public int _18 { get; set; }
        public int _19 { get; set; }
        public int _20 { get; set; }
        public int _21 { get; set; }
        public int _22 { get; set; }
        public int _23 { get; set; }
    }

    private static async Task<SolunarForecast> LoadSolunarData(float longitude = 38.042253f, float latitude = -85.5406209f, string date = "20220620", int timeZone = -4)
    {

        string url = $"https://api.solunar.org/solunar/{longitude},{latitude},{date},{timeZone}";
        var solunar = await ApiDataProcessor<SolunarForecast>.LoadApiData(url);
        DateTime correctDate = Convert.ToDateTime("06/16/2022");
        solunar.Date = correctDate;
        //Console.WriteLine($"Sunrise is at: {solunar.SunRise} and sunset is at: {solunar.SunSet}. Date: {solunar.Date}");
        return solunar;
    }

    public static async Task<List<SolunarForecast>> Forecast(int numberOfDays)
    {
        List<SolunarForecast> forecast = new List<SolunarForecast>();
        DateTime startDate = DateTime.Parse("02/28/2022");
        DateTime endDate = DateTime.Parse("02/28/2022");
        for (int i = 0; i < numberOfDays; i++)
        {
            var line = await LoadSolunarData();
            //Console.WriteLine($"New Date is: {endDate.AddDays(i).Date.ToString("d")}");
            forecast.Add(new SolunarForecast() {    Date = endDate.AddDays(i).Date, 
                                                    SunRise = line.SunRise, 
                                                    SunSet = line.SunSet,
                                                    DayRating = line.DayRating});
        }

        foreach (var item in forecast)
        {
            Console.WriteLine($"Today's date is {item.Date.ToString("d")} and sunrise is at {item.SunRise}, sunset is at {item.SunSet}.");
            Console.WriteLine($"Today's fishing quality is {item.DayRating}.");
        }
        return forecast;
    }
}