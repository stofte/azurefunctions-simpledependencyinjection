using Microsoft.Extensions.DependencyInjection;

namespace AzureFunctions.Extensions.SimpleDependencyInjection
{
    public interface IContainerConfigurator
    {
        void Configure(IServiceCollection services);
    }
}
