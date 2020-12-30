using FooModule.Application;
using FooModule.AuditLogging;
using FooModule.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace FooModule.EntityFramework
{
    [ConnectionStringName(ConnectionStrings.DefaultConnectionStringName)]
    public class HelloWorldDbContext : AbpDbContext<HelloWorldDbContext>
    {
        public DbSet<Apple> Apples { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public HelloWorldDbContext(DbContextOptions<HelloWorldDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureExamples();

            modelBuilder.ConfigurePermissionManagement();

            modelBuilder.ConfigureAuditLogging();

            modelBuilder.ConfigureSettingManagement();

            modelBuilder.ConfigureFeatureManagement();

            modelBuilder.ConfigureTenantManagement();
        }
    }
}
