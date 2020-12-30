using System;
using System.ComponentModel.DataAnnotations;

namespace FooModule.Authorization
{
    public class CatDto
    {
        [Range(1, int.MaxValue)]
        public int ID { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
    }
}
