using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CarrierAPI
{
    public class Shipping
    {
        internal enum ShippingServices
        {
            FedEx,
            UPS
        }

        internal enum ServiceTypes
        {
            FedExAIR,
            FedExGround,
            UPSExpress,
            UPS2DAY
        }

        [DataMember]
        internal static ServiceTypes serviceID;

        [DataMember]
        internal static ShippingServices ServiceType;
    }
}