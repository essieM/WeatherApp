using Newtonsoft.Json;

namespace WeatherAppSample.Models
{
    public class Coord
    {
        [JsonIgnore]
        public double Longitude { get; set; }

        [JsonIgnore]
        public double Latitude { get; set; }
    }
}
