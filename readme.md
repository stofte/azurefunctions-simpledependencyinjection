Azure Functions v2 Simple Dependency Injection
==============================================

[Note: v2 function runtimes only](https://docs.microsoft.com/en-us/azure/azure-functions/functions-versions)

Packaged code based on [Boris Wilhelms code](https://blog.wille-zone.de/post/azure-functions-proper-dependency-injection/). A basic configuration interface has been added to enable packaging. The code expects a single implementation of this interface. The container configuration is shared by all functions in the app. This package requires `3.0.0-beta8` of the `Microsoft.Azure.WebJobs` package.

Configuration example:

    using AzureFunctions.Extensions.SimpleDependencyInjection;

    namespace MyFunctionApp 
    {
        public class Startup : IContainerConfigurator
        {
            // IContainerConfigurator interface
            public void Configure(IServiceCollection services)
            {
                // supports basic registrations+scoped (as in article)
                services.AddSingleton(new FooService());
            }
        }
    }   

Usage example:

	[InjectFilter]
    public static class MyFunction
    {
        [FunctionName("MyFunction")]
        public static async Task Run(
            [TimerTrigger("%myfunctimer%")] TimerInfo myTimer,
            [Inject] FooService fooSvc
            )
        {
    
        }
    }
