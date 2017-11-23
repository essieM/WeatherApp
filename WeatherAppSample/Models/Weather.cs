using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherAppSample.Models
{
    public class Weather
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public string Main { get; set; }

        [JsonIgnore]
        public string Description { get; set; }

        [JsonIgnore]
        public string Icon { get; set; }
    }

    public class WeatherRoot
    {
        [JsonProperty("coord")]
        public Coord Coordinates { get; set; } = new Coord();

        [JsonProperty("sys")]
        public Sys System { get; set; } = new Sys();

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; } = new List<Weather>();

        [JsonProperty("main")]
        public Main MainWeather { get; set; } = new Main();

        [JsonProperty("wind")]
        public Wind Wind { get; set; } = new Wind();

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; } = new Clouds();

        [JsonIgnore]
        public int CityId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dt_txt")]
        public string Date { get; set; } = string.Empty;

        [JsonIgnore]
        public string DisplayDate { get; set; } = string.Empty;

        [JsonIgnore]
        public string DisplayTime { get; set; }

        [JsonIgnore]
        public string DisplayTemp { get; set; }

        [JsonIgnore]
        public string DisplayIcon { get; set; }
    }

}
