using WeatherForecast.Data.Exceptions;
using WeatherForecast.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherForecast.Data.Controllers
{
    static class ForecastController
    {
        public static DailyForecast GetDailyAvgTemperature(ForecastResponse forecastResponse)
        {
            try
            {
                DailyForecast dailyForecast = new DailyForecast
                {
                    Longitude = forecastResponse.longitude,
                    Latitude = forecastResponse.latitude,
                    Unit = forecastResponse.hourly_units.temperature_2m,
                    DailyTempAvg = new Dictionary<DateTime, double>()
                };

                var tempDict = new Dictionary<DateTime, double>();

                for(int i = 0; i < forecastResponse.hourly.temperature_2m.Count(); i++)
                {
                    var date = forecastResponse.hourly.time[i].Date;

                    if (!tempDict.ContainsKey(date))
                    {
                        tempDict.Add(date, forecastResponse.hourly.temperature_2m[i]);
                    }
                    else
                    {
                        double avgTemp = tempDict[date];
                        avgTemp = avgTemp + forecastResponse.hourly.temperature_2m[i];
                        tempDict[date] = avgTemp;
                    }
                }

                foreach(var x in tempDict)
                {
                    dailyForecast.DailyTempAvg.Add(x.Key, Math.Round(x.Value / 24, 2));
                }

                return dailyForecast;
            }
            catch(ForecastControllerException e)
            {
                throw new ForecastControllerException($"Could not calculate daily average temperatures for given forecast! Exception message: {e.Message}");
            }
        }

        public static byte[] GetDailyAvgTemperatureAsBytes(DailyForecast dailyForecast)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(dailyForecast);

                return Encoding.ASCII.GetBytes(jsonString);
            }
            catch(ForecastControllerException e)
            {
                throw new ForecastControllerException($"Could not parse daily forecast json string to byte array! Exception message: {e.Message}");
            }

        }
    }
}
