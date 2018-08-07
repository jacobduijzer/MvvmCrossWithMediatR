using System;
using MediatR;
using MediatrTest.Core.Helpers;
using MediatrTest.Core.ViewModels.Login;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Localization;
using MvvmCross.ViewModels;

namespace MediatrTest.Core
{
    public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("Handler")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterSingleton<IMvxTextProvider>(new TextProviderBuilder().TextProvider);

            Mvx.LazyConstructAndRegisterSingleton<IMediator, Mediator>();

            Mvx.RegisterSingleton<ServiceFactory>((Type serviceType) =>
            {
                var resolver = Mvx.Resolve<IMvxIoCProvider>();

                try
                {
                    return resolver.Resolve(serviceType);
                }
                catch (Exception)
                {
                    // a "bit" buggy, I know!
                    return Array.CreateInstance(serviceType.GenericTypeArguments[0], 0);
                }
            });

            RegisterAppStart<LoginViewModel>();
        }
    }
}
