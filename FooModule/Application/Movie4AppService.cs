using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace FooModule.Application
{
    public class Movie4AppService : CrudAppService<Movie, Movie, Guid>, IMovieAppService
    {
        public Movie4AppService(IRepository<Movie, Guid> repository) : base(repository)
        {
            GetPolicyName = "...";
            GetListPolicyName = "...";
            CreatePolicyName = "...";
            UpdatePolicyName = "...";
            DeletePolicyName = "...";
        }

        protected async override Task CheckCreatePolicyAsync()
        {
            await AuthorizationService.CheckAsync("...");
        }
    }
}