using Newtonsoft.Json;

namespace WeatherAppSample.Models
{
    public class Sys
    {
        [JsonProperty("country")]
        public string Country { get; set; }
    }

}
