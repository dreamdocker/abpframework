using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace FooModule.Domain
{
    public class IssueManager : DomainService
    {
        private readonly IRepository<Issue, Guid> _issueRepository;

        public IssueManager(IRepository<Issue, Guid> issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task AssignAsync(Issue issue, DomainUser user)
        {
            var currentIssueCount = _issueRepository.Count(i => i.AssignedUserId == user.Id);

            //Implementing a core business validation
            if (currentIssueCount >= 3)
            {
                throw new BusinessException("The user still has at least 3 unresolved issues.");
            }

            issue.AssignedUserId = user.Id;

            await Task.CompletedTask;
        }
    }
}
