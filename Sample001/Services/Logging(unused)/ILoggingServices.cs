using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample001.Services.Logging
{
    public interface ILoggingServices
    {
        // Properties

        // Methods
        public void SetLogMessage(string? lLev, int? code, string? msg);
    }
}
