using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace CarrierAPIXML
{
    [ServiceContract]
    public interface ICarrierAPIXML
    {
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "PerformShipping",
                RequestFormat = WebMessageFormat.Xml,
                ResponseFormat = WebMessageFormat.Xml,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string PerformShipping(int serviceUsed = -1, int serviceID = -1, double width = 0,
            double height = 0, double length = 0, double weight = 0);
    }
}
