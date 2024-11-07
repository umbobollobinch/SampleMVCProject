using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample001.Services
{
    public interface ICovidServices
    {
        // Properties
        public IBasicServices pbasicServices { get; }
        
        // Methods
        Task SetDatabase();
        Task SetDatabase(string place);
        dynamic GetDatabase(string place);
    }
}