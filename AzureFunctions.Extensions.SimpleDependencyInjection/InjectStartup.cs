using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            builder.AddExtension(new InjectConfiguration());
        }
    }
}
