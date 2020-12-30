using Volo.Abp.Domain.Entities;

namespace FooModule.AuditLogging
{
    public class Apple : Entity<int>
    {
        public string Name { get; set; }
    }
}
