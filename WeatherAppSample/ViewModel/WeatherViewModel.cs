using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Plugin.Geolocator;
using WeatherAppSample.Exceptions;
using WeatherAppSample.Models;
using WeatherAppSample.Services;

namespace WeatherAppSample.ViewModel
{
    public class WeatherViewModel
    {
        WeatherService WeatherService;

        WeatherRoot weatherRoot;
        public WeatherRoot weather
        {
            get { return weatherRoot; }
            set { weatherRoot = value;}
        }

        //Country
        string country;
        public string countryName
        {
            get { return country; }
            set { country = value; }
        }

        //Name of the city
        string name;
        public string cityName
        {
            get { return name; }
            set { name = value; }
        }

        //Maximum temperature for the day
        string max_temp;
        public string maximumTemp
        {
            get { return max_temp; }
            set { max_temp = value; }
        }

        //Minimum temperature for the day
        string min_temp;
        public string minimumTemp
        {
            get { return min_temp; }
            set { min_temp = value; }
        }


        public WeatherViewModel()
        {
            WeatherService = new WeatherService();
        }

        public async Task GetWeatherForecast()
        {
            try
            {
                var gps = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromSeconds(5), null, true);
                weather = await WeatherService.GetForecast(gps.Latitude, gps.Longitude);

                if (weather != null)
                {
                    PopulateData();
                }
            }
            catch (Exception ex)
            {
                await HandleException(ex);
            }
        }

        public void PopulateData()
        {
            var todaysForecast = weather;

            cityName = todaysForecast.Name;

            max_temp = convertTempToCelsius(todaysForecast.MainWeather.MaxTemperature).ToString();

            min_temp = convertTempToCelsius(todaysForecast.MainWeather.MinTemperature).ToString();

            countryName = todaysForecast.System.Country;
        }

        public double convertTempToCelsius(double temp)
        {
            return Convert.ToInt32((temp - 273.15));
        }

        async Task HandleException(Exception ex)
        {
            if (ex.GetType() == typeof(NotConnectedException))
            {
                await UserDialogs.Instance.AlertAsync("Request Failed","We are having trouble reaching this service.Please try again","Ok");
            }
            else if (ex.GetType() == typeof(RequestException))
            {
                await UserDialogs.Instance.AlertAsync("Request Failed", ex.Message, "Ok");
            }
            else if (ex.InnerException?.GetType() == typeof(WebException))
            {
                await UserDialogs.Instance.AlertAsync("We have an unrecoverable Error.", "Please try again later", "Ok");
            }
            else
            {
                await UserDialogs.Instance.AlertAsync("We have an unrecoverable Error.", "Please try again later", "Ok");
            }        
        }
    }
}
