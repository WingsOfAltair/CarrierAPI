using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CarrierAPI
{
    [DataContractAttribute]
    public class Response
    {
        bool ResponseValidity { get; set; }
        string ResponseText { get; set; }

        public Response(bool responseValidity, string responseText)
        {
            ResponseValidity = responseValidity;
            ResponseText = responseText;
        }
    }
}