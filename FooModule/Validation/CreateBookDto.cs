using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Volo.Abp.Validation;

namespace FooModule.Validation
{
    public class CreateBookDto : IValidatableObject
    {
        [Required]
        [StringLength(10)]
        [DynamicStringLength(typeof(CreateBookDto), "NameMaxLength")]
        [Display(Name = "书名")]
        public string Name { get; set; }

        [Range(0, 10)]
        public decimal Price { get; set; }

        public static int NameMaxLength { get; set; } = 6;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //var myService = validationContext.GetRequiredService<IMyService>();

            if (!string.IsNullOrWhiteSpace(Name) && Name.Any(c => char.IsNumber(c)))
            {
                yield return new ValidationResult("The name cannot contain numbers!", new[] { nameof(Name) });
            }
        }
    }
}
