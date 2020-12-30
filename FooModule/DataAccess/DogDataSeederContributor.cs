using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace FooModule.DataAccess
{
    public class DogDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Dog> _dogRepository;

        public DogDataSeederContributor(IRepository<Dog> dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _dogRepository.GetCountAsync() <= 0)
            {
                await _dogRepository.InsertAsync(
                    new Dog(1)
                    {
                        Name = "Dog1",
                        Age = 11
                    },
                    autoSave: true
                );

                await _dogRepository.InsertAsync(
                    new Dog(2)
                    {
                        Name = "Dog2",
                        Age = 22
                    },
                    autoSave: true
                );
            }
        }
    }
}
