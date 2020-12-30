using Volo.Abp.Data;

namespace FooModule.DataAccess.EfCore
{
    public static class DogStoreDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "DogStore";
    }
}
