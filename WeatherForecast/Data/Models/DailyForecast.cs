using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Data.Models
{
    internal class DailyForecast
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Unit { get; set; }
        public Dictionary<DateTime, double> DailyTempAvg { get; set; }
    }
}
