using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Validation;

namespace FooModule.Validation
{
    public class BookController : AbpController
    {
        private readonly IBookService _bookService;

        private readonly IObjectValidator _objectValidator;

        public BookController(IBookService bookService, IObjectValidator objectValidator)
        {
            _bookService = bookService;
            _objectValidator = objectValidator;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateBookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            return Ok(bookDto);
        }

        public async Task<IActionResult> Create(string name, decimal price)
        {
            var bookDto = new CreateBookDto { Name = name, Price = price };

            await _bookService.CreateAsync(bookDto);

            return Ok(bookDto);
        }

        public IActionResult CreateForObjectValidator(string name, decimal price)
        {
            var bookDto = new CreateBookDto { Name = name, Price = price };

            _objectValidator.Validate(bookDto);

            //var results = _objectValidator.GetErrors(bookDto);

            return Ok(bookDto);
        }
    }
}
