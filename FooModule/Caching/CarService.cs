using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;

namespace FooModule.Caching
{
    public class CarService : IRemoteService, ITransientDependency
    {
        private readonly IDistributedCache<CarCacheItem> _cache;

        public CarService(IDistributedCache<CarCacheItem> cache)
        {
            _cache = cache;
        }

        public async Task<CarCacheItem> GetAsync(Guid carId)
        {
            return await _cache.GetOrAddAsync(
                carId.ToString(),
                async () => await GetCarFromDatabaseAsync(carId),
                () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
                }
            );
        }

        private async Task<CarCacheItem> GetCarFromDatabaseAsync(Guid bookId)
        {
            await Task.Delay(TimeSpan.FromSeconds(3));

            return new CarCacheItem { Id = bookId, Name = "Porsche", Price = 88.88F };
        }
    }
}
