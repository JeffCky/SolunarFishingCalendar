using System;

public class SolunarForecastModel
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

    
}