using Microsoft.AspNetCore.Http;
using Sample001.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTestSample001.Mocks
{
    class AccountServiceMock: IAccountServices
    {
        public async Task SignIn(string name = null, HttpContext httpContext = null)
        {
        }

        public async Task SignOut(HttpContext httpContext = null)
        {
        }
    }
}
