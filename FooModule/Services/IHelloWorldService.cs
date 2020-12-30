using System.Threading.Tasks;

namespace FooModule.Services
{
    public interface IHelloWorldService
    {
        Task<string> HelloWorld();
    }
}
