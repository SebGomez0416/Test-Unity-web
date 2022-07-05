using UnityEngine;
using System.Collections.Generic;


public class Weather 
{
    public string temperature;
    public string wind;
    public string description;
    public IList<Forecast> forecast;
}

public class Forecast
{
    public string day;
    public string temperature;
    public string wind;
}
