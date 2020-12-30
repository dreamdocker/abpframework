using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FooModule.Localization
{
    public class LocalizationController : AbpController
    {
        private readonly IStringLocalizer<TestResource> _localizer;

        public LocalizationController(IStringLocalizer<TestResource> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult HelloWorld()
        {
            return Content(_localizer.GetString("HelloWorld"));
        }
    }
}
