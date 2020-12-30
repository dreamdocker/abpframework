using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace FooModule.Application
{
    public class Movie6AppService : CrudAppService<Movie, Movie, Guid>, IMovieAppService
    {
        public Movie6AppService(IRepository<Movie, Guid> repository) : base(repository)
        {
        }

        public async Task Upload(IRemoteStreamContent streamContent)
        {
            using var fs = new FileStream(@"C:\abc.xls", FileMode.OpenOrCreate);

            await streamContent.GetStream().CopyToAsync(fs);

            await fs.FlushAsync();
        }

        public Task<IRemoteStreamContent> Download()
        {
            var fs = new FileStream(@"C:\abc.xls", FileMode.OpenOrCreate);

            return Task.FromResult((IRemoteStreamContent)new RemoteStreamContent(fs)
            {
                ContentType = "application/octet-stream"
            });
        }
    }
}