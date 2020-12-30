using FooModule.AuditLogging;
using FooModule.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace FooModule.EntityFramework
{
    public static class HelloWorldDbContextModelCreatingExtensions
    {
        public static void ConfigureExamples(this ModelBuilder modelBuilder)
        {
            Check.NotNull(modelBuilder, nameof(modelBuilder));

            modelBuilder.Entity<Apple>(b =>
            {
                b.ToTable("Apples", "Foo");
                b.ConfigureByConvention();
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            });

            modelBuilder.Entity<Article>(b =>
            {
                b.ToTable("Articles", "Foo");
                b.ConfigureByConvention();
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).IsRequired().HasMaxLength(50);
            });
        }
    }
}
