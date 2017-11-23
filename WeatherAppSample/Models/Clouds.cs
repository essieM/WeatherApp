using Newtonsoft.Json;

namespace WeatherAppSample.Models
{
    public class Clouds
    {
        [JsonIgnore]
        public int CloudinessPercent { get; set; } = 0;
    }
}
