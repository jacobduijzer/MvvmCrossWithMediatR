using MvvmCross.Tests;
using Xunit;
using MvvmCross.IoC;
using MediatR;
using MediatrTest.Core.Models;
using MediatrTest.Core.Handlers;
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

            Ioc.LazyConstructAndRegisterSingleton<IRequestHandler<Ping, Pong>, PingHandler>();
            Ioc.LazyConstructAndRegisterSingleton<IMediator, Mediator>();
        }
    }
}
