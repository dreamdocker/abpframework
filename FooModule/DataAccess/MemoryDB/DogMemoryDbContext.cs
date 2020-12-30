using System;
using System.Collections.Generic;
using Volo.Abp.Data;
using Volo.Abp.MemoryDb;

namespace FooModule.DataAccess.MemoryDb
{
    [ConnectionStringName("DogStore")]
    public class DogMemoryDbContext : MemoryDbContext
    {
        private static readonly Type[] EntityTypeList = {
            typeof(Dog)
        };

        public override IReadOnlyList<Type> GetEntityTypes()
        {
            return EntityTypeList;
        }
    }
}