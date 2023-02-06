using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Data.Exceptions
{
    internal class ResponseControllerExcpetion : Exception
    {
        public ResponseControllerExcpetion() { }
        public ResponseControllerExcpetion(string message) : base(message) { }
        public ResponseControllerExcpetion(string message, Exception inner) : base(message, inner) { }
    }
}
