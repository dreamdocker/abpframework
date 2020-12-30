using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;

namespace FooModule.Caching
{
    public class Car3Service : IRemoteService, ITransientDependency
    {
        private readonly IDistributedCache<CarCacheItem, CarCacheKey> _cache;

        public Car3Service(IDistributedCache<CarCacheItem, CarCacheKey> cache)
        {
            _cache = cache;
        }

        public async Task<CarCacheItem> GetAsync(Guid carId)
        {
            return await _cache.GetOrAddAsync(
                new CarCacheKey { Id = carId, CarType = "MZ" },
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
