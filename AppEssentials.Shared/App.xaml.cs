using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppEssentials.Shared.Pages;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppEssentials
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

            Xamarin.Essentials.VersionTracking.Track();

			MainPage = new MasterPage();


		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
