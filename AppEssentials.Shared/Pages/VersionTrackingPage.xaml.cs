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
    public partial class VersionTrackingPage : ContentPage
    {
        public VersionTrackingPage()
        {
            InitializeComponent();
            LabelCurrent.Text = $"{VersionTracking.CurrentBuild} ({VersionTracking.CurrentVersion})";
            LabelPast.Text = $"{VersionTracking.PreviousBuild} ({VersionTracking.PreviousVersion})";

            if (VersionTracking.IsFirstLaunchForCurrentBuild)
                LabelNew.Text = "New Version";

        }
    }
}