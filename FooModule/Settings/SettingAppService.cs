using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace FooModule.Settings
{
    public class SettingAppService : ApplicationService
    {
        private readonly ISettingProvider _settingProvider;

        private readonly ISettingManager _settingManager;

        //Inject ISettingProvider in the constructor
        public SettingAppService(ISettingProvider settingProvider, ISettingManager settingManager)
        {
            _settingProvider = settingProvider;
            _settingManager = settingManager;
        }

        public async Task CreateAsync()
        {
            var httpContextAccessor = ServiceProvider.GetService<IHttpContextAccessor>();

            foreach (var item in httpContextAccessor.HttpContext.Request.Form)
            {
                await _settingManager.SetGlobalAsync(item.Key, item.Value.First());
            }

            await Task.CompletedTask;
        }

        public async Task<object> GetAsync()
        {
            //Get a value as string.
            string host = await _settingProvider.GetOrNullAsync("Smtp.Host");

            //string host2 = await SettingProvider.GetOrNullAsync("Smtp.Host");

            //Get a bool value and fallback to the default value (false) if not set.
            bool enableSsl1 = await _settingProvider.GetAsync<bool>("Smtp.EnableSsl");

            //Get a bool value and fallback to the provided default value (true) if not set.
            bool enableSsl2 = await _settingProvider.GetAsync("Smtp.EnableSsl", defaultValue: true);

            //Get a bool value with the IsTrueAsync shortcut extension method
            bool enableSsl3 = await _settingProvider.IsTrueAsync("Smtp.EnableSsl");

            //Get an int value or the default value (0) if not set
            int port1 = await _settingProvider.GetAsync<int>("Smtp.Port");

            //Get an int value or null if not provided
            int? port2 = (await _settingProvider.GetOrNullAsync("Smtp.Port"))?.To<int>();

            string setting1 = await _settingProvider.GetOrNullAsync("Example.Setting1");

            string setting2 = await _settingProvider.GetOrNullAsync("Example.Setting2");

            string setting3 = await _settingProvider.GetOrNullAsync("Example.Setting3");

            return new { host, enableSsl1, enableSsl2, enableSsl3, port1, port2, setting1, setting2, setting3 };
        }
    }
}
