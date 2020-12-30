
using Dapper.Contrib.Extensions;

namespace FooModule.DataAccess.Dapper
{
    [Table("AbpDogs")]
    public class DogEntry
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
