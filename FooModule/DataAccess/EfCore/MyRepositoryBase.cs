using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

/// <summary>
/// options.SetDefaultRepositoryClasses(typeof(MyRepositoryBase<,>), typeof(MyRepositoryBase<>));
/// </summary>
namespace FooModule.DataAccess.EfCore
{
    public class MyRepositoryBase<TEntity> : EfCoreRepository<DogStoreDbContext, TEntity> where TEntity : class, IEntity
    {
        public MyRepositoryBase(IDbContextProvider<DogStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return base.InsertAsync(entity, autoSave, cancellationToken);
        }
    }

    public class MyRepositoryBase<TEntity, TKey> : EfCoreRepository<DogStoreDbContext, TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        public MyRepositoryBase(IDbContextProvider<DogStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(predicate, autoSave, cancellationToken);
        }
    }
}
