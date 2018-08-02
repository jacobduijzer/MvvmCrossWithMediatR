using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.IoC;

namespace MediatrTest.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.CoreApp, Core.FormsApp>
    {
        protected override IMvxIocOptions CreateIocOptions()
        {
            return new MvxIocOptions()
            {
                PropertyInjectorOptions = MvxPropertyInjectorOptions.MvxInject
            };
        }
    }
}
