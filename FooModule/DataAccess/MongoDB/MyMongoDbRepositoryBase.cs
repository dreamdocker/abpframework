using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

/// <summary>
/// options.SetDefaultRepositoryClasses(typeof(MyRepositoryBase<,>), typeof(MyRepositoryBase<>));
/// </summary>
namespace FooModule.DataAccess.MongoDB
{
    public class MyMongoDBRepositoryBase<TEntity> : MongoDbRepository<IDogMongoDbContext, TEntity> where TEntity : class, IEntity
    {
        public MyMongoDBRepositoryBase(IMongoDbContextProvider<DogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return base.InsertAsync(entity, autoSave, cancellationToken);
        }
    }

    public class MyMongoDBRepositoryBase<TEntity, TKey> : MongoDbRepository<DogMongoDbContext, TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        public MyMongoDBRepositoryBase(IMongoDbContextProvider<DogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return base.InsertAsync(entity, autoSave, cancellationToken);
        }
    }
}
