using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.Domain.Entities;

namespace FooModule.Authorization
{
    [Authorize(MyPermissions.Cats.Default)]
    public class CatAppService : ApplicationService, ICatAppService
    {
        private static List<CatDto> catDtos = new List<CatDto>()
        {
            new CatDto { ID=1, Name="Cat001" },
            new CatDto { ID=2, Name="Cat002" }
        };

        public async Task<List<CatDto>> GetListAsync() => await Task.FromResult(catDtos);

        [Authorize("MyPolicy2")]
        public async Task<CatDto> GetAsync(int id)
        {
            return await Task.FromResult(catDtos.Find(a => a.ID == id));
        }

        [Authorize(MyPermissions.Cats.Create)]
        public async Task CreateAsync(CatDto input)
        {
            if (!catDtos.Any(a => a.ID == input.ID))
            {
                catDtos.Add(input);
            }

            await Task.CompletedTask;
        }

        [Authorize(MyPermissions.Cats.Edit)]
        public async Task UpdateAsync(CatDto input)
        {
            var catDto = catDtos.Find(a => a.ID == input.ID);

            if (catDto == null)
            {
                throw new EntityNotFoundException(typeof(CatDto));
            }

            catDto.Name = input.Name;

            await Task.CompletedTask;
        }

        [Authorize(MyPermissions.Cats.Delete)]
        public async Task DeleteAsync(int id)
        {
            catDtos.RemoveAll(a => a.ID == id);

            await Task.CompletedTask;
        }

        public async Task Create2Async()
        {
            string policyName = MyPermissions.Cats.Create;

            //Method 1

            var result = await AuthorizationService.AuthorizeAsync(policyName);
            if (!result.Succeeded)
            {
                throw new AbpAuthorizationException();
            }

            //Method 2

            await AuthorizationService.CheckAsync(policyName);


            //Method 3

            bool isGranted = await AuthorizationService.IsGrantedAsync(policyName);

            Console.WriteLine(isGranted);
        }
    }
}
