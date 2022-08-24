using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LoggingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoggingService" in both code and config file together.
    [ServiceContract]
    public interface ILoggingService
    {
        [OperationContract]
        void LogSuccess(string successMessage);
        [OperationContract]
        void LogFailure(string errorMessage);
    }
}
