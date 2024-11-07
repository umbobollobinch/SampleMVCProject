using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
// definition for Cookie auths -----------------------
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
// ---------------------------------------------------

namespace Sample001.Services.Account
{
    public class AccountServices: IAccountServices
    {
        public async Task SignIn(string name, HttpContext httpContext)
        {
            var claims = new[] { new Claim(ClaimTypes.Name, name) };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(principal);
        }

        public async Task SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
