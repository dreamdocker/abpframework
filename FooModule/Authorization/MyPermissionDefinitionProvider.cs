using FooModule.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace FooModule.Authorization
{
    public class MyPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var catGroup = context.AddGroup(MyPermissions.GroupName, L("Permission:CatStore"));

            var catManagement = catGroup.AddPermission(MyPermissions.Cats.Default, L("Permission:CatStore.Cats"));

            catManagement.AddChild(MyPermissions.Cats.Create, L("Permission:CatStore.Cats.Creeate"));
            catManagement.AddChild(MyPermissions.Cats.Edit, L("Permission:CatStore.Cats.Edit"));
            catManagement.AddChild(MyPermissions.Cats.Delete, L("Permission:CatStore.Cats.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<TestResource>(name);
        }
    }
}