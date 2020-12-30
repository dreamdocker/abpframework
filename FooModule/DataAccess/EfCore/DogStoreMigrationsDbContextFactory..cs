
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FooModule.DataAccess.EfCore
{
    public class DogStoreMigrationsDbContextFactory : IDesignTimeDbContextFactory<DogStoreMigrationsDbContext>
    {
        public DogStoreMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false).Build();

            var builder = new DbContextOptionsBuilder<DogStoreMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("DogStore"), ServerVersion.FromString("3.1"));

            return new DogStoreMigrationsDbContext(builder.Options);
        }
    }
}