using Microsoft.Azure.WebJobs.Description;
using System;

namespace AzureFunctions.Extensions.SimpleDependencyInjection
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
    }
}
