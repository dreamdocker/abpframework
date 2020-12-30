using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace FooModule.Application
{
    public class Movie5AppService : CrudAppService<Movie, Movie, Guid>, IMovieAppService
    {
        public Movie5AppService(IRepository<Movie, Guid> repository) : base(repository)
        {
        }

        protected override IQueryable<Movie> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input).Where(m => m.Name.Length > 3);
        }

        protected override IQueryable<Movie> ApplyPaging(IQueryable<Movie> query, PagedAndSortedResultRequestDto input)
        {
            return base.ApplyPaging(query, input);
        }

        protected override IQueryable<Movie> ApplySorting(IQueryable<Movie> query, PagedAndSortedResultRequestDto input)
        {
            return base.ApplySorting(query, input);
        }

        protected override IQueryable<Movie> ApplyDefaultSorting(IQueryable<Movie> query)
        {
            return query.OrderBy(m => m.Price);
        }

        protected override Task<Movie> GetEntityByIdAsync(Guid id)
        {
            return base.GetEntityByIdAsync(id);
        }

        protected override Task DeleteByIdAsync(Guid id)
        {
            return base.DeleteByIdAsync(id);
        }
    }
}