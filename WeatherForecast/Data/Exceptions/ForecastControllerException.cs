using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Data.Exceptions
{
    internal class ForecastControllerException : Exception
    {
        public ForecastControllerException() { }
        public ForecastControllerException(string message) : base(message) { }
        public ForecastControllerException(string message, Exception inner) : base(message, inner) { }
    }
}
