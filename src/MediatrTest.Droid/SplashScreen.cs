using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Core;
using MvvmCross.Forms.Platforms.Android.Views;
using MvvmCross.Platforms.Android.Views;

namespace MediatrTest.Droid
{
    // No Splash Screen: To remove splash screen, remove this class and uncomment lines in MainActivity
    [Activity(
        Label = "MediatrTest.Droid"
        , MainLauncher = true
        , Icon = "@mipmap/ic_launcher"
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxFormsSplashScreenActivity<Setup, Core.CoreApp, Core.FormsApp>
    {
        protected override void RunAppStart(Bundle bundle)
        {
            StartActivity(typeof(MainActivity));
            base.RunAppStart(bundle);
        }
    }
}