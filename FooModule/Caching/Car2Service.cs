using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;

namespace FooModule.Caching
{
    public class Car2Service : IRemoteService, ITransientDependency
    {
        private readonly IDistributedCache<CarCacheItem, Guid> _cache;

        public Car2Service(IDistributedCache<CarCacheItem, Guid> cache)
        {
            _cache = cache;
        }

        public async Task<CarCacheItem> GetAsync(Guid carId)
        {
            return await _cache.GetOrAddAsync(
                carId,
                async () => await GetCarFromDatabaseAsync(carId),
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
                }
            );
        }

        private async Task<CarCacheItem> GetCarFromDatabaseAsync(Guid carId)
        {
            await Task.Delay(TimeSpan.FromSeconds(3));

            return new CarCacheItem { Id = carId, Name = "Porsche", Price = 88.88F };
        }
    }
}
