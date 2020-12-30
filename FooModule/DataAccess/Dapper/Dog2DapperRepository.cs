using Dapper.Contrib.Extensions;
using FooModule.DataAccess.EfCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;

namespace FooModule.DataAccess.Dapper
{
    [ExposeServices(typeof(IDogDapperRepository))]
    public class Dog2DapperRepository : DapperRepository<DogStoreDbContext>, IDogDapperRepository, ITransientDependency
    {
        public Dog2DapperRepository(IDbContextProvider<DogStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<int> Create(DogEntry dogEntry)
        {
            return await DbConnection.InsertAsync(dogEntry, DbTransaction);
        }

        public virtual async Task<bool> Delete(int id)
        {
            return await DbConnection.DeleteAsync(new DogEntry { Id = id }, DbTransaction);
        }

        public virtual async Task<IEnumerable<DogEntry>> GetAll()
        {
            return await DbConnection.GetAllAsync<DogEntry>();
        }

        public virtual async Task<bool> Update(DogEntry dogEntry)
        {
            return await DbConnection.UpdateAsync(dogEntry, DbTransaction);
        }
    }
}