using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace FooModule.DataAccess.MongoDB
{
    public static class DogMongoDbContextExtensions
    {
        public static void ConfigureDogs(this IMongoModelBuilder modelBuilder, Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(modelBuilder, nameof(modelBuilder));

            var options = new DogMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            modelBuilder.Entity<Dog>(b =>
            {
                b.BsonMap.ConfigureAbpConventions();
                b.CollectionName = options.CollectionPrefix + "Dogs";
            });
        }
    }
}