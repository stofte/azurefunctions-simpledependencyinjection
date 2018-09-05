using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: WebJobsStartup(typeof(AzureFunctions.Extensions.SimpleDependencyInjection.InjectStartup))]
namespace AzureFunctions.Extensions.SimpleDependencyInjection
{
    public class InjectStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddSingleton<IFunctionFilter, ScopeCleanupFilter>();
            builder.AddExtension<InjectConfiguration>();
        }
    }
}
