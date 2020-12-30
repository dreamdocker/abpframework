using Dapper.Contrib.Extensions;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace FooModule.DataAccess.Dapper
{
    [ExposeServices(typeof(IDogDapperRepository))]
    public class Dog3DapperRepository : IDogDapperRepository, IDisposable, ITransientDependency
    {
        private readonly IDbConnection _dbConnection;

        public Dog3DapperRepository(IConnectionStringResolver connectionStringResolver)
        {
            string connectionString = connectionStringResolver.Resolve("DogStore");
            //_dbConnection = new Microsoft.Data.SqlClient.SqlConnection(connectionString);
            _dbConnection = new MySqlConnection(connectionString);
        }

        public virtual async Task<int> Create(DogEntry dogEntry)
        {
            return await _dbConnection.InsertAsync(dogEntry);
        }

        public virtual async Task<bool> Delete(int id)
        {
            return await _dbConnection.DeleteAsync(new DogEntry { Id = id });
        }

        public virtual async Task<IEnumerable<DogEntry>> GetAll()
        {
            return await _dbConnection.GetAllAsync<DogEntry>();
        }

        public virtual async Task<bool> Update(DogEntry dogEntry)
        {
            return await _dbConnection.UpdateAsync(dogEntry);
        }

        public void Dispose()
        {
            _dbConnection?.Dispose();
        }
    }
}