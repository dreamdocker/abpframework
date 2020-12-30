using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace FooModule.DataAccess.MongoDB
{
    public class DogMongoDbRepository : MongoDbRepository<IDogMongoDbContext, Dog, int>, IDogRepository
    {
        public DogMongoDbRepository(IMongoDbContextProvider<IDogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task DeleteDogsByAge(int age)
        {
            await Collection.DeleteManyAsync(Builders<Dog>.Filter.Eq(b => b.Age, age));
        }

        public override Task<Dog> UpdateAsync(Dog entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(entity, autoSave, cancellationToken);
        }
    }
}
