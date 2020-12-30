using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace FooModule.Application
{
    public class MovieDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Movie, Guid> _movieRepository;

        public MovieDataSeederContributor(IRepository<Movie, Guid> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            Random random = new Random();

            if (await _movieRepository.GetCountAsync() <= 0)
            {
                for (int i = 1; i <= 20; i++)
                {
                    Movie movie = new(Guid.NewGuid(), $"Movice{i}", random.Next(1000, 9999));
                    await _movieRepository.InsertAsync(movie, true);
                }
            }
        }
    }
}
