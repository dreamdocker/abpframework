using FooModule.Authorization;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.PermissionManagement;

namespace FooModule.Features
{
    public class FeatureDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IPermissionManager _permissionManager;

        public FeatureDataSeederContributor(IPermissionManager permissionManager)
        {
            _permissionManager = permissionManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _permissionManager.SetAsync(MyPermissions.Cats.Default, "U", "a7234ca4-2130-46dd-b77a-1d94412cbb01", true);
            await _permissionManager.SetAsync(MyPermissions.Cats.Default, "U", "a7234ca4-2130-46dd-b77a-1d94412cbb02", true);
        }
    }
}
