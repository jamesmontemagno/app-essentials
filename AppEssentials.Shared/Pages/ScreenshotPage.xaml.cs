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
    public partial class ScreenshotPage : ContentPage
    {
        public ScreenshotPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (Screenshot.IsCaptureSupported)
            {
                var screenshot = await Screenshot.CaptureAsync();
                var stream = await screenshot.OpenReadAsync();

                ImageScreenshot.Source = ImageSource.FromStream(() => stream);
            }
        }
    }
}