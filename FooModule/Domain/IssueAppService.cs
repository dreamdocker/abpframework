using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace FooModule.Domain
{
    public class IssueAppService : ApplicationService
    {
        private readonly IssueManager _issueManager;

        private readonly IRepository<DomainUser, Guid> _userRepository;

        private readonly IRepository<Issue, Guid> _issueRepository;

        public IssueAppService(IssueManager issueManager, IRepository<DomainUser, Guid> userRepository, IRepository<Issue, Guid> issueRepository)
        {
            _issueManager = issueManager;
            _userRepository = userRepository;
            _issueRepository = issueRepository;
        }

        public async Task AssignAsync(Guid issueId, Guid userId)
        {
            var issue = await _issueRepository.GetAsync(issueId);
            var user = await _userRepository.GetAsync(userId);

            await _issueManager.AssignAsync(issue, user);
            await _issueRepository.UpdateAsync(issue);
        }
    }
}
