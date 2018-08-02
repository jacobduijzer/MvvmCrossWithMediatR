using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;

namespace MediatrTest.Droid
{
    [Activity(
        Label = "MainActivity",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        LaunchMode = LaunchMode.SingleTask)]
    public class MainActivity : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
        }
    }
}