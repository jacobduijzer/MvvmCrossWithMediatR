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

            Mvx.IoCProvider.RegisterSingleton<IMvxTextProvider>(new TextProviderBuilder().TextProvider);

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IMediator, Mediator>();

            Mvx.IoCProvider.RegisterSingleton<ServiceFactory>((Type serviceType) =>
            {
                var resolver = Mvx.IoCProvider.Resolve<IMvxIoCProvider>();

                if(resolver.CanResolve(serviceType))
                    return resolver.Resolve(serviceType);
                
                // a "bit" buggy, I know!
                return Array.CreateInstance(serviceType.GenericTypeArguments[0], 0);
            });

            RegisterAppStart<LoginViewModel>();
        }
    }
}
