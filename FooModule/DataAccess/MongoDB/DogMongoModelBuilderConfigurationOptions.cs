using Volo.Abp.MongoDB;

namespace FooModule.DataAccess.MongoDB
{
    public class DogMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public DogMongoModelBuilderConfigurationOptions() : base("Abp")
        {
        }
    }
}