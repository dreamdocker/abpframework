using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FooModule.EntityFramework
{
    public class LoggingMigrationsDbContext : AbpDbContext<LoggingMigrationsDbContext>
    {
        public LoggingMigrationsDbContext(DbContextOptions<LoggingMigrationsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureAuditLogging();
        }
    }
}
