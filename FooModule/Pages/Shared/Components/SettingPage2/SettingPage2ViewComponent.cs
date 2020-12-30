using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.SettingManagement;

namespace FooModule.Pages.Shared.Components.SettingPage2
{
    public class SettingPage2ViewComponent : AbpViewComponent
    {
        private readonly ISettingManager _settingManager;

        public SettingPage2ViewComponent(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        public IViewComponentResult Invoke()
        {
            var settingValues = _settingManager.GetAllGlobalAsync().Result
                .Where(x => x.Name.StartsWith("Example"))
                .ToDictionary(t => t.Name, t => t.Value);

            return View("~/Pages/Shared/Components/SettingPage1/Default.cshtml", settingValues);
        }
    }
}