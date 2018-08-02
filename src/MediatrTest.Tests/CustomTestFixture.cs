using MvvmCross.Tests;
using Xunit;
using MvvmCross.IoC;
using MediatR;
using System;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace MediatrTest.Tests
{
    public class CustomTestFixture : MvxTestFixture
    {
        public CustomTestFixture()
        {
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
            
            Ioc.LazyConstructAndRegisterSingleton<IMediator, Mediator>();
        }
    }
}
