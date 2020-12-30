using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FooModule.DataAccess.EfCore
{
    [ConnectionStringName(DogStoreDbProperties.ConnectionStringName)]
    public class DogStoreDbContext : AbpDbContext<DogStoreDbContext>, IDogStoreDbContext
    {
        public DbSet<Dog> Dogs { get; set; }

        public DogStoreDbContext(DbContextOptions<DogStoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureEntities();
        }
    }
}