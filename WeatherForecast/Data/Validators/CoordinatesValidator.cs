using WeatherForecast.Data.Models;

namespace WeatherForecast.Data.Validators
{
    public static class CoordinatesValidator
    {
        public static bool ValidateCoordinates(string latitude, string longitude)
        {
            if (!Double.TryParse(longitude.Replace(".", ","), out double lon) || !Double.TryParse(latitude.Replace(".",","), out double lat))
                return false;
           
            if (lon < -180 || lon > 180 || lat < -90 || lat > 90)
                return false;

            return true;
        }
    }
}
