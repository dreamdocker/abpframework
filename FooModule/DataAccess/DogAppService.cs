using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;

namespace FooModule.DataAccess
{
    public class DogAppService : ApplicationService
    {
        private readonly IRepository<Dog, int> _dogRepository;

        public DogAppService(IRepository<Dog, int> dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public async Task<object> GetListAsync()
        {
            var dog3 = new Dog(3) { Name = "Dog3", Age = 33 };

            await _dogRepository.InsertAsync(dog3);

            await _dogRepository.DeleteAsync(1);

            await _dogRepository.UpdateAsync(new Dog(2) { Name = "Dog22", Age = 222 });

            dog3.SetProperty("Remark", "This is Dog.");
            await _dogRepository.UpdateAsync(dog3);

            var dogs = await _dogRepository.GetListAsync();

            return new { dogs };
        }
    }
}