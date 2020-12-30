using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace FooModule.DataAccess.MongoDB
{
    [ConnectionStringName("DogStore")]
    public class DogMongoDbContext : AbpMongoDbContext, IDogMongoDbContext
    {
        public IMongoCollection<Dog> Dogs => Collection<Dog>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            //modelBuilder.Entity<Dog>(b =>
            //{
            //    b.BsonMap.ConfigureAbpConventions();
            //    b.CollectionName = "AbpDogs";
            //});

            modelBuilder.ConfigureDogs(options =>
            {
                options.CollectionPrefix = "Abp";
            });
        }
    }
}
