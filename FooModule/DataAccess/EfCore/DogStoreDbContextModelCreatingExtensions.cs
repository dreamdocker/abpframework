using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.ObjectExtending;

namespace FooModule.DataAccess.EfCore
{
    public static class DogStoreDbContextModelCreatingExtensions
    {
        public static void ConfigureEntities(this ModelBuilder modelBuilder)
        {
            Check.NotNull(modelBuilder, nameof(modelBuilder));

            ObjectExtensionManager.Instance.MapEfCoreProperty<Dog, string>("Remark", (entityBuilder, propertyBuilder) => { propertyBuilder.HasMaxLength(DogConsts.MaxRemarkLength); });

            modelBuilder.Entity<Dog>(b =>
            {
                b.ToTable($"{DogStoreDbProperties.DbTablePrefix}Dogs", DogStoreDbProperties.DbSchema);
                b.ConfigureByConvention();
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).HasMaxLength(DogConsts.MaxRemarkLength);
            });
        }
    }
}
