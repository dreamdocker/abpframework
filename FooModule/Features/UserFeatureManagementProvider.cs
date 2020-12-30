using Volo.Abp.DependencyInjection;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Users;

namespace FooModule.Features
{
    public class UserFeatureManagementProvider : FeatureManagementProvider, ITransientDependency
    {
        public override string Name => UserFeatureValueProvider.ProviderName;

        protected ICurrentUser CurrentUser { get; }

        public UserFeatureManagementProvider(IFeatureManagementStore store, ICurrentUser currentUser) : base(store)
        {
            CurrentUser = currentUser;
        }

        protected override string NormalizeProviderKey(string providerKey)
        {
            if (providerKey != null)
            {
                return providerKey;
            }

            return CurrentUser.Id?.ToString();
        }
    }
}
