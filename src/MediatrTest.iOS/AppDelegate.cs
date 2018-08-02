using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using UIKit;

namespace MediatrTest.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.CoreApp, Core.FormsApp>
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            UINavigationBar.Appearance.BarTintColor = UIColor.White;
            UINavigationBar.Appearance.TintColor = UIColor.White;

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
