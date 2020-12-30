namespace FooModule.Authorization
{
    //[Dependency(ReplaceServices = true)]
    //public class FakeCurrentPrincipalAccessor : ThreadCurrentPrincipalAccessor
    //{
    //    protected override ClaimsPrincipal GetClaimsPrincipal()
    //    {
    //        List<Claim> claims = new List<Claim>
    //        {
    //            new Claim(AbpClaimTypes.UserId,"37d8e892-bfd8-8abf-2c0c-e45040978c79"),
    //            new Claim(AbpClaimTypes.UserName,"admin"),
    //            new Claim(AbpClaimTypes.Email,"admin@xcode.me"),
    //            new Claim(AbpClaimTypes.TenantId,"2a3e5584-5d2f-eb46-cbad-6758d4873878"),
    //            new Claim(AbpClaimTypes.ClientId,"2f04b138-f41c-17c3-fb0c-44165f48a68d"),
    //            new Claim(AbpClaimTypes.Role,"myrole")
    //        };

    //        return new ClaimsPrincipal(new ClaimsIdentity(claims));
    //    }
    //}
}