using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Settings;

namespace FooModule.Settings
{
    public class CustomSettingValueProvider : ISettingValueProvider, ITransientDependency
    {
        public string Name => "M";

        private readonly ISettingStore _settingStore;

        private readonly ICurrentTenant _currentTenant;

        public CustomSettingValueProvider(ISettingStore settingStore, ICurrentTenant currentTenant)
        {
            _settingStore = settingStore;
            _currentTenant = currentTenant;
        }

        public async Task<List<SettingValue>> GetAllAsync(SettingDefinition[] settings)
        {
            return await _settingStore.GetAllAsync(settings.Select(x => x.Name).ToArray(), Name, _currentTenant.Id?.ToString());
        }

        public async Task<string> GetOrNullAsync(SettingDefinition setting)
        {
            if (setting.Name == "Example.Setting3")
            {
                return await Task.FromResult("www.xcode.me");
            }

            return null;
        }
    }
}
