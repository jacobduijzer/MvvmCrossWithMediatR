using System;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Localization;
using MvvmCross.ViewModels;
using MediatrTest.Core.Helpers;
using MediatrTest.Core.ViewModels;
using MediatR;
using System.Linq;

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

            RegisterAppStart<StartViewModel>();
        }

        public override void Reset()
        {
            base.Reset();
        }
    }
}
