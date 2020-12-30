using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace FooModule.AuditLogging
{
    public class AppleDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Apple, int> _appleRepository;

        public AppleDataSeederContributor(IRepository<Apple, int> appleRepository)
        {
            _appleRepository = appleRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _appleRepository.GetCountAsync() <= 0)
            {
                await _appleRepository.InsertAsync(
                    new Apple
                    {
                        Name = "Apple1"
                    },
                    autoSave: true
                );

                await _appleRepository.InsertAsync(
                    new Apple
                    {
                        Name = "Apple2"
                    },
                    autoSave: true
                );
            }
        }
    }
}
