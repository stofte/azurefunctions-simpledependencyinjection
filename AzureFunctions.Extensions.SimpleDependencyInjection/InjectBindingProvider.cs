using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzureFunctions.Extensions.SimpleDependencyInjection
{
    public class InjectBindingProvider : IBindingProvider
    {
        private readonly Lazy<IServiceProvider> _serviceProvider;

        public static readonly ConcurrentDictionary<Guid, IServiceScope> Scopes =
            new ConcurrentDictionary<Guid, IServiceScope>();

        public InjectBindingProvider(Lazy<IServiceProvider> serviceProvider) =>
            _serviceProvider = serviceProvider;

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            IBinding binding = new InjectBinding(_serviceProvider.Value, context.Parameter.ParameterType);
            return Task.FromResult(binding);
        }
    }
}
