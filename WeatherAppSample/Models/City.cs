using System;
using Newtonsoft.Json;

namespace WeatherAppSample.Models
{
    public class City
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public string Name { get; set; }
        [JsonIgnore]
        public Coord Coord { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonIgnore]
        public int Population { get; set; }
        [JsonIgnore]
        public Sys Sys { get; set; }
    }
}
