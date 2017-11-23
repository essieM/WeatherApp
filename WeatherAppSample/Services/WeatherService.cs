using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Newtonsoft.Json;
using Plugin.Connectivity;
using WeatherAppSample.Models;

namespace WeatherAppSample.Services
{
    public class WeatherService
    {
        const string ForecastUri = "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid=6e53544a8469b0360969b7d96a531b1e";

        public async Task<WeatherRoot> GetForecast(double latitude, double longitude)
        {
            //Call this function to ensure that a cellular or wifi connection is available first.
            var isConnected = await CheckForNetworkConnection();

            if (isConnected)
            {
                var url = string.Format(ForecastUri, latitude, longitude);

                using (var client = new HttpClient())
                {
                    var result = await client.GetAsync(url);

                    var json = await result.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(json))
                    {
                        return null;
                    }
                    return JsonConvert.DeserializeObject<WeatherRoot>(json);
                }
            }
            return null;
        }


        async Task<bool> CheckForNetworkConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await UserDialogs.Instance.AlertAsync("This app requires Cellular or Wifi access. Kindly ensure one of these is enabled first.");
                return false;
            }
            return true;
        }
    }
}
