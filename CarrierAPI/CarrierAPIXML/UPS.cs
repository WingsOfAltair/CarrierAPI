using CarrierAPIXML.LoggingService;
using Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CarrierAPI
{
    internal class UPS
    {
        LoggingServiceClient loggingService = new LoggingServiceClient();
        Response response;

        internal string ShipUsingUPS(int serviceID = -1, Package package = null)
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
                return String.Format("API failed to process your request. Error: {0}", error.Message);
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
                return String.Format("API failed to process your request. Error: {0}", error.Message);
            }
        }
    }
}