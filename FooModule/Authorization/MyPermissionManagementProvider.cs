using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Volo.Abp.PermissionManagement
{
    public class MyRolePermissionManagementProvider : PermissionManagementProvider
    {
        public MyRolePermissionManagementProvider(IPermissionGrantRepository permissionGrantRepository, IGuidGenerator guidGenerator, ICurrentTenant currentTenant) : base(permissionGrantRepository, guidGenerator, currentTenant)
        {
        }

        public override string Name => RolePermissionValueProvider.ProviderName;
    }

    public class MyUserPermissionManagementProvider : PermissionManagementProvider
    {
        public MyUserPermissionManagementProvider(IPermissionGrantRepository permissionGrantRepository, IGuidGenerator guidGenerator, ICurrentTenant currentTenant) : base(permissionGrantRepository, guidGenerator, currentTenant)
        {
        }

        public override string Name => UserPermissionValueProvider.ProviderName;
    }
}