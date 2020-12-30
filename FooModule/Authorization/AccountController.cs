using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Security.Claims;

namespace FooModule.Authorization
{
    public class AccountController : AbpController
    {
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View("~/Authorization/Login.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult> Login(string userName, string password, string returnUrl)
        {
            if (!string.Equals(userName, password, System.StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToAction(nameof(Login));
            }

            List<Claim> userClaims = new List<Claim>
            {
                new Claim(AbpClaimTypes.UserName, userName),
                new Claim(AbpClaimTypes.Email, $"{userName}@xcode.me")
            };

            if (string.Equals(userName, "user0"))
            {
                userClaims.Add(new Claim(AbpClaimTypes.UserId, "a7234ca4-2130-46dd-b77a-1d94412cbb00"));
                userClaims.Add(new Claim(AbpClaimTypes.ClientId, "myclient0"));
                userClaims.Add(new Claim(AbpClaimTypes.Role, "admin"));
            }

            if (string.Equals(userName, "user1"))
            {
                userClaims.Add(new Claim(AbpClaimTypes.UserId, "a7234ca4-2130-46dd-b77a-1d94412cbb01"));
                userClaims.Add(new Claim(AbpClaimTypes.ClientId, "myclient1"));
                userClaims.Add(new Claim(AbpClaimTypes.TenantId, "b1f14a2a-9539-6f03-5db5-0898ed7ae901"));
                userClaims.Add(new Claim(AbpClaimTypes.Role, "myrole1"));
            }

            if (string.Equals(userName, "user2"))
            {
                userClaims.Add(new Claim(AbpClaimTypes.UserId, "a7234ca4-2130-46dd-b77a-1d94412cbb02"));
                userClaims.Add(new Claim(AbpClaimTypes.ClientId, "myclient2"));
                userClaims.Add(new Claim(AbpClaimTypes.TenantId, "b1f14a2a-9539-6f03-5db5-0898ed7ae902"));
                userClaims.Add(new Claim(AbpClaimTypes.Role, "myrole2"));
            }

            if (string.Equals(userName, "user3"))
            {
                userClaims.Add(new Claim(AbpClaimTypes.UserId, "a7234ca4-2130-46dd-b77a-1d94412cbb03"));
                userClaims.Add(new Claim(AbpClaimTypes.ClientId, "myclient3"));
                userClaims.Add(new Claim(AbpClaimTypes.TenantId, "b1f14a2a-9539-6f03-5db5-0898ed7ae903"));
                userClaims.Add(new Claim(AbpClaimTypes.Role, "myrole1"));
                userClaims.Add(new Claim(AbpClaimTypes.Role, "myrole2"));
                userClaims.Add(new Claim(AbpClaimTypes.Role, "myrole3"));
            }

            if (string.Equals(userName, "user4"))
            {
                userClaims.Add(new Claim(AbpClaimTypes.UserId, "a7234ca4-2130-46dd-b77a-1d94412cbb04"));
                userClaims.Add(new Claim(AbpClaimTypes.TenantId, "b1f14a2a-9539-6f03-5db5-0898ed7ae904"));
                userClaims.Add(new Claim(AbpClaimTypes.ClientId, "myclient4"));
                userClaims.Add(new Claim(AbpClaimTypes.Role, "myrole4"));
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            identity.AddClaims(userClaims);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties() { IsPersistent = true };

            await HttpContext.SignInAsync(principal, properties);

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied() => Content(nameof(AccessDenied));
    }
}