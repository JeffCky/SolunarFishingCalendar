using SolunarFishing;
using System;
using System.Collections.Generic;


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

    public HourlyRating HourlyRating { get; set; }

    

    
}