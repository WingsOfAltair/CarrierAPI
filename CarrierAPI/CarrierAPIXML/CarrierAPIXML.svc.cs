using CarrierAPI;
using CarrierAPIXML.LoggingService;
using Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

namespace CarrierAPIXML
{
    [ServiceBehavior(MaxItemsInObjectGraph = int.MaxValue)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CarrierAPIXML : ICarrierAPIXML
    {
        LoggingServiceClient loggingService = new LoggingServiceClient();
        public string PerformShipping(int serviceUsed = -1, int serviceID = -1, double width = 0,
            double height = 0, double length = 0, double weight = 0)
        {
            try
            {
                if (width <= 0)
                {
                    return "Invalid package width.";
                }
                if (height <= 0)
                {
                    return "Invalid package height.";
                }
                if (length <= 0)
                {
                    return "Invalid package length.";
                }
                if (weight <= 0)
                {
                    return "Invalid package weight.";
                }

                Package package = new Package();
                package.Width = width;
                package.Height = height;
                package.Length = length;
                package.Weight = weight;

                if (serviceUsed > -1)
                {
                    Shipping.ShippingServices shippingServiceUsed = (Shipping.ShippingServices)serviceUsed;

                    switch (shippingServiceUsed)
                    {
                        case Shipping.ShippingServices.FedEx:
                            FedEx fedEx = new FedEx();
                            return fedEx.ShipUsingFedEx(serviceID, package);

                        case Shipping.ShippingServices.UPS:
                            UPS ups = new UPS();
                            return ups.ShipUsingUPS(serviceID, package);

                        default:
                            // Log bad response, that no such shipping service is defined in our API.
                            // Return bad response, that no such shipping service is defined in our API.
                            return "No such shipping provider is defined in our API.";
                    }
                }
                else
                {
                    return "No such shipping provider is defined in our API.";
                }
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                loggingService.LogFailure(String.Format("API failed to process your request. Error: {0}", error.Message));
                return String.Format("API failed to process your request. Error: {0}", error.Message);
            }
        }
    }
}
