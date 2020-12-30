using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Validation;

namespace FooModule.Validation
{
    public class BookService : IRemoteService, IBookService, IValidationEnabled, ITransientDependency
    {
        private readonly ILogger<BookService> _logger;

        public BookService(ILogger<BookService> logger)
        {
            _logger = logger;
        }

        //[DisableValidation]
        //[EnableValidation]
        public virtual async Task CreateAsync(CreateBookDto bookDto)
        {
            await Task.CompletedTask;

            _logger.LogInformation("The {0} has been created.", bookDto.Name);
        }
    }
}
