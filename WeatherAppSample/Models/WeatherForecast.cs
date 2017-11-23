using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAppSample.Models
{
    public class WeatherForecast
    {
        [JsonIgnore]
        public City City { get; set; }
        [JsonIgnore]
        public string Vod { get; set; }
        [JsonIgnore]
        public double Message { get; set; }
        [JsonIgnore]
        public int Cnt { get; set; }
        [JsonProperty("list")]
        public List<WeatherRoot> Items { get; set; }
    }
}
