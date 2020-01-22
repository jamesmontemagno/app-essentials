using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Essentials;

namespace AppEssentials.Shared.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlashlightPage : ContentPage
    {
        public FlashlightPage()
        {
            InitializeComponent();
        }

        private async void ButtonOn_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Flashlight.TurnOnAsync();
            }
            catch (Exception)
            {

            }

        }

        private async void ButtonOff_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Flashlight.TurnOffAsync();

            }
            catch (Exception)
            {

            }
        }
    }
}