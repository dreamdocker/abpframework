using System;
using Volo.Abp.TenantManagement;

namespace FooModule.MultiTenancy
{
    public class MyTenant : Tenant
    {
        public MyTenant(Guid id, string name) : base(id, name)
        {
        }
    }
}