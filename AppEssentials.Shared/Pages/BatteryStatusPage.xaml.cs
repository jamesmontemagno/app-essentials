
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEssentials.Shared.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BatteryStatusPage : ContentPage
    {
        public BatteryStatusPage()
        {
            InitializeComponent();

            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
        }

        private void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            SetBackground(e.ChargeLevel, e.State == BatteryState.Charging || e.State == BatteryState.Full);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        void SetBackground(double level, bool charging)
        {
            Color? color = null;
            var status = "";
            if(level > .5f)
            {
                color = Color.Green.MultiplyAlpha(level);
            }
            else if(level > .1f)
            {
                color = Color.Yellow.MultiplyAlpha(1d - level);
            }
            else
            {
                color = Color.Red.MultiplyAlpha(1d - level);
            }

            BackgroundColor = color.Value;
            LabelBatteryLevel.Text = status;

        }

    }
}