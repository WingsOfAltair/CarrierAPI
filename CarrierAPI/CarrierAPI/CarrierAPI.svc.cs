using CarrierAPI.LoggingService;
using Dependencies;
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Script.Serialization;

namespace CarrierAPI
{
    [ServiceBehavior(MaxItemsInObjectGraph = int.MaxValue)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CarrierAPI : ICarrierAPI
    {
        LoggingServiceClient loggingService = new LoggingServiceClient();
        Response response = new Response();
        public string PerformShipping(int serviceUsed = -1, int serviceID = -1, double width = 0,
            double height = 0, double length = 0, double weight = 0)
        {
            try
            {
                if (width <= 0)
                {
                    response.ResponseMessage = "Invalid package width.";
                    response.ResponseStatus = false;
                    return new JavaScriptSerializer().Serialize(response);
                }
                if (height <= 0)
                {
                    response.ResponseMessage = "Invalid package height.";
                    response.ResponseStatus = false;
                    return new JavaScriptSerializer().Serialize(response);
                }
                if (length <= 0)
                {
                    response.ResponseMessage = "Invalid package length.";
                    response.ResponseStatus = false;
                    return new JavaScriptSerializer().Serialize(response);
                }
                if (weight <= 0)
                {
                    response.ResponseMessage = "Invalid package weight.";
                    response.ResponseStatus = false;
                    return new JavaScriptSerializer().Serialize(response);
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
                            return new JavaScriptSerializer().Serialize(fedEx.ShipUsingFedEx(serviceID, package));

                        case Shipping.ShippingServices.UPS:
                            UPS ups = new UPS();
                            return new JavaScriptSerializer().Serialize(ups.ShipUsingUPS(serviceID, package));

                        default:
                            // Log bad response, that no such shipping service is defined in our API.
                            // Return bad response, that no such shipping service is defined in our API.
                            response.ResponseMessage = "No such shipping provider is defined in our API.";
                            response.ResponseStatus = false;
                            return new JavaScriptSerializer().Serialize(response);
                    }
                } else
                {
                    response.ResponseMessage = "No such shipping provider is defined in our API.";
                    response.ResponseStatus = false;
                    return new JavaScriptSerializer().Serialize(response);
                }
            } catch(Exception error)
            {
                // Log error into a text file or db.
                loggingService.LogFailure(String.Format("API failed to process your request. Error: {0}", error.Message));
                    response.ResponseMessage = String.Format("API failed to process your request. Error: {0}", error.Message);
                    response.ResponseStatus = false;
                    return new JavaScriptSerializer().Serialize(response);
            }
        }
    }
}
