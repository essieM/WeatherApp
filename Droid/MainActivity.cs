using Android.App;
using Android.Widget;
using Android.OS;
using WeatherAppSample.ViewModel;
using System;
using System.Threading.Tasks;
using Acr.UserDialogs;

namespace WeatherAppSample.Droid
{
    [Activity(Label = "WeatherAppSample", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        WeatherViewModel weatherViewModel;
        TextView tvDate;
        TextView tvMaxTemp;
        TextView tvMinTemp;
        TextView tvCity;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Initialize the views
            tvDate = FindViewById<TextView>(Resource.Id.tv_date);
            tvDate.Text = string.Format("TODAY, {0}", DateTime.Today.ToString("dd MMMMM yyyy"));

            tvMaxTemp = FindViewById<TextView>(Resource.Id.tv_maxTemperature);
            tvMaxTemp.Text = string.Format("max 0\u00B0C ");

            tvMinTemp = FindViewById<TextView>(Resource.Id.tv_minTemperature);
            tvMinTemp.Text = string.Format("min 0\u00B0C ");

            tvCity = FindViewById<TextView>(Resource.Id.tv_city);

            weatherViewModel = new WeatherViewModel();

            UserDialogs.Init(this);

            UserDialogs.Instance.ShowLoading("Loading data...");

            var data = Task.Run(async () =>
            {
                //Fetch the weather forecast for the day from the weather service
                await weatherViewModel.GetWeatherForecast();
                UpdateFields();
            });

            UserDialogs.Instance.HideLoading();
        }

        void UpdateFields()
        {
            RunOnUiThread(() =>
            {
                ////Populate the fields with the data
                if (string.IsNullOrWhiteSpace(weatherViewModel.maximumTemp))
                {
                    tvMaxTemp.Text = string.Format("max 0\u00B0C ");
                }else{
                    tvMaxTemp.Text = string.Format("max {0}\u00B0C ", weatherViewModel.maximumTemp);
                }

                if (string.IsNullOrWhiteSpace(weatherViewModel.minimumTemp))
                {
                    tvMinTemp.Text = string.Format("min 0\u00B0C ");
                }else{
                    tvMinTemp.Text = string.Format("min {0}\u00B0C ", weatherViewModel.minimumTemp);
                }

                if (string.IsNullOrWhiteSpace(weatherViewModel.cityName))
                {
                    tvCity.Text = "";
                }else{
                    tvCity.Text = string.Format("{0}, {1}", weatherViewModel.cityName, weatherViewModel.countryName);
                }
            });
        }

    }
}

