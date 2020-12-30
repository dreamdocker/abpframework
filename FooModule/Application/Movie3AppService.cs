using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace FooModule.Application
{
    public class MovieKey
    {
        public Guid MovieId { get; set; }

        public string MovieName { get; set; }
    }

    public class Movie3AppService : AbstractKeyCrudAppService<Movie, Movie, MovieKey>
    {
        public Movie3AppService(IRepository<Movie, Guid> repository) : base(repository)
        {
        }

        protected async override Task DeleteByIdAsync(MovieKey id)
        {
            await Repository.DeleteAsync(m => m.Id == id.MovieId && m.Name == id.MovieName);
        }

        protected async override Task<Movie> GetEntityByIdAsync(MovieKey id)
        {
            var query = Repository.Where(m => m.Id == id.MovieId && m.Name == id.MovieName);
            return await AsyncExecuter.FirstOrDefaultAsync(query);
        }
    }
}