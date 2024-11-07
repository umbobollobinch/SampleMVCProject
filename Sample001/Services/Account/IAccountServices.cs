using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample001.Services.Account
{
    public interface IAccountServices
    {
        public Task SignIn(string name, HttpContext httpcontext);
        public Task SignOut(HttpContext httpContext);
    }
}
