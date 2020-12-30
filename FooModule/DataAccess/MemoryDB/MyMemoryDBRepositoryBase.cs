using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.MemoryDb;
using Volo.Abp.MemoryDb;

namespace FooModule.DataAccess.MemoryDb
{
    public class MyMemoryDbRepositoryBase<TEntity> : MemoryDbRepository<DogMemoryDbContext, TEntity> where TEntity : class, IEntity
    {
        public MyMemoryDbRepositoryBase(IMemoryDatabaseProvider<DogMemoryDbContext> databaseProvider) : base(databaseProvider)
        {
        }

        public override Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return base.InsertAsync(entity, autoSave, cancellationToken);
        }
    }

    public class MyMemoryDbRepositoryBase<TEntity, TKey> : MemoryDbRepository<DogMemoryDbContext, TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        public MyMemoryDbRepositoryBase(IMemoryDatabaseProvider<DogMemoryDbContext> databaseProvider) : base(databaseProvider)
        {
        }

        public override Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return base.InsertAsync(entity, autoSave, cancellationToken);
        }
    }
}
