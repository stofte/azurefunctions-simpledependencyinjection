using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Config;

using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AzureFunctions.Extensions.SimpleDependencyInjection
{
    [Extension("Inject")]
    public class InjectConfiguration : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context
                .AddBindingRule<InjectAttribute>()
                .Bind(new InjectBindingProvider(DependencyInjection.LazyProvider));
        }
    }
}
