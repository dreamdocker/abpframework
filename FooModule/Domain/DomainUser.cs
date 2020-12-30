using System;
using Volo.Abp.Domain.Entities;

namespace FooModule.Domain
{
    public class DomainUser : AggregateRoot<Guid>
    {
        public string UserName { get; set; }
    }
}
