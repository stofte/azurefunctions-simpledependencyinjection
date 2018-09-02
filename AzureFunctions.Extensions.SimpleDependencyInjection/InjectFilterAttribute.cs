using Microsoft.Azure.WebJobs.Host;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AzureFunctions.Extensions.SimpleDependencyInjection
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class InjectFilterAttribute : FunctionInvocationFilterAttribute, IFunctionExceptionFilter
    {
        public override Task OnExecutingAsync(FunctionExecutingContext executingContext, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        
        public override Task OnExecutedAsync(FunctionExecutedContext executedContext, CancellationToken cancellationToken)
        {
            RemoveScope(executedContext.FunctionInstanceId);
            return Task.CompletedTask;
        }

        public Task OnExceptionAsync(FunctionExceptionContext exceptionContext, CancellationToken cancellationToken)
        {
            RemoveScope(exceptionContext.FunctionInstanceId);
            return Task.CompletedTask;
        }

        private void RemoveScope(Guid id)
        {
            if (InjectBindingProvider.Scopes.TryRemove(id, out var scope))
            {
                scope.Dispose();
            }
        }
    }
}
