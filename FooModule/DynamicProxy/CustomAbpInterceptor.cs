using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.DynamicProxy;

namespace FooModule.DynamicProxy
{
    public class CustomAbpInterceptor : AbpInterceptor, ITransientDependency
    {
        private readonly ILogger<CustomAbpInterceptor> _logger;

        public CustomAbpInterceptor(ILogger<CustomAbpInterceptor> logger)
        {
            _logger = logger;
        }

        public override async Task InterceptAsync(IAbpMethodInvocation invocation)
        {
            _logger.LogTrace($"{invocation.Method.Name} Executing ...");

            await invocation.ProceedAsync();

            _logger.LogTrace($"{invocation.Method.Name} Executed ...");
        }
    }
}
