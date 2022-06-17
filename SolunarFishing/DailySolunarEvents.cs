﻿using SolunarFishing;

public class DailySolunarEvents
{
    public string sunRise { get; set; }
    public string sunTransit { get; set; }
    public string sunSet { get; set; }
    public string moonRise { get; set; }
    public string moonTransit { get; set; }
    public string moonUnder { get; set; }
    public string moonSet { get; set; }
    public string moonPhase { get; set; }
    public float moonIllumination { get; set; }
    public float sunRiseDec { get; set; }
    public float sunTransitDec { get; set; }
    public float sunSetDec { get; set; }
    public float moonRiseDec { get; set; }
    public float moonSetDec { get; set; }
    public float moonTransitDec { get; set; }
    public float moonUnderDec { get; set; }
    public float minor1StartDec { get; set; }
    public string minor1Start { get; set; }
    public float minor1StopDec { get; set; }
    public string minor1Stop { get; set; }
    public float minor2StartDec { get; set; }
    public string minor2Start { get; set; }
    public float minor2StopDec { get; set; }
    public string minor2Stop { get; set; }
    public float major1StartDec { get; set; }
    public string major1Start { get; set; }
    public float major1StopDec { get; set; }
    public string major1Stop { get; set; }
    public float major2StartDec { get; set; }
    public string major2Start { get; set; }
    public float major2StopDec { get; set; }
    public string major2Stop { get; set; }
    public int dayRating { get; set; }

    public HourlyRating hourlyRating { get; set; }
}