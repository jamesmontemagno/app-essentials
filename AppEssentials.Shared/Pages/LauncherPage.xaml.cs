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
    public partial class LauncherPage : ContentPage
    {
        public LauncherPage()
        {
            InitializeComponent();
        }

        private async void ButtonLauncher_Clicked(object sender, EventArgs e)
        {
            if(await Launcher.CanOpenAsync("lyft://"))
            {
                await Launcher.OpenAsync("lyft://ridetype?id=lyft_line");
            }
        }
    }
}