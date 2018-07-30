using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctions.Extensions.SimpleDependencyInjection
{
    public interface IContainerConfigurator
    {
        void Configure(IServiceCollection services);
    }
}
