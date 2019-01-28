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
    public partial class ConnectivityPage : ContentPage
    {
        public ConnectivityPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            LabelStatus.Text = $"Network Access: {Connectivity.NetworkAccess}";
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }
               
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }

        private async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            LabelStatus.Text = $"Network Access: {e.NetworkAccess}";
            await DisplayAlert("Connectivity Changed",
                $"Network Access: {e.NetworkAccess}",
                "OK");
        }
    }
}