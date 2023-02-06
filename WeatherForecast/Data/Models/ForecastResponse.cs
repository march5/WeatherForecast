using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Data.Models
{
    internal class ForecastResponse
    {
        public double latitude { get;set; }
        public double longitude { get;set; }
        public HourlyUnits hourly_units { get; set; }
        public Hourly hourly { get; set; }
    }
}
