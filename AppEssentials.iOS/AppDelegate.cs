using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace AppEssentials.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}

		public override void PerformActionForShortcutItem(UIApplication application, UIApplicationShortcutItem shortcutItem, UIOperationHandler completionHandler)
				=> Xamarin.Essentials.Platform.PerformActionForShortcutItem(application, shortcutItem, completionHandler);
	}
}
