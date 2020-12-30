using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.FeatureManagement;

namespace FooModule.Features
{
    public static class UserFeatureManagerExtensions
    {
        public static Task<string> GetOrNullForUserAsync(this IFeatureManager featureManager, string name, Guid userId, bool fallback = true)
        {
            return featureManager.GetOrNullAsync(name, UserFeatureValueProvider.ProviderName, userId.ToString(), fallback);
        }

        public static Task<List<FeatureNameValue>> GetAllForUserAsync(this IFeatureManager featureManager, Guid userId, bool fallback = true)
        {
            return featureManager.GetAllAsync(UserFeatureValueProvider.ProviderName, userId.ToString(), fallback);
        }

        public static Task<FeatureNameValueWithGrantedProvider> GetOrNullWithProviderForUserAsync(this IFeatureManager featureManager, string name, Guid userId, bool fallback = true)
        {
            return featureManager.GetOrNullWithProviderAsync(name, UserFeatureValueProvider.ProviderName, userId.ToString(), fallback);
        }

        public static Task<List<FeatureNameValueWithGrantedProvider>> GetAllWithProviderForUserAsync(this IFeatureManager featureManager, Guid userId, bool fallback = true)
        {
            return featureManager.GetAllWithProviderAsync(UserFeatureValueProvider.ProviderName, userId.ToString(), fallback);
        }

        public static Task SetForUserAsync(this IFeatureManager featureManager, Guid userId, string name, string value, bool forceToSet = false)
        {
            return featureManager.SetAsync(name, value, UserFeatureValueProvider.ProviderName, userId.ToString(), forceToSet);
        }
    }
}
