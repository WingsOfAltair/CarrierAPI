using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LoggingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoggingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoggingService.svc or LoggingService.svc.cs at the Solution Explorer and start debugging.
    public class LoggingService : ILoggingService
    {
        public void LogFailure(string errorMessage)
        {
            string logPath = "error-log.txt";
            using (StreamWriter sw = File.AppendText(logPath))
            {
                sw.WriteLine(String.Format("Error Message: {0}. Date: {1}", errorMessage, DateTime.UtcNow));
            }
        }
    }
}
