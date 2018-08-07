using System;
using MediatR;
using MediatrTest.Core.Interfaces.LoginService;
using MediatrTest.Core.Services.LoginService;
using Moq;
using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvvmCross.Tests;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace MediatrTest.Tests
{
    public class CustomTestFixture : MvxTestFixture
    {
        public readonly Mock<IMvxNavigationService> MockNavigationService;

        public CustomTestFixture()
        {
            MockNavigationService = new Mock<IMvxNavigationService>();
            Ioc.RegisterSingleton<IMvxNavigationService>(MockNavigationService.Object);

            Ioc.RegisterSingleton<ServiceFactory>((Type serviceType) =>
            {
                var resolver = Ioc.Resolve<IMvxIoCProvider>();
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

            typeof(MediatrTest.Core.CoreApp)
                .Assembly
                .CreatableTypes()
                .EndingWith("Handler")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Ioc.LazyConstructAndRegisterSingleton<ILoginService, FakeLoginService>();
            
            Ioc.LazyConstructAndRegisterSingleton<IMediator, Mediator>();
        }
    }
}
