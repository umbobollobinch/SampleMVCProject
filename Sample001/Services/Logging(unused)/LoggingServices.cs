using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample001.Services.Logging
{
    public class LoggingServices: ILoggingServices
    {
        private readonly ILogger<LoggingServices> sLogger;

        public LoggingServices(ILogger<LoggingServices> logger) {
            sLogger = logger;
        }

        // Methods
        public void SetLogMessage(string? lLev, int? code, string? msg) {
            switch (lLev) 
            {
                case "Trace":
                    msg ??= "This is a trace log for confirmation.";
                    sLogger.LogTrace(msg);
                    break;
                case "Debug":
                    msg ??= "This is a debug log for confirmation.";
                    sLogger.LogDebug(msg);
                    break;
                case "Information":
                    msg ??= "This is an information log for confirmation.";
                    sLogger.LogInformation(msg);
                    break;
                case "Warning":
                    msg ??= "This is a warning log for confirmation.";
                    sLogger.LogWarning(msg);
                    break;
                case "Error":
                    msg ??= "This is an error log for confirmation.";
                    sLogger.LogError(msg);
                    break;
                case "Critical":
                    msg ??= "This is a critical log for confirmation.";
                    sLogger.LogCritical(msg);
                    break;
            }
        }
    }
}
