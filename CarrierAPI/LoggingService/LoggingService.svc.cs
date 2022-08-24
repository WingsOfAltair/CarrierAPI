using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LoggingService
{
    public class LoggingService : ILoggingService
    {
        public void LogSuccess(string successMessage)
        {
            string logPath = "C:\\shipping-log.txt";
            using (StreamWriter sw = File.AppendText(logPath))
            {
                sw.WriteLine(String.Format("Shipping Started: {0}. Date: {1}", successMessage, DateTime.UtcNow));
            }
        }
        public void LogFailure(string errorMessage)
        {
            string logPath = "C:\\error-log.txt";
            using (StreamWriter sw = File.AppendText(logPath))
            {
                sw.WriteLine(String.Format("Error Message: {0}. Date: {1}", errorMessage, DateTime.UtcNow));
            }
        }
    }
}
