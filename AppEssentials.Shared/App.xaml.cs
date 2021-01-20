using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppEssentials.Shared.Pages;
using AppEssentials.Shared;
using Xamarin.Essentials;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
[assembly: ExportFont("FASolid.otf", Alias = "FA")]
namespace AppEssentials
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

            Xamarin.Essentials.VersionTracking.Track();

            AppActions.OnAppAction += AppActions_OnAppAction;

            MainPage = new AppShell();
        }

        private void AppActions_OnAppAction(object sender, AppActionEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (e.AppAction.Id == "app_info")
                    await Shell.Current.GoToAsync("//" + nameof(AppInfoPage));
            });
        }

        protected override async void OnStart()
		{
            // Handle when your app starts

            try
            {
				await AppActions.SetAsync(new AppAction("app_info", "Essentials App Info"));
            }
            catch (System.Exception ex)
            {

            }
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
