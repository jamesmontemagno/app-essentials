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
	public partial class SharePage : ContentPage
	{
		public SharePage ()
		{
			InitializeComponent ();
		}

        private async void ButtonShare_Clicked(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = EntryShare.Text,
                Title = "Share!"
            });
        }
    }
}