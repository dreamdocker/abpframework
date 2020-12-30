using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.PermissionManagement;

namespace FooModule.Authorization
{
    public class MyPermissionExampleService : ApplicationService, ITransientDependency
    {
        private readonly IPermissionManager _permissionManager;

        public MyPermissionExampleService(IPermissionManager permissionManager)
        {
            _permissionManager = permissionManager;
        }

        public async Task GetAsync()
        {
            await _permissionManager.SetAsync(MyPermissions.Cats.Create, "U", "user2", true);
        }

        public async Task GrantPermissionForUserAsync(string userId, string permissionName)
        {
            await _permissionManager.SetAsync(permissionName, "U", userId, true);
        }

        public async Task ProhibitPermissionForUserAsync(string userId, string permissionName)
        {
            await _permissionManager.SetAsync(permissionName, "T", userId, false);
        }
    }
}
