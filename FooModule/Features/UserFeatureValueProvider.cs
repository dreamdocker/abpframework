using System.Threading.Tasks;
using Volo.Abp.Features;
using Volo.Abp.Users;

namespace FooModule.Features
{
    public class UserFeatureValueProvider : FeatureValueProvider
    {
        private readonly ICurrentUser _currentUser;

        public UserFeatureValueProvider(IFeatureStore featureStore, ICurrentUser currentUser) : base(featureStore)
        {
            _currentUser = currentUser;
        }

        public const string ProviderName = "U";

        public override string Name => ProviderName;

        public override async Task<string> GetOrNullAsync(FeatureDefinition feature)
        {
            return await FeatureStore.GetOrNullAsync(feature.Name, Name, _currentUser?.Id?.ToString());
        }
    }
}