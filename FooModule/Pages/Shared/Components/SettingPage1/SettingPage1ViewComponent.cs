using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.SettingManagement;

namespace FooModule.Pages.Shared.Components.SettingPage1
{
    public class SettingPage1ViewComponent : AbpViewComponent
    {
        private readonly ISettingManager _settingManager;

        public SettingPage1ViewComponent(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        public IViewComponentResult Invoke()
        {
            var settingValues = _settingManager.GetAllGlobalAsync().Result
                .Where(x => x.Name.StartsWith("Smtp"))
                .ToDictionary(t => t.Name, t => t.Value);

            return View("~/Pages/Shared/Components/SettingPage1/Default.cshtml", settingValues);
        }
    }
}