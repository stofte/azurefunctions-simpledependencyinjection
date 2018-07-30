using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctions.Extensions.SimpleDependencyInjection
{
    public class InjectBindingProvider : IBindingProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public static readonly ConcurrentDictionary<Guid, IServiceScope> Scopes =
            new ConcurrentDictionary<Guid, IServiceScope>();

        public InjectBindingProvider(IServiceProvider serviceProvider) =>
            _serviceProvider = serviceProvider;

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {

            IBinding binding = new InjectBinding(_serviceProvider, context.Parameter.ParameterType);
            return Task.FromResult(binding);
        }
    }
}
