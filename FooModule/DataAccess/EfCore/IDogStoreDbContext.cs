using Microsoft.EntityFrameworkCore;

namespace FooModule.DataAccess.EfCore
{
    public interface IDogStoreDbContext
    {
        DbSet<Dog> Dogs { get; set; }
    }
}
