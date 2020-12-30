using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace FooModule.Application
{
    public class Movie1AppService : ApplicationService, IMovieAppService
    {
        private readonly IRepository<Movie, Guid> _moviceRepository;

        public Movie1AppService(IRepository<Movie, Guid> moviceRepository)
        {
            _moviceRepository = moviceRepository;
        }

        public async Task<Movie> CreateAsync(Movie movie)
        {
            return await _moviceRepository.InsertAsync(movie);
        }

        public async Task<List<Movie>> GetListAsync()
        {
            return await _moviceRepository.GetListAsync();
        }

        public async Task<Movie> GetAsync(Guid id)
        {
            return await _moviceRepository.GetAsync(id);
        }
    }
}