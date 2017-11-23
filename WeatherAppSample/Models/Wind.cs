using Newtonsoft.Json;

namespace WeatherAppSample.Models
{
    public class Wind
    {
        [JsonIgnore]
        public double Speed { get; set; }

        [JsonIgnore]
        public double WindDirectionDegrees { get; set; }
    }
}
