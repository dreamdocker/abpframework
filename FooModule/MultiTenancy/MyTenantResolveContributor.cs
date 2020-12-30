using System.Threading.Tasks;
using Volo.Abp.MultiTenancy;

namespace FooModule.MultiTenancy
{
    public class MyTenantResolveContributor : TenantResolveContributorBase
    {
        public override string Name => "Custom";

        public async override Task ResolveAsync(ITenantResolveContext context)
        {
            context.Handled = false;

            await Task.CompletedTask;
        }
    }
}
