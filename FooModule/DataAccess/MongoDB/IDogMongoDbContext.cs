using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FooModule.DataAccess.MongoDB
{
    [ConnectionStringName("DogStore")]
    public interface IDogMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<Dog> Dogs { get; }
    }
}
