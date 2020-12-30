using System.Collections.Generic;
using System.Threading.Tasks;

namespace FooModule.DataAccess.Dapper
{
    public interface IDogDapperRepository
    {
        Task<int> Create(DogEntry dogEntry);

        Task<bool> Delete(int id);

        Task<bool> Update(DogEntry dogEntry);

        Task<IEnumerable<DogEntry>> GetAll();
    }
}
