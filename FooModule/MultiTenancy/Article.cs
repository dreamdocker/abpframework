using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace FooModule.MultiTenancy
{
    public class Article : Entity<int>, IMultiTenant
    {
        public Guid? TenantId { get; set; }

        public string Title { get; set; }
    }
}