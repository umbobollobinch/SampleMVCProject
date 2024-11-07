using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Sample001.DBContexts;
using Sample001.Services.Account;
// definition for Cookie auths -----------------------
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
// ---------------------------------------------------

namespace Sample001.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private AccountDBContext _adbcontext;
        private IAccountServices _acs;

        public AccountController(AccountDBContext context, IAccountServices acs) // constructor; initialization method
        {
            _adbcontext = context;
            _acs = acs;
        }

        // ////////////////////////////////////////////////////////////////////////////////////////
        // ///// Actions //////////////////////////////////////////////////////////////////////////
        // ----------------------------------------------------------------------------------------
        [HttpGet]
        //public IActionResult Login(string returnUrl = null)
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string passWord) 
        {
            return await UserCheck(userName, passWord);
        }

        public IActionResult LoginError()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _acs.SignOut(HttpContext);
            return View();
        }
        // ----------------------------------------------------------------------------------------

        // ////////////////////////////////////////////////////////////////////////////////////////
        // ///// Methods for AcountController /////////////////////////////////////////////////////
        // ----------------------------------------------------------------------------------------
        private async Task<RedirectToActionResult> UserCheck(string name, string pass) {
            var UserAccounts = _adbcontext.AccountInfo.ToDictionary(x => x.User, x => x.Pass);
            if (name is null || 
                pass is null || 
                UserAccounts.TryGetValue(name, out string getPass) == false || 
                pass != getPass)
            {
                return RedirectToAction("LoginError");
            }
            else
            {
                await _acs.SignIn(name, HttpContext);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
