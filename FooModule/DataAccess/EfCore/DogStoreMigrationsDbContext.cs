using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FooModule.DataAccess.EfCore
{
    public class DogStoreMigrationsDbContext : AbpDbContext<DogStoreMigrationsDbContext>
    {
        public DogStoreMigrationsDbContext(DbContextOptions<DogStoreMigrationsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureEntities();
        }
    }
}