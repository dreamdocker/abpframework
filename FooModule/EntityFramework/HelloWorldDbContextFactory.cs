using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FooModule.EntityFramework
{
    public class HelloWorldDbContextFactory : IDesignTimeDbContextFactory<HelloWorldDbContext>
    {
        public HelloWorldDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false).Build();

            var builder = new DbContextOptionsBuilder<HelloWorldDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new HelloWorldDbContext(builder.Options);
        }
    }
}