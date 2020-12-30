using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Http;
using Volo.Abp.VirtualFileSystem;

namespace FooModule.VirtualFileSystem
{
    public class VirtualFileController : AbpController
    {
        private readonly IVirtualFileProvider _virtualFileProvider;

        public VirtualFileController(IVirtualFileProvider virtualFileProvider)
        {
            _virtualFileProvider = virtualFileProvider;
        }

        public async Task<IActionResult> ReadFile()
        {
            var fileInfo = _virtualFileProvider.GetFileInfo("/FooModule/MyResources/Localization/en.json");

            //string fileString = await fileInfo.ReadAsStringAsync();

            var fileBytes = await fileInfo.ReadBytesAsync();

            return File(fileBytes, MimeTypes.Application.Json);
        }
    }
}