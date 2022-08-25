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
                            return new JavaScriptSerializer().Serialize(ShipUsingFedEx(serviceID, package));

                        case Shipping.ShippingServices.UPS:
                            return new JavaScriptSerializer().Serialize(ShipUsingUPS(serviceID, package));

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

        private Response ShipUsingFedEx(int serviceID = -1, Package package = null)
        {
            try
            {
                if (serviceID > -1)
                {
                    Shipping.ServiceTypes serviceTypeUsed = (Shipping.ServiceTypes)serviceID;

                    switch (serviceTypeUsed)
                    {
                        case Shipping.ServiceTypes.FedExAIR:
                            response.ResponseMessage = ShipUsingFedExAIR(serviceID, package);
                            response.ResponseStatus = true;
                            return response;

                        case Shipping.ServiceTypes.FedExGround:
                            response.ResponseMessage = ShipUsingFedExGround(serviceID, package);
                            response.ResponseStatus = true;
                            return response;

                        default:
                            // Log bad response, that no such shipping service is defined in our API.
                            // Return bad response, that no such shipping service is defined in our API.
                            response.ResponseMessage = String.Format("No such shipping service is defined in our API.");
                            response.ResponseStatus = false;
                            return response;
                    }
                }
                else
                {
                    response.ResponseMessage = String.Format("No such shipping service is defined in our API.");
                    response.ResponseStatus = false;
                    return response;
                }
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                loggingService.LogFailure(String.Format("API failed to process your request. Error: {0}", error.Message));
                response.ResponseMessage = String.Format("API failed to process your request. Error: {0}", error.Message);
                response.ResponseStatus = false;
                return response;
            }
        }

        private Response ShipUsingUPS(int serviceID = -1, Package package = null)
        {
            try
            {
                if (serviceID > 0)
                {
                    Shipping.ServiceTypes serviceTypeUsed = (Shipping.ServiceTypes)serviceID;

                    switch (serviceTypeUsed)
                    {
                        case Shipping.ServiceTypes.UPSExpress:
                            response.ResponseMessage = ShipUsingUPSExpress(serviceID, package);
                            response.ResponseStatus = true;
                            return response;

                        case Shipping.ServiceTypes.UPS2DAY:
                            response.ResponseMessage = ShipUsingUPS2DAY(serviceID, package);
                            response.ResponseStatus = true;
                            return response;

                        default:
                            // Log bad response, that no such shipping service is defined in our API.
                            // Return bad response, that no such shipping service is defined in our API.
                            response.ResponseMessage = String.Format("No such shipping service is defined in our API.");
                            response.ResponseStatus = false;
                            return response;
                    }
                }
                else
                {
                    response.ResponseMessage = String.Format("No such shipping service is defined in our API.");
                    response.ResponseStatus = false;
                    return response;
                }
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                loggingService.LogFailure(String.Format("API failed to process your request. Error: {0}", error.Message));
                response.ResponseMessage = String.Format("API failed to process your request. Error: {0}", error.Message);
                response.ResponseStatus = false;
                return response;
            }
        }

        private string ShipUsingFedExGround(int serviceID, Package package)
        {
            try
            {
                // Make API call to FedEx Ground API with arguments from input.
                loggingService.LogSuccess(String.Format("Success [FedEx Ground], package with dimensions Weight: {0} kg, Height: {1}, Width: {2}, Length: {3} costs $100.", package.Weight, package.Height, package.Width, package.Length));
                return String.Format("Success, package with dimensions Weight: {0} kg, Height: {1}, Width: {2}, Length: {3} costs $100.", package.Weight, package.Height, package.Width, package.Length);
            } catch(Exception error)
            {
                // Log error into a text file or db.
                loggingService.LogFailure(String.Format("API failed to process your request. Error: {0}", error.Message));
                response.ResponseMessage = String.Format("API failed to process your request. Error: {0}", error.Message);
                response.ResponseStatus = false;
                return new JavaScriptSerializer().Serialize(response);
            }
        }

        private string ShipUsingFedExAIR(int serviceID, Package package)
        {
            try
            {
                // Make API call to FedEx AIR API with arguments from input.
                loggingService.LogSuccess(String.Format("Success [FedEx AIR], package with dimensions Weight: {0} kg, Height: {1}, Width: {2}, Length: {3} costs $100.", package.Weight, package.Height, package.Width, package.Length));
                return String.Format("Success, package with dimensions Weight: {0} kg, Height: {1}, Width: {2}, Length: {3} costs $100.", package.Weight, package.Height, package.Width, package.Length);
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                loggingService.LogFailure(String.Format("API failed to process your request. Error: {0}", error.Message));
                response.ResponseMessage = String.Format("API failed to process your request. Error: {0}", error.Message);
                response.ResponseStatus = false;
                return new JavaScriptSerializer().Serialize(response);
            }
        }

        private string ShipUsingUPSExpress(int serviceID, Package package)
        {
            try
            {
                // Make API call to UPS Express API with arguments from input.
                loggingService.LogSuccess(String.Format("Success [UPS Express], package with dimensions Weight: {0} kg, Height: {1}, Width: {2}, Length: {3} costs $100.", package.Weight, package.Height, package.Width, package.Length));
                return String.Format("Success, package with dimensions Weight: {0} kg, Height: {1}, Width: {2}, Length: {3} costs $100.", package.Weight, package.Height, package.Width, package.Length);
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                loggingService.LogFailure(String.Format("API failed to process your request. Error: {0}", error.Message));
                response.ResponseMessage = String.Format("API failed to process your request. Error: {0}", error.Message);
                response.ResponseStatus = false;
                return new JavaScriptSerializer().Serialize(response);
            }
        }

        private string ShipUsingUPS2DAY(int serviceID, Package package)
        {
            try
            {
                // Make API call to UPS2DAY API with arguments from input.
                loggingService.LogSuccess(String.Format("Success [UPS 2DAY], package with dimensions Weight: {0} kg, Height: {1}, Width: {2}, Length: {3} costs $100.", package.Weight, package.Height, package.Width, package.Length));
                return String.Format("Success, package with dimensions Weight: {0} kg, Height: {1}, Width: {2}, Length: {3} costs $100.", package.Weight, package.Height, package.Width, package.Length);
            }
            catch (Exception error)
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
