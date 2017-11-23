using Newtonsoft.Json;

namespace WeatherAppSample.Models
{
    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; } = 0;

        [JsonIgnore]
        public double Pressure { get; set; }

        [JsonIgnore]
        public double Humidity { get; set; }

        [JsonProperty("temp_min")]
        public double MinTemperature { get; set; } = 0;

        [JsonProperty("temp_max")]
        public double MaxTemperature { get; set; } = 0;
    }
}
