using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace FooModule.Application
{
    public interface IMovieAppService: IApplicationService
    {
        Task<Movie> CreateAsync(Movie movie);

        Task<Movie> GetAsync(Guid id);
    }
}