Azure Functions v2 Simple Dependency Injection
==============================================

[Note: v2 function runtimes only](https://docs.microsoft.com/en-us/azure/azure-functions/functions-versions)

Packaged code based on [Boris Wilhelms code](https://blog.wille-zone.de/post/azure-functions-proper-dependency-injection/). A basic configuration interface has been added to enable packaging. The code expects a single implementation of this interface. The container configuration is shared by all functions in the app.


Configuration example:

    using AzureFunctions.Extensions.SimpleDependencyInjection;

    namespace MyFunctionApp 
	{
        public class Startup : IContainerConfigurator
        {
            public void Configure(IServiceCollection services)
            {
                // supports basic registrations+scoped (as in article)
                services.AddSingleton(...);
                services.AddSingleton<...>();
            }
        }
    }   

Usage example:

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
