using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HatTrick.CommonModel
{
    public class Weather
    {
        private static readonly string[] WEATHERS = { "Cloudy", "Rainy", "Stormy", "Bright", "Very Hot", "Hot", "Semi-Cloudy", "Dry", "Dusty", "Windy", "Pretty", "Nice" };

        public static string GetRandomWeather()
        {
            return WEATHERS[Consts.GameRandom.Next(0, WEATHERS.Length - 1)];
        }
    }
}
