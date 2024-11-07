using System;
using Xunit;
using Moq;
using Sample001.DBContexts;
using Sample001.Models;
using Sample001.Controllers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Linq.Expressions;
using xUnitTestSample001.Mocks;

namespace xUnitTestSample001.Tests
{
    public class UnitTest1
    {
        // Whether to Move the expected page according to the input account information
        //AccountControllerが、アカウント情報によって正しいビューを返せるかを確かめたい、
        [Theory] // When you use "InlineData" atr(s).
        [InlineData("aaa", "123", "Home/SetUp")]
        [InlineData("aaa", "456", "LoginError")]
        [InlineData("aaa", null, "LoginError")]
        [InlineData(null, "456", "LoginError")]
        [InlineData(null, null, "LoginError")]
        public async Task CheckAccountController_ViewCheck(string usr, string pass, string state)
        {
            // ///// Mock /////////////////////////////////////////////////////
            var mockDbContext = UserAccountMock.SetMockContext();
            var mockAcs = new AccountServiceMock();
            // ----------------------------------------------------------------
            
            var ac = new AccountController(context: mockDbContext, acs: mockAcs);

            var viewResult = await ac.Login(usr, pass);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(viewResult);

            string expectedAction = GetExpectedRedirectName(redirectToActionResult);

            Assert.Equal(state, expectedAction);
        }

        private string GetExpectedRedirectName(RedirectToActionResult res) {
            string str = res.ControllerName == null ? res.ActionName : res.ControllerName + "/" + res.ActionName;

            return str;
        }
    }
}
