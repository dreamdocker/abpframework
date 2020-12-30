using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.Features
{
    public class MyFeatureStore : IFeatureStore, ISingletonDependency
    {
        public async Task<string> GetOrNullAsync(string name, string providerName, string providerKey)
        {
            if (name == "MyApp.MaxProductCount")
            {
                return await Task.FromResult("55");
            }

            return await Task.FromResult<string>(null);
        }
    }
}