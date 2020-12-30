using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FooModule.DataAccess.EfCore
{
    /// <summary>
    /// options.AddRepository<Dog, EfCoreDogRepository>();
    /// </summary>
    public class EfCoreDogRepository : EfCoreRepository<DogStoreDbContext, Dog, int>, IDogRepository
    {
        public EfCoreDogRepository(IDbContextProvider<DogStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task DeleteDogsByAge(int age)
        {
            await DbContext.Database.ExecuteSqlRawAsync($"DELETE FROM AbpDogs WHERE Age = {age}");
        }

        public override Task<Dog> InsertAsync(Dog entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return base.InsertAsync(entity, autoSave, cancellationToken);
        }
    }
}