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
    public partial class ClipboardPage : ContentPage
    {
        public ClipboardPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (EntryPin.Text == "1234")
                DisplayAlert("You did it!", "Pin was accepted!", "OK");
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if(Clipboard.HasText)
            {
                var text = await Clipboard.GetTextAsync();
                if (text.Length == 4)
                    EntryPin.Text = text;
            }
        }
    }
}