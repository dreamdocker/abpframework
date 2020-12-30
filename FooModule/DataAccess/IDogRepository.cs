using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FooModule.DataAccess
{
    public interface IDogRepository : IRepository<Dog, int>
    {
        Task DeleteDogsByAge(int age);
    }
}