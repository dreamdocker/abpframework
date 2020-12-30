using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace FooModule.Application
{
    public class Movie2AppService : CrudAppService<Movie, Movie, Guid>, IMovieAppService
    {
        public Movie2AppService(IRepository<Movie, Guid> repository) : base(repository)
        {
          
        }
    }
}