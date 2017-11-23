using System;
using System.Threading.Tasks;
using UIKit;
using WeatherAppSample.iOS.CustomViews;
using WeatherAppSample.iOS.Utils;
using WeatherAppSample.ViewModel;

namespace WeatherAppSample.iOS
{
    public partial class ViewController : UIViewController
    {
        WeatherViewModel weatherViewModel;
        LoadingOverlay loadingOverlay;

        public ViewController(IntPtr handle) : base(handle)
        {
            weatherViewModel = new WeatherViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            labelDate.Font = UIFont.BoldSystemFontOfSize(17f);
            labelDate.TextColor = UIColor.Clear.FromHexString("#E5E4E2", 1);
            labelDate.Text = string.Format("TODAY, {0}", DateTime.Today.ToString("dd MMMMM yyyy"));
            labelDate.AdjustsFontSizeToFitWidth = true;

            labelMax.Font = UIFont.BoldSystemFontOfSize(35f);
            labelMax.Text = string.Format("max 0\u00B0C ");
            labelMax.AdjustsFontSizeToFitWidth = true;

            labelMin.Font = UIFont.SystemFontOfSize(21f);
            labelMin.Text = string.Format("min 0\u00B0C ");
            labelMin.AdjustsFontSizeToFitWidth = true;


            labelCityName.Font = UIFont.BoldSystemFontOfSize(17f);
            labelCityName.TextColor = UIColor.LightGray;
            labelCityName.Text = "";
            labelCityName.AdjustsFontSizeToFitWidth = true;
        }

        public override async void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            loadingOverlay = new LoadingOverlay(UIScreen.MainScreen.Bounds, "Loading data...");
            View.AddSubview(loadingOverlay);

            await weatherViewModel.GetWeatherForecast();

            loadingOverlay.Hide();

            UpdateFields();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

        void UpdateFields()
        {
            //Populate the fields with the data
            if (string.IsNullOrWhiteSpace(weatherViewModel.maximumTemp))
            {
                labelMax.Text = string.Format("max 0\u00B0C ");
            }else{
                labelMax.Text = string.Format("max {0}\u00B0C ", weatherViewModel.maximumTemp);
            }

            if (string.IsNullOrWhiteSpace(weatherViewModel.minimumTemp))
            {
                labelMin.Text = string.Format("min 0\u00B0C ");
            }else{
                labelMin.Text = string.Format("min {0}\u00B0C ", weatherViewModel.minimumTemp);
            }

            if (string.IsNullOrWhiteSpace(weatherViewModel.cityName))
            {
                labelCityName.Text = "";
            }else{
                labelCityName.Text = string.Format("{0}, {1}", weatherViewModel.cityName, weatherViewModel.countryName);
            }
        }
    }
}
