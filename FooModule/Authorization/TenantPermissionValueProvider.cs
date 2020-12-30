using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Security.Claims;

namespace FooModule.Authorization
{
    public class TenantPermissionValueProvider : PermissionValueProvider
    {
        public TenantPermissionValueProvider(IPermissionStore permissionStore) : base(permissionStore)
        {
        }

        public const string ProviderName = "T";

        public override string Name => ProviderName;

        public override async Task<PermissionGrantResult> CheckAsync(PermissionValueCheckContext context)
        {
            var tenantId = context.Principal?.FindFirst(AbpClaimTypes.TenantId)?.Value;

            if (tenantId == null)
            {
                return PermissionGrantResult.Undefined;
            }

            return await PermissionStore.IsGrantedAsync(context.Permission.Name, Name, tenantId)
                ? PermissionGrantResult.Granted
                : PermissionGrantResult.Undefined;
        }

        public override async Task<MultiplePermissionGrantResult> CheckAsync(PermissionValuesCheckContext context)
        {
            var permissionNames = context.Permissions.Select(x => x.Name).ToArray();

            var tenantId = context.Principal?.FindFirst(AbpClaimTypes.TenantId)?.Value;

            if (tenantId == null)
            {
                return new MultiplePermissionGrantResult(permissionNames);
            }

            return await PermissionStore.IsGrantedAsync(permissionNames, Name, tenantId);
        }
    }
}