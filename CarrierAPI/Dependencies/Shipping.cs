using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Dependencies
{
    public class Shipping
    {
        public enum ShippingServices
        {
            FedEx,
            UPS
        }

        public enum ServiceTypes
        {
            FedExAIR,
            FedExGround,
            UPSExpress,
            UPS2DAY
        }

        [DataMember]
        public static ServiceTypes serviceID;

        [DataMember]
        public static ShippingServices ServiceType;
    }
}