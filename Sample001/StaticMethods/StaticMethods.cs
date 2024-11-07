using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sample001.StaticMethods
{
    public static class StaticMethods
    {
        public static IEnumerable<object> GetDataForGraph(this IConfiguration cfg ,List<dynamic>model, string place = "Default")
            // where T: IPlaceModel
        {
            string dateType = cfg["DateType:" + place];

            IEnumerable<dynamic> result;
            if (place == "Default")
            {
                result = model
                        .Select(x => new { Date = DateTime.ParseExact(x.pubDate, dateType, null), Num = x.patientNum });
            }
            else
            {
                result = model
                         .GroupBy(x => x.pubDate)
                         .Select(x => new { Date = DateTime.ParseExact(x.Key, dateType, null), Num = x.Count() });
                            
            }

            result = result.OrderBy(x => x.Date)
                            .Select(x => new { Date = x.Date.ToString("d"), Num = x.Num });

            return result;
        }

        public static Dictionary<string, string> GetChidrenSectionDict(this IConfigurationSection parent) {
            var elems = parent.GetChildren();
            var dict = new Dictionary<string, string>();
            foreach (var elem in elems)
            {
                dict.Add(elem.Key, elem.Value);
            }
            return dict;
        }

        public static List<string> GetDisplayNames(dynamic model) {
            List<string> dlist = new();

            foreach (var propinfo in model.GetType().GetProperties())    
            {
                DisplayNameAttribute att = (DisplayNameAttribute)Attribute.GetCustomAttribute(propinfo, typeof(DisplayNameAttribute));
                dlist.Add(att.DisplayName);
            }

            return dlist;
        }

        public static List<string> GetPropertyNames(dynamic model)
        {
            List<string> plist = new();
            foreach (var propinfo in model.GetType().GetProperties())
            {
                plist.Add(propinfo.Name);
            }

            return plist;
        }

        public static List<string> GetJsonNames(dynamic model)
        {
            List<string> jlist = new();
            foreach (var propinfo in model.GetType().GetProperties())
            {
                JsonPropertyNameAttribute att2 = (JsonPropertyNameAttribute)Attribute.GetCustomAttribute(propinfo, typeof(JsonPropertyNameAttribute));
                jlist.Add(att2.Name);
            }

            return jlist;
        }

        public static List<List<string>> GetValues(dynamic model)
        {
            List<List<string>> vlist = new();
            foreach (var items in model)
            {
                List<string> column = new();
                foreach (var propinfo in items.GetType().GetProperties())
                {
                    column.Add(propinfo.GetValue(items).ToString());
                }

                vlist.Add(column);
            }

            return vlist;
        }
    }
}
