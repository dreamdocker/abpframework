using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace FooModule.MultiTenancy
{
    public class ArticleDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Article, int> _articleRepository;

        public ArticleDataSeederContributor(IRepository<Article, int> articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _articleRepository.GetCountAsync() <= 0)
            {
                await _articleRepository.InsertAsync(
                    new Article
                    {
                        Title = "Article0"
                    },
                    autoSave: true
                );

                await _articleRepository.InsertAsync(
                    new Article
                    {
                        Title = "Article1",
                        TenantId = Guid.Parse("b1f14a2a-9539-6f03-5db5-0898ed7ae901")
                    },
                    autoSave: true
                );

                await _articleRepository.InsertAsync(
                    new Article
                    {
                        Title = "Article2",
                        TenantId = Guid.Parse("b1f14a2a-9539-6f03-5db5-0898ed7ae902")
                    },
                    autoSave: true
                );
            }
        }
    }
}
