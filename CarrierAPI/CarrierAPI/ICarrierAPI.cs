using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace CarrierAPI
{
    [ServiceContract]
    public interface ICarrierAPI
    {
        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "PerformShipping",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string PerformShipping(int serviceUsed = -1, int serviceID = -1, double width = 0,
            double height = 0, double length = 0, double weight = 0);

        [OperationContract]
        [
            WebInvoke
            (
                Method = "POST",
                UriTemplate = "PerformShippingXML",
                RequestFormat = WebMessageFormat.Xml,
                ResponseFormat = WebMessageFormat.Xml,
                BodyStyle = WebMessageBodyStyle.WrappedRequest
            )
        ]
        string PerformShippingXML(int serviceUsed = -1, int serviceID = -1, double width = 0,
            double height = 0, double length = 0, double weight = 0);
    }
}
