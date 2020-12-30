using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;

namespace FooModule.MultiTenancy
{
    public class ArticleAppService : ApplicationService
    {
        private readonly IRepository<Article, int> _articleRepository;

        private readonly IDataFilter _dataFilter;

        public ArticleAppService(IRepository<Article, int> articleRepository, IDataFilter dataFilter)
        {
            _articleRepository = articleRepository;
            _dataFilter = dataFilter;
        }

        public async Task<IEnumerable<Article>> GetAsync()
        {
            //using (CurrentTenant.Change(Guid.Parse("b1f14a2a-9539-6f03-5db5-0898ed7ae902")))
            //{
            //    IEnumerable<Article> result2 = await _articleRepository.GetListAsync();
            //}

            //using (CurrentTenant.Change(null))
            //{
            //    IEnumerable<Article> result0 = await _articleRepository.GetListAsync();
            //}

            //using (_dataFilter.Disable<IMultiTenant>())
            //{
            //    return await _articleRepository.GetListAsync();
            //}

            return await _articleRepository.GetListAsync();
        }

        public async Task<Article> CreateAsync(string title)
        {
            var product = new Article { TenantId = CurrentTenant.Id, Title = title };

            return await _articleRepository.InsertAsync(product);
        }
    }
}