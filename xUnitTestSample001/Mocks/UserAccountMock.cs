using Microsoft.EntityFrameworkCore;
using Moq;
using Sample001.DBContexts;
using Sample001.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTestSample001.Mocks
{
    class UserAccountMock
    {
        public static List<AccountModel> TestUA = new()
        {
            new AccountModel { User = "aaa", Pass = "123" },
            new AccountModel { User = "bbb", Pass = "456" }
        };

        public static AccountDBContext SetMockContext()
        {
            var DummyDB = TestUA.AsQueryable();

            var MockAccountModel = new Mock<DbSet<AccountModel>>();

            MockAccountModel.As<IQueryable<AccountModel>>().Setup(m => m.Provider).Returns(DummyDB.Provider);
            MockAccountModel.As<IQueryable<AccountModel>>().Setup(m => m.Expression).Returns(DummyDB.Expression);
            MockAccountModel.As<IQueryable<AccountModel>>().Setup(m => m.ElementType).Returns(DummyDB.ElementType);
            MockAccountModel.As<IQueryable<AccountModel>>().Setup(m => m.GetEnumerator()).Returns(DummyDB.GetEnumerator());

            var mockContext = new Mock<AccountDBContext>();
            mockContext.Setup((m) => m.AccountInfo).Returns(MockAccountModel.Object);

            var obj = mockContext.Object;
            return mockContext.Object;
        }
    }
}
