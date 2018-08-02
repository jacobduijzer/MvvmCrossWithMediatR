

using MvvmCross.Forms.Core;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.IoC;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.ViewModels;
using UIKit;

namespace MediatrTest.iOS
{
    public class Setup : MvxFormsIosSetup<Core.CoreApp, Core.FormsApp>
    {
        //public Setup(IMvxApplicationDelegate applicationDelegate, UIWindow window)
        //    : base(applicationDelegate, window)
        //{
        //}

        //protected override IMvxApplication CreateApp() => new CoreApp();
        //protected override MvxFormsApplication CreateFormsApplication() => new Core.Application();
        //protected override IMvxTrace CreateDebugTrace() => new DebugTrace();

        protected override IMvxIocOptions CreateIocOptions()
        {
            return new MvxIocOptions()
            {
                PropertyInjectorOptions = MvxPropertyInjectorOptions.MvxInject
            };
        }
    }
}

