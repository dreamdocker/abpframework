using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace FooModule.Exceptions
{
    public class ExceptionController : AbpController
    {
        public IActionResult Exception()
        {
            //throw new BusinessException("Foo:001").WithData("UserName", "john");

            throw new BusinessException("Foo:001")
            {
                Data = { { "UserName", "john" } }
            };
        }
    }
}
