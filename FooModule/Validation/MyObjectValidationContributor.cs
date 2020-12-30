using System.ComponentModel.DataAnnotations;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Validation;

namespace FooModule.Validation
{
    public class MyObjectValidationContributor : IObjectValidationContributor, ITransientDependency
    {
        public void AddErrors(ObjectValidationContext context)
        {
            //Get the validating object
            var obj = context.ValidatingObject;

            if (obj is CreateBookDto)
            {
                var bookDto = obj as CreateBookDto;

                if (bookDto.Price == 8)
                {
                    var result = new ValidationResult("Price is not equal to 8", new string[] { nameof(bookDto.Price) });

                    //Add the validation errors if available
                    context.Errors.Add(result);
                }
            }
        }
    }
}
