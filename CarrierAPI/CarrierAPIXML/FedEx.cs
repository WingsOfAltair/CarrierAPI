using CarrierAPIXML.LoggingService;
using Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CarrierAPI
{
    internal class FedEx
    {
        LoggingServiceClient loggingService = new LoggingServiceClient();
        Response response;
        internal string ShipUsingFedEx(int serviceID = -1, Package package = null)
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
                            return String.Format("No such shipping service is defined in our API.");
                    }
                }
                else
                {
                    return String.Format("No such shipping service is defined in our API.");
                }
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                loggingService.LogFailure(String.Format("API failed to process your request. Error: {0}", error.Message));
                return String.Format("API failed to process your request. Error: {0}", error.Message);
            }
        }

        private string ShipUsingFedExGround(int serviceID, Package package)
        {
            try
            {
                // Make API call to FedEx Ground API with arguments from input.
                loggingService.LogSuccess(String.Format("Success [FedEx Ground], package with dimensions Weight: {0} kg, Height: {1}, Width: {2}, Length: {3} costs $100.", package.Weight, package.Height, package.Width, package.Length));
                return String.Format("Success, package with dimensions Weight: {0} kg, Height: {1}, Width: {2}, Length: {3} costs $100.", package.Weight, package.Height, package.Width, package.Length);
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                loggingService.LogFailure(String.Format("API failed to process your request. Error: {0}", error.Message));
                return String.Format("API failed to process your request. Error: {0}", error.Message);
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
                return String.Format("API failed to process your request. Error: {0}", error.Message);
            }
        }
    }
}