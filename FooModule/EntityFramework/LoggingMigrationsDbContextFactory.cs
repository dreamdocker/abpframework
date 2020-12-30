using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FooModule.EntityFramework
{
    public class LoggingMigrationsDbContextFactory : IDesignTimeDbContextFactory<LoggingMigrationsDbContext>
    {
        public LoggingMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false).Build();

            var builder = new DbContextOptionsBuilder<LoggingMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("AbpAuditLogging"));

            return new LoggingMigrationsDbContext(builder.Options);
        }
    }
}
