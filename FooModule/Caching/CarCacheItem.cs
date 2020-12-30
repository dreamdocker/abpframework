using System;
using Volo.Abp.Caching;

namespace FooModule.Caching
{
    [CacheName("CarCustomName")]
    public class CarCacheItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }
    }
}
