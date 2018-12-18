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
	public partial class AppInfoPage : ContentPage
	{
		public AppInfoPage ()
		{
			InitializeComponent ();

            LabelAppInfo.Text = $"{AppInfo.Name}";
            LabelVersionInfo.Text = $"{AppInfo.VersionString} " +
                $"{AppInfo.BuildString}";

        }
	}
}