namespace FooModule.Authorization
{
    public static class MyPermissions
    {
        public const string GroupName = "CatStore";

        public static class Cats
        {
            public const string Default = GroupName + ".Cats";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}
