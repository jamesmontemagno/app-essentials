using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.IO;

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
            var info = EntryShare.Text;
            if (string.IsNullOrWhiteSpace(info))
                return;
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = info,
                Title = "Share!"
            });
        }

        private async void ButtonShareFile_Clicked(object sender, EventArgs e)
        {
            var info = EntryShare.Text;
            if (string.IsNullOrWhiteSpace(info))
                return;

            var path = string.Empty;
            path = Path.Combine(FileSystem.CacheDirectory, "Attachment.txt");
            File.WriteAllText(path, info);

            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Hello from Xamarin.Essentials",
                File = new ShareFile(path)
            });
        }
    }
}