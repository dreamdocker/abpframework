using System.Threading.Tasks;

namespace FooModule.Validation
{
    public interface IBookService
    {
        Task CreateAsync(CreateBookDto bookDto);
    }
}
