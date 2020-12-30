using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace FooModule.Domain
{
    public class MouseAppService : ApplicationService
    {
        private readonly IRepository<Mouse2> _mouseRepository;

        public MouseAppService(IRepository<Mouse2> mouseRepository)
        {
            _mouseRepository = mouseRepository;
        }

        public async Task GetTestAsync()
        {
            var mouse = new Mouse2(GuidGenerator.Create())
            {
                Brand = "Microsoft",
                Price = 88.00F
            };

            Address address1 = new Address();
            Address address2 = new Address();

            bool result = address1.ValueEquals(address2);

            await _mouseRepository.InsertAsync(mouse);
        }
    }
}