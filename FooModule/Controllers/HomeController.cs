using FooModule.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace FooModule.Controllers
{
    public class HomeController : AbpController
    {
        private readonly IHelloWorldService _helloWorldService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(IHelloWorldService helloWorldService, ILogger<HomeController> logger)
        {
            _helloWorldService = helloWorldService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            string hello = await _helloWorldService.HelloWorld();

            _logger.LogError(hello);

            return Content(hello);
        }
    }
}
