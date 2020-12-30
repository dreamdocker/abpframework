namespace FooModule.Authorization
{
    //[Dependency(ReplaceServices = true)]
    //public class MyPermissionStore : IPermissionStore, ISingletonDependency
    //{
    //    private static List<Tuple<string, string, string>> acls = new List<Tuple<string, string, string>>()
    //    {
    //       new Tuple<string, string, string>(MyPermissions.Cats.Default,UserPermissionValueProvider.ProviderName,"userid1"),
    //       new Tuple<string, string, string>(MyPermissions.Cats.Default,UserPermissionValueProvider.ProviderName,"userid2"),
    //       new Tuple<string, string, string>(MyPermissions.Cats.Default,UserPermissionValueProvider.ProviderName,"userid3"),
    //       new Tuple<string, string, string>(MyPermissions.Cats.Default,UserPermissionValueProvider.ProviderName,"userid4"),

    //       new Tuple<string, string, string>(MyPermissions.Cats.Create,RolePermissionValueProvider.ProviderName,"myrole1"),

    //       new Tuple<string, string, string>(MyPermissions.Cats.Edit,RolePermissionValueProvider.ProviderName,"myrole2"),

    //       new Tuple<string, string, string>(MyPermissions.Cats.Delete,ClientPermissionValueProvider.ProviderName,"myclient3"),

    //       new Tuple<string, string, string>(MyPermissions.Cats.Create,TenantPermissionValueProvider.ProviderName,"643ce51d-3624-4c4e-8aa4-543057942604")
    //    };

    //    public async Task<bool> IsGrantedAsync(string name, string providerName, string providerKey)
    //    {
    //        await Task.CompletedTask;

    //        return acls.Any(ac => ac.Item1 == name && ac.Item2 == providerName && ac.Item3 == providerKey);
    //    }
    //}
}