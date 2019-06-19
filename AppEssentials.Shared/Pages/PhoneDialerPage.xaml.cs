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
    public partial class PhoneDialerPage : ContentPage
    {
        public PhoneDialerPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open(EntryNumber.Text);
            }
            catch (Exception ex)
            {
                DisplayAlert("Unable to make call", "Please enter a number", "OK");
            }
        }
    }
}