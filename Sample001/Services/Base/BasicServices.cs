using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Sample001.DBContexts;
using Sample001.StaticMethods;

namespace Sample001.Services
{
    public class BasicServices: IBasicServices
    {
        public SchoolDBContext bdbcontext { get; }
        public IHttpClientFactory bclientFactory { get; }
        public IConfiguration bconfiguration { get; }

        public BasicServices(SchoolDBContext context, IHttpClientFactory clientFactory, IConfiguration config)
        { // これをコンストラクタと呼ぶ
            bdbcontext = context;
            bclientFactory = clientFactory;
            bconfiguration = config;
        }

        public async Task<string> GetJsonString(string place) {
            var client = bclientFactory.CreateClient();
            var result = await client.GetAsync(GetConfigName("apis:" + place));
            var jsonString = await result.Content.ReadAsStringAsync();

            return jsonString;
        }

        public (Type type, Type a_type) GetPlaceModel(string place) {
            string modelName = GetConfigName("ModelName:" + place);
            Type type = Type.GetType(modelName);

            // change an type into an array type.
            var arrModel = Array.CreateInstance(type, 0);
            Type arrtype = arrModel.GetType();

            return (type, arrtype);
        }

        public SchoolDBContext GetDBContext() {
            return bdbcontext;
        }

        public string GetConfigName(string str) {
            return bconfiguration[str];
        }

        public Dictionary<string, string> GetChidren(string parentSec) {
            var dict = bconfiguration.GetSection(parentSec)
                                     .GetChidrenSectionDict();
            return dict;
        }

        /*private void tiko() {
            string[] str = new string[] { };
            var result = bdbcontext.FukuiResults.Select(x => {
                foreach (var item in x.GetType().GetProperties())
                {
                    if (!(str.Contains(item.Name))) {
                        item.SetValue(x, "");
                    }
                }
            });
        }*/
    }
}
