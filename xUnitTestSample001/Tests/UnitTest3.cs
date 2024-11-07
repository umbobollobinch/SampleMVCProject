using System;
using Xunit;
using Moq;
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
using System.Reflection;

namespace xUnitTestSample001.Tests
{
    public class UnitTest3 {
        public class PropertyCollection {
            public PropertyCollection(int a, string b, string c, bool d) {
                this.aaa = a;
                this.bbb = b;
                this.ccc = c;
                this.ddd = d;
            }

            [DisplayName("001")]
            public int aaa { get; set; }

            [DisplayName("002")]
            public string bbb { get; set; }

            [DisplayName("003")]
            public string ccc { get; set; }

            [DisplayName("004")]
            public bool ddd { get; set; }
        }

        [Fact]
        public void Test_Getproperty() { 
            PropertyCollection hako = new PropertyCollection(1, "b", "c", true);
            var propertyinfo = typeof(PropertyCollection).GetProperties();
            MemberInfo propertyinfo2 = typeof(PropertyCollection);
            //PropertyInfo propertyinfo3 = (PropertyInfo)propertyinfo2;
            foreach (var item in propertyinfo)
            {
                DisplayNameAttribute att = (DisplayNameAttribute)Attribute.GetCustomAttribute(item, typeof(DisplayNameAttribute));
                Console.WriteLine(att.DisplayName);
            }
            Attribute[] att2 = Attribute.GetCustomAttributes(propertyinfo2, typeof(DisplayNameAttribute));

            foreach (var item in att2)
            {
                DisplayNameAttribute dispatt = item as DisplayNameAttribute;
                string youki = dispatt.DisplayName;
            }

            //Console.WriteLine(att);
            // var att2 = att.Select();
            Assert.Equal(1, 1);
        }

        [Fact]
        public void Test_Contains() {
            string[] str = { "aaa", "ccc", "ddd"};

            Dictionary<string, string> dict = new Dictionary<string, string> { { "aaa","vvv"}, {"bbb","www" }, {"ccc", "xxx" }, { "ddd", "yyy"}, { "eee", "zzz"}};

            var result = dict.Where(x => str.Contains(x.Key)).ToList();
            
            Assert.Equal(1, 1);
        }
    }
}
