using FooModule.Pages.Shared.Components.SettingPage1;
using FooModule.Pages.Shared.Components.SettingPage2;
using System;
using System.Threading.Tasks;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;

namespace FooModule.Settings
{
    public class MySettingPageContributor : ISettingPageContributor
    {
        public async Task<bool> CheckPermissionsAsync(SettingPageCreationContext context)
        {
            return await Task.FromResult(true);
        }

        public async Task ConfigureAsync(SettingPageCreationContext context)
        {
            context.Groups.Add(new SettingPageGroup(Guid.NewGuid().ToString(), "设置1", typeof(SettingPage1ViewComponent)));
            context.Groups.Add(new SettingPageGroup(Guid.NewGuid().ToString(), "设置2", typeof(SettingPage2ViewComponent)));

            await Task.CompletedTask;
        }
    }
}