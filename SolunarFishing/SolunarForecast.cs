using SolunarFishing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SolunarForecast
{
    public DateTime Date { get; set; }
    public string SunRise { get; set; }
    public string SunTransit { get; set; }
    public string SunSet { get; set; }
    public string MoonRise { get; set; }
    public string MoonTransit { get; set; }
    public string MoonUnder { get; set; }
    public string MoonSet { get; set; }
    public string MoonPhase { get; set; }
    public float MoonIllumination { get; set; }
    public float SunRiseDec { get; set; }
    public float SunTransitDec { get; set; }
    public float SunSetDec { get; set; }
    public float MoonRiseDec { get; set; }
    public float MoonSetDec { get; set; }
    public float MoonTransitDec { get; set; }
    public float MoonUnderDec { get; set; }
    public float Minor1StartDec { get; set; }
    public string Minor1Start { get; set; }
    public float Minor1StopDec { get; set; }
    public string Minor1Stop { get; set; }
    public float Minor2StartDec { get; set; }
    public string Minor2Start { get; set; }
    public float Minor2StopDec { get; set; }
    public string Minor2Stop { get; set; }
    public float Major1StartDec { get; set; }
    public string Major1Start { get; set; }
    public float Major1StopDec { get; set; }
    public string Major1Stop { get; set; }
    public float Major2StartDec { get; set; }
    public string Major2Start { get; set; }
    public float Major2StopDec { get; set; }
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

    private static async Task<SolunarForecast> LoadSolunarData(float longitude = 38.042253f, float latitude = -85.5406209f, string date = "20220616", int timeZone = -4)
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
        DateTime startDate = DateTime.Now;
        DateTime endDate = DateTime.Now;
        for (int i = 0; i < 7; i++)
        {
            var line = await LoadSolunarData();
            //Console.WriteLine($"New Date is: {endDate.AddDays(i).Date.ToString("d")}");
            forecast.Add(new SolunarForecast() { Date = endDate.AddDays(i).Date, SunRise = line.SunRise, SunSet = line.SunSet });
        }

        foreach (var item in forecast)
        {
            Console.WriteLine(item.Date + " " + item.SunRise + " " + item.SunSet);
        }
        return forecast;
    }
}