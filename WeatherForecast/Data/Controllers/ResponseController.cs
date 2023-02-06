using WeatherForecast.Data.Exceptions;
using WeatherForecast.Data.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherForecast.Data.Controllers
{
    static class ResponseController
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<Stream> GetResponse(Coordinates coordinates)
        {
            try
            {
                string url = "https://api.open-meteo.com/v1/forecast?latitude="
                            + coordinates.Latitude.Replace(",",".")
                            + "&longitude="
                            + coordinates.Longitude.Replace(",",".")
                            + "&hourly=temperature_2m";

                Console.WriteLine(url);

                HttpResponseMessage response = await client.GetAsync(url);
                
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStreamAsync();

                return responseBody;
            }
            catch (ResponseControllerExcpetion e)
            {
                Console.WriteLine(e.Message);
                throw new ResponseControllerExcpetion($"Error occured during getting response! Exception message: {e.Message}");
            }
        }

        public static ForecastResponse DeserializeResponse(Stream responseBody)
        {
            try
            {
                ForecastResponse forecastResponse = JsonSerializer.Deserialize<ForecastResponse>(responseBody);

                return forecastResponse;
            }
            catch(ResponseControllerExcpetion e)
            {
                Console.WriteLine(e.Message);
                throw new ResponseControllerExcpetion($"Error occured during deserializing response body! Exception message: {e.Message}");
            }
        }
    }
}
