using System.Collections.Generic;
using System.Threading.Tasks;

namespace FooModule.Authorization
{
    public interface ICatAppService
    {
        Task CreateAsync(CatDto input);

        Task DeleteAsync(int id);

        Task<CatDto> GetAsync(int id);

        Task<List<CatDto>> GetListAsync();

        Task UpdateAsync(CatDto input);
    }
}