#MvvmCross with MediatR

I started using MediatR a while ago but didn't get into the full benefits of the MediatR library. Last week I decided to give it a try but found out it was much harder than I thought. All samples of the library are working with different kind of IoC container frameworks but **not** with **MvvmCross**.

After debugging the MediatR source we found out that (at least autofac but since other frameworks work too I guess they do the same) return an empty array when a Type cannot be resolved.

From the [source](https://github.com/jbogard/MediatR/blob/master/src/MediatR/Internal/RequestHandlerWrapper.cs):

```
return serviceFactory
                .GetInstances<IPipelineBehavior<TRequest, TResponse>>()
                .Reverse()
                .Aggregate((RequestHandlerDelegate<TResponse>) Handler, (next, pipeline) => () => pipeline.Handle((TRequest)request, cancellationToken, next))();
```

After splitting it to debug:

```
var test1 = serviceFactory.GetInstances<IPipelineBehavior<TRequest, TResponse>>();

            var test2 = test1.Reverse();

            var test3 = test2.Aggregate((RequestHandlerDelegate<TResponse>)Handler, (next, pipeline) => () => pipeline.Handle((TRequest)request, cancellationToken, next))();

            return test3;
```

With MvvmCross test1 throws an exception:

```
{MvvmCross.Exceptions.MvxIoCResolveException: Failed to resolve type System.Collections.Generic.IEnumerable`1[[MediatR.IPipelineBehavior`2[[MediatR.Examples.Ping, MediatR.Examples, Version=5.1.0.0, Culture=neutral, PublicKeyToken=null],[MediatR.Examples.Pong, MediatR.Examples, Version=5.1.0.0, Culture=neutral, PublicKeyToken=null]], MediatR, Version=5.1.0.0, Culture=neutral, PublicKeyToken=null]]    at MvvmCross.IoC.MvxIoCContainer.Resolve(Type t) in C:\projects\mvvmcross\MvvmCross\IoC\MvxIoCContainer.cs:line 246    at MediatR.Examples.MvvmCross.UnitTest1.<>c.<Test1>b__0_0(Type serviceType) in /Users/jacob.duijzer/Downloads/MediatR-5.1.0/samples/MediatR.Examples.MvvmCross/UnitTest1.cs:line 34}
```

While AutoFac returns:

```
{MediatR.IPipelineBehavior<MediatR.Examples.Ping, MediatR.Examples.Pong>[0]}
```


My current work-around it this:

```
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
```

I know it is buggy code but I ran out of time for now and just want to share my experiences. Hopefully I will jump back into it in a while.

[MvvmCross](https://www.mvvmcross.com)

[MediatR](https://github.com/jbogard/MediatR)