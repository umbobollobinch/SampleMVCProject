using System;
using Xunit;
using Moq;
using Sample001;
using Sample001.Models;
using Sample001.Models.Prefs;
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
using System.ComponentModel;

namespace xUnitTestSample001.Tests
{
    public class UnitTest2
    {
        [Fact]
        public void test_makeType() {
            string pref = "Fukui";
            pref = "Sample001.Models.Prefs." + pref + "Model, Sample001";

            Type type = Type.GetType(pref);

            Assert.Equal(typeof(FukuiModel), type);
        }
    }
}
