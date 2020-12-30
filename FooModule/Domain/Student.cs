using System;
using Volo.Abp.Domain.Entities;

namespace FooModule.Domain
{
    public class Student : AggregateRoot<Guid>
    {
        public string Name { get; set; }

        public byte Age { get; set; }

        public long Balance { get; set; }

        public string Location { get; set; }
    }
}