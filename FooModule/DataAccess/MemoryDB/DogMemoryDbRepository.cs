using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MemoryDb;
using Volo.Abp.MemoryDb;

namespace FooModule.DataAccess.MemoryDb
{
    public class DogMemoryDbRepository : MemoryDbRepository<DogMemoryDbContext, Dog, int>, IDogRepository
    {
        public DogMemoryDbRepository(IMemoryDatabaseProvider<DogMemoryDbContext> databaseProvider) : base(databaseProvider)
        {
        }

        public async Task DeleteDogsByAge(int age)
        {
            var entities = GetQueryable().Where(d => d.Age == age).ToList();

            foreach (var entity in entities)
            {
                await DeleteAsync(entity);
            }
        }

        public override Task<Dog> InsertAsync(Dog entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return base.InsertAsync(entity, autoSave, cancellationToken);
        }
    }
}
