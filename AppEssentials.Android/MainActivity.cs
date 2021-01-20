
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using AppEssentials.Shared.Models;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace AppEssentials.Droid
{
    [IntentFilter(new[] { Xamarin.Essentials.Platform.Intent.ActionAppAction },
                          Categories = new[] { Android.Content.Intent.CategoryDefault })]
    [Activity(Label = "AppEssentials", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);

            DependencyService.Register<IStatusBar, StatusBarChanger>();
            
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnResume()
        {
            base.OnResume();

            Xamarin.Essentials.Platform.OnResume(this);
        }

        protected override void OnNewIntent(Android.Content.Intent intent)
        {
            base.OnNewIntent(intent);

            Xamarin.Essentials.Platform.OnNewIntent(intent);
        }

    }

    public class StatusBarChanger : IStatusBar
    {
        public void SetStatusBarColor(System.Drawing.Color color)
        {
            if (Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop)
                return;

            var window = Platform.CurrentActivity.Window;
            window.AddFlags(Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
            window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);
            var androidColor = color.ToPlatformColor();

            window.SetStatusBarColor(androidColor);
            
        }

    }
}
