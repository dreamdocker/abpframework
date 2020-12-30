using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;

namespace FooModule.DataAccess
{
    public class Dog : Entity<int>, IHasExtraProperties
    {
        public Dog(int id) : base(id)
        {

        }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public ExtraPropertyDictionary ExtraProperties { get; }
    }
}