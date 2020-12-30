using FooModule.MultiTenancy;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy.ConfigurationStore;
using Volo.Abp.TenantManagement;

namespace FooModule.AuditLogging
{
    public class TenantDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly ITenantRepository _tenantRepository;

        private readonly AbpDefaultTenantStoreOptions _options;

        public TenantDataSeederContributor(ITenantRepository tenantRepository, ITenantManager tenantManager, IOptionsSnapshot<AbpDefaultTenantStoreOptions> options)
        {
            _tenantRepository = tenantRepository;
            _options = options.Value;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _tenantRepository.GetCountAsync() <= 0)
            {
                foreach (var tenant in _options.Tenants)
                {
                    var myTenant = new MyTenant(tenant.Id, tenant.Name);

                    myTenant.ConnectionStrings.AddRange(tenant.ConnectionStrings.Select(cs => new TenantConnectionString(myTenant.Id, cs.Key, cs.Value)));

                    await _tenantRepository.InsertAsync(myTenant, autoSave: true);
                }
            }
        }
    }
}