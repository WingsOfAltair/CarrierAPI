using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CarrierAPI
{
    public class Package
    {
        [DataMember]
        public double Height { get; set; }

        [DataMember]
        public double Width { get; set; }

        [DataMember]
        public double Length { get; set; }

        [DataMember]
        public double Weight { get; set; }
    }
}