using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEssentials.Shared.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceInfoPage : ContentPage
    {
        public DeviceInfoPage()
        {
            InitializeComponent();

            // Device Model (SMG-950U, iPhone10,6)
            var device = DeviceInfo.Model;

            // Manufacturer (Samsung)
            var manufacturer = DeviceInfo.Manufacturer;

            // Device Name (Motz's iPhone)
            var deviceName = DeviceInfo.Name;

            // Operating System Version Number (7.0)
            var version = DeviceInfo.VersionString;

            // Platform (Android)
            var platform = DeviceInfo.Platform;

            if(platform == DevicePlatform.Android)
            {
                // for android here
            }

            // Idiom (Phone)
            var idiom = DeviceInfo.Idiom;

            if(idiom == DeviceIdiom.Tablet)
            {
                // if on tablet do something
            }

            // Device Type (Physical)
            var deviceType = DeviceInfo.DeviceType;


            LabelDeviceInfo.Text = $"{deviceName} {version} {platform}";

            LabelDeviceDisplay.Text = DeviceDisplay.MainDisplayInfo.ToString();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;
        }

        private void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            LabelDeviceDisplay.Text = e.DisplayInfo.ToString();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DeviceDisplay.MainDisplayInfoChanged -= DeviceDisplay_MainDisplayInfoChanged;

        }
    }
}