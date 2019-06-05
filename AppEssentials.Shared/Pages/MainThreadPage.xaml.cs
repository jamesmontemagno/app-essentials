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
    public partial class MainThreadPage : ContentPage
    {
        public MainThreadPage()
        {
            InitializeComponent();
        }
        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.IsEnabled = false;
            LoadingIndicator.IsRunning = true;

            await Task.Run(async () =>
            {
                //do work here.
                for(int i = 0; i < 5; i++)
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        LabelUpdate.Text = $"Update #{i}";
                    });
                    await Task.Delay(1000);
                }
            });

            LoadingIndicator.IsRunning = false;
            button.IsEnabled = true;
        }
    }
}