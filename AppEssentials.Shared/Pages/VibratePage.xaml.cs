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
    public partial class VibratePage : ContentPage
    {
        public VibratePage()
        {
            InitializeComponent();
        }

        private void ButtonVibrate_Clicked(object sender, EventArgs e)
        {
            Vibration.Vibrate(TimeSpan.FromMilliseconds(SliderTime.Value));
        }

        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            Vibration.Cancel();
        }
    }
}