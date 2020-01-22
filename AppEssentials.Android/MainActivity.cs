
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using AppEssentials.Shared.Models;
using Xamarin.Forms;
using System.Drawing;
using Xamarin.Essentials;

namespace AppEssentials.Droid
{
    [Activity(Label = "AppEssentials.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);

            DependencyService.Register<IStatusBar, StatusBarChanger>();
            
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

       
    }

    public class StatusBarChanger : IStatusBar
    {
        public void SetStatusBarColor(System.Drawing.Color color)
        {
            if (Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop)
                return;

            var window = ((MainActivity)Forms.Context).Window;
            window.AddFlags(Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
            window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);
            var androidColor = color.ToPlatformColor();

            window.SetStatusBarColor(androidColor);
            
        }

    }
}
