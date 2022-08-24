using CarrierAPI.LoggingService;
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

namespace CarrierAPI
{
    [ServiceBehavior(MaxItemsInObjectGraph = int.MaxValue)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CarrierAPI : ICarrierAPI
    {
        LoggingServiceClient loggingService = new LoggingServiceClient();
        public string PerformShipping(int serviceUsed = -1, int serviceID = -1, double width = 0,
            double height = 0, double length = 0, double weight = 0)
        {
            try
            {
                if (width <= 0)
                {
                    return new JavaScriptSerializer().Serialize("Invalid package width.");
                }
                if (height <= 0)
                {
                    return new JavaScriptSerializer().Serialize("Invalid package height.");
                }
                if (length <= 0)
                {
                    return new JavaScriptSerializer().Serialize("Invalid package length.");
                }
                if (weight <= 0)
                {
                    return new JavaScriptSerializer().Serialize("Invalid package weight.");
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
                            return new JavaScriptSerializer().Serialize(ShipUsingFedEx(serviceID, package));

                        case Shipping.ShippingServices.UPS:
                            return new JavaScriptSerializer().Serialize(ShipUsingUPS(serviceID, package));

                        default:
                            // Log bad response, that no such shipping service is defined in our API.
                            // Return bad response, that no such shipping service is defined in our API.
                            return new JavaScriptSerializer().Serialize("No such shipping provider is defined in our API.");
                    }
                } else
                {
                    return new JavaScriptSerializer().Serialize("No such shipping provider is defined in our API.");
                }
            } catch(Exception error)
            {
                // Log error into a text file or db.
                loggingService.LogFailure(String.Format("API failed to process your request. Error: {0}", error.Message));
                return new JavaScriptSerializer().Serialize(String.Format("API failed to process your request. Error: {0}", error.Message));
            }
        }

        private string ShipUsingFedEx(int serviceID = -1, Package package = null)
        {
            try
            {
                if (serviceID > -1)
                {
                    Shipping.ServiceTypes serviceTypeUsed = (Shipping.ServiceTypes)serviceID;

                    switch (serviceTypeUsed)
                    {
                        case Shipping.ServiceTypes.FedExAIR:
                            return ShipUsingFedExAIR(serviceID, package);

                        case Shipping.ServiceTypes.FedExGround:
                            return ShipUsingFedExGround(serviceID, package);

                        default:
                            // Log bad response, that no such shipping service is defined in our API.
                            // Return bad response, that no such shipping service is defined in our API.
                            return new JavaScriptSerializer().Serialize(String.Format("No such shipping service is defined in our API."));
                    }
                }
                else
                {
                    return new JavaScriptSerializer().Serialize(String.Format("No such shipping service is defined in our API."));
                }
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                loggingService.LogFailure(String.Format("API failed to process your request. Error: {0}", error.Message));
                return new JavaScriptSerializer().Serialize(String.Format("API failed to process your request. Error: {0}", error.Message));
            }
        }

        private string ShipUsingUPS(int serviceID = -1, Package package = null)
        {
            try
            {
                if (serviceID > 0)
                {
                    Shipping.ServiceTypes serviceTypeUsed = (Shipping.ServiceTypes)serviceID;

                    switch (serviceTypeUsed)
                    {
                        case Shipping.ServiceTypes.UPSExpress:
                            return ShipUsingUPSExpress(serviceID, package);

                        case Shipping.ServiceTypes.UPS2DAY:
                            return ShipUsingUPS2DAY(serviceID, package);

                        default:
                            // Log bad response, that no such shipping service is defined in our API.
                            // Return bad response, that no such shipping service is defined in our API.
                            return new JavaScriptSerializer().Serialize(String.Format("No such shipping service is defined in our API."));
                    }
                }
                else
                {
                    return new JavaScriptSerializer().Serialize(String.Format("No such shipping service is defined in our API."));
                }
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                loggingService.LogFailure(String.Format("API failed to process your request. Error: {0}", error.Message));
                return new JavaScriptSerializer().Serialize(String.Format("API failed to process your request. Error: {0}", error.Message));
            }
        }

        private string ShipUsingFedExGround(int serviceID, Package package)
        {
            try
            {
                // Make API call to FedEx Ground API with arguments from input.
                return new JavaScriptSerializer().Serialize(String.Format("Success, package with dimensions Weight: {0} kg, Height: {1}, Width: {2}, Length: {3} costs $100.", package.Weight, package.Height, package.Width, package.Length));
            } catch(Exception error)
            {
                // Log error into a text file or db.
                loggingService.LogFailure(String.Format("API failed to process your request. Error: {0}", error.Message));
                return new JavaScriptSerializer().Serialize(String.Format("API failed to process your request. Error: {0}", error.Message));
            }
        }

        private string ShipUsingFedExAIR(int serviceID, Package package)
        {
            try
            {
                // Make API call to FedEx AIR API with arguments from input.
                return new JavaScriptSerializer().Serialize(String.Format("Success, package with dimensions Weight: {0} kg, Height: {1}, Width: {2}, Length: {3} costs $100.", package.Weight, package.Height, package.Width, package.Length));
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                loggingService.LogFailure(String.Format("API failed to process your request. Error: {0}", error.Message));
                return new JavaScriptSerializer().Serialize(String.Format("API failed to process your request. Error: {0}", error.Message));
            }
        }

        private string ShipUsingUPSExpress(int serviceID, Package package)
        {
            try
            {
                // Make API call to UPS Express API with arguments from input.
                return new JavaScriptSerializer().Serialize(String.Format("Success, package with dimensions Weight: {0} kg, Height: {1}, Width: {2}, Length: {3} costs $100.", package.Weight, package.Height, package.Width, package.Length));
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                loggingService.LogFailure(String.Format("API failed to process your request. Error: {0}", error.Message));
                return new JavaScriptSerializer().Serialize(String.Format("API failed to process your request. Error: {0}", error.Message));
            }
        }

        private string ShipUsingUPS2DAY(int serviceID, Package package)
        {
            try
            {
                // Make API call to UPS2DAY API with arguments from input.
                return new JavaScriptSerializer().Serialize(String.Format("Success, package with dimensions Weight: {0} kg, Height: {1}, Width: {2}, Length: {3} costs $100.", package.Weight, package.Height, package.Width, package.Length));
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                loggingService.LogFailure(String.Format("API failed to process your request. Error: {0}", error.Message));
                return new JavaScriptSerializer().Serialize(String.Format("API failed to process your request. Error: {0}", error.Message));
            }
        }
    }
}
