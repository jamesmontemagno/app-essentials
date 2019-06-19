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
    public partial class SmsPage : ContentPage
    {
        public SmsPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {

                await Sms.ComposeAsync(new SmsMessage(EntryMessage.Text,
                    EntryNumber.Text));

            }
            catch (Exception)
            {
                await DisplayAlert("Unable to send sms", "Check phone number and try again.", "OK");
            }
        }
    }
}