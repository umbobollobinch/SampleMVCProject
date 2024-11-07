using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Sample001.DBContexts;

namespace Sample001.Services
{
    public class CovidServices: ICovidServices
    {
        public IBasicServices pbasicServices { get; }
        
        public CovidServices(IBasicServices basicservices) {
            pbasicServices = basicservices;
        }

        public async Task SetDatabase() {
            var setDbDict = pbasicServices.GetChidren("apis");

            foreach (var elem in setDbDict)
            {
                string place = elem.Key;

                var jsonString = await pbasicServices.GetJsonString(place);

                (_, Type placeModelTypeA) = pbasicServices.GetPlaceModel(place);
                // Only the type "dynamic" can pass compiling; the type of "cityofPatients" is defined when the variable is sent by an html page.
                dynamic patients = JsonSerializer.Deserialize(jsonString, placeModelTypeA);

                (string DBName, var dbContext, dynamic container) = SetUpDB(place);

                using (var tx = dbContext.Database.BeginTransaction())
                {
                    // ----- alternative solution - this is also ok, I don't like this very much...  ------------
                    string sqlCom = "truncate table " + DBName;
                    dbContext.Database.ExecuteSqlRaw(sqlCom);

                    foreach (var flist in patients)
                    {
                        container.Add(flist);
                    }

                    if (place == "Default")
                    {
                        // if a DB has key[s] but is not the name "ID", you don't have to exec "SET IDENTITY_INSERT"
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo." + DBName + " ON");
                        dbContext.SaveChanges();
                        dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo." + DBName + " OFF");
                    }
                    // -----------------------------------------------------------------------------
                    tx.Commit();
                }
            }
        }

        public async Task SetDatabase(string place)
        {
            var jsonString = await pbasicServices.GetJsonString(place);

            (_, Type placeModelTypeA) = pbasicServices.GetPlaceModel(place);
            // Only the type "dynamic" can pass compiling; the type of "cityofPatients" is defined when the variable is sent by an html page.
            dynamic patients = JsonSerializer.Deserialize(jsonString, placeModelTypeA);

            (string DBName, var dbContext, dynamic container) = SetUpDB(place);

            using (var tx = dbContext.Database.BeginTransaction())
            {
                // ----- alternative solution - this is also ok, I don't like this very much...  ------------
                string sqlCom = "truncate table " + DBName;
                dbContext.Database.ExecuteSqlRaw(sqlCom);

                foreach (var flist in patients)
                {
                    container.Add(flist);
                }

                if (place == "Default")
                {
                    // if a DB has key[s] but is not the name "ID", you don't have to exec "SET IDENTITY_INSERT"
                    dbContext.SaveChanges();
                }
                else
                {
                    dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo." + DBName + " ON");
                    dbContext.SaveChanges();
                    dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo." + DBName + " OFF");
                }
                // -----------------------------------------------------------------------------
                tx.Commit();
            }
        }

        public dynamic GetDatabase(string place)
        {
            dynamic container;

            try
            {
                (_, _, container) = SetUpDB(place);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }

            //dynamic tmpList = Activator.CreateInstance(placeModelType);
            var tmpList = new List<dynamic>();
            foreach (var item in container)
            {
                tmpList.Add(item);
            }

            return tmpList;
        }

        private (string dbn, SchoolDBContext dbc, dynamic c) SetUpDB(string place)
        {
            var dbc = pbasicServices.GetDBContext();
            string dbcn = pbasicServices.GetConfigName("DBNames:DbContext");
            string dbn = pbasicServices.GetConfigName("DBNames:" + place);

            // the object of c is got as expected, but methods in DbSet etc. does not function, why?
            // the measurement of avoiding the problem above.
            dynamic c = Type.GetType(dbcn)
                            .GetProperty(dbn)
                            .GetValue(dbc);

            return (dbn, dbc, c);
        }
    }
}
