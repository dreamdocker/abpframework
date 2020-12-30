using System;
using Volo.Abp.Domain.Entities;

namespace FooModule.Domain
{
    public class Issue : AggregateRoot<Guid>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public Guid? AssignedUserId { get; internal set; }
    }
}
