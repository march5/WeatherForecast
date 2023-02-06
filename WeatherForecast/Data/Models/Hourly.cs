using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Data.Models
{
    internal class Hourly
    {
        public List<DateTime> time { get; set; }
        public List<double> temperature_2m { get; set; }
    }
}
