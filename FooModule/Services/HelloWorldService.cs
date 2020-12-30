using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace FooModule.Services
{
    public class HelloWorldService : IHelloWorldService, ITransientDependency
    {
        public async Task<string> HelloWorld()
        {
            await Task.CompletedTask;

            return "Hello,World!";
        }
    }
}