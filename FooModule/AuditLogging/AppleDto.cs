using Volo.Abp.Application.Dtos;

namespace FooModule.AuditLogging
{
    public class AppleDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}