using Dapper;
using FooModule.DataAccess.EfCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;

namespace FooModule.DataAccess.Dapper
{
    [ExposeServices(typeof(IDogDapperRepository))]
    public class DogDapperRepository : DapperRepository<DogStoreDbContext>, IDogDapperRepository, ITransientDependency
    {
        public DogDapperRepository(IDbContextProvider<DogStoreDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<int> Create(DogEntry dogEntry)
        {
            string sql = "INSERT INTO AbpDogs(Name,Age) VALUES(@Name,@Age)";
            return await DbConnection.ExecuteAsync(sql, dogEntry, DbTransaction);
        }

        public virtual async Task<bool> Delete(int id)
        {
            string sql = "DELETE FROM AbpDogs WHERE ID=@ID";
            return await DbConnection.ExecuteAsync(sql, new { id }, DbTransaction) > 0;
        }

        public virtual async Task<bool> Update(DogEntry dogEntry)
        {
            string sql = "UPDATE AbpDogs SET Name=@Name,Age=@Age WHERE ID=@ID";
            return await DbConnection.ExecuteAsync(sql, dogEntry, DbTransaction) > 0;
        }

        public virtual async Task<IEnumerable<DogEntry>> GetAll()
        {
            string sql = "SELECT ID,Name,Age FROM AbpDogs";
            return await DbConnection.QueryAsync<DogEntry>(sql, DbTransaction);
        }
    }
}