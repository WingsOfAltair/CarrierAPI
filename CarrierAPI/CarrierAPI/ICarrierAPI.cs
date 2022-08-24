using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarrierAPI
{
    [ServiceContract]
    public interface ICarrierAPI
    {
        [OperationContract]
        Response PerformShipping(int serviceUsed = -1, int serviceID = -1, double width = 0,
            double height = 0, double length = 0, double weight = 0);
    }
}
