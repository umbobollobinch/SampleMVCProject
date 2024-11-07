using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Sample001.DBContexts;

namespace Sample001.Services
{
    public interface IBasicServices //must be prepared
    {
        //Properties
        public SchoolDBContext bdbcontext { get; }
        public IHttpClientFactory bclientFactory { get; }
        public IConfiguration bconfiguration { get; }

        //Methods
        public Task<string> GetJsonString(string place);
        public (Type type, Type a_type) GetPlaceModel(string place);
        public SchoolDBContext GetDBContext();
        public string GetConfigName(string str);
        public Dictionary<string, string> GetChidren(string parentSec);
    }
}
