using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace FooModule.AuditLogging
{
    public class AppleAppService : CrudAppService<Apple, AppleDto, int, PagedAndSortedResultRequestDto, AppleDto>, IRemoteService
    {
        public AppleAppService(IRepository<Apple, int> repository) : base(repository)
        {

        }
    }
}
