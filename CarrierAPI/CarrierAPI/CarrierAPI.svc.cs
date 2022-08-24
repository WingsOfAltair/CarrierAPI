using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarrierAPI
{
    public class CarrierAPI : ICarrierAPI
    {
        public Response PerformShipping(int serviceUsed = -1, int serviceID = -1, double width = 0,
            double height = 0, double length = 0, double weight = 0)
        {
            try
            {
                if (serviceUsed > 0)
                {
                    Shipping.ShippingServices shippingServiceUsed = (Shipping.ShippingServices)serviceUsed;

                    switch (shippingServiceUsed)
                    {
                        case Shipping.ShippingServices.FedEx:
                            return new Response(true, ShipUsingFedEx(serviceID, width, height, length, weight));

                        case Shipping.ShippingServices.UPS:
                            return new Response(true, ShipUsingUPS(serviceID, width, height, length, weight));

                        default:
                            // Log bad response, that no such shipping service is defined in our API.
                            // Return bad response, that no such shipping service is defined in our API.
                            return new Response(false, "No such shipping provider is defined in our API.");
                    }
                } else
                {
                    return new Response(false, "No such shipping provider is defined in our API.");
                }
            } catch(Exception error)
            {
                // Log error into a text file or db.
                return new Response(false, "API failed to process your request.");
            }
        }

        private string ShipUsingFedEx(int serviceID = -1, double width = 0,
            double height = 0, double length = 0, double weight = 0)
        {
            try
            {
                if (serviceID > 0)
                {
                    Shipping.ServiceTypes serviceTypeUsed = (Shipping.ServiceTypes)serviceID;

                    switch (serviceTypeUsed)
                    {
                        case Shipping.ServiceTypes.FedExAIR:
                            return ShipUsingFedExAIR(serviceID, width, height, length, weight);

                        case Shipping.ServiceTypes.FedExGround:
                            return ShipUsingFedExGround(serviceID, width, height, length, weight);

                        default:
                            // Log bad response, that no such shipping service is defined in our API.
                            // Return bad response, that no such shipping service is defined in our API.
                            return "No such shipping service is defined in our API.";
                    }
                }
                else
                {
                    return "No such shipping service is defined in our API.";
                }
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                return "API failed to process your request.";
            }
        }

        private string ShipUsingUPS(int serviceID = -1, double width = 0,
            double height = 0, double length = 0, double weight = 0)
        {
            try
            {
                if (serviceID > 0)
                {
                    Shipping.ServiceTypes serviceTypeUsed = (Shipping.ServiceTypes)serviceID;

                    switch (serviceTypeUsed)
                    {
                        case Shipping.ServiceTypes.UPSExpress:
                            return ShipUsingUPSExpress(serviceID, width, height, length, weight);

                        case Shipping.ServiceTypes.UPS2DAY:
                            return ShipUsingUPS2DAY(serviceID, width, height, length, weight);

                        default:
                            // Log bad response, that no such shipping service is defined in our API.
                            // Return bad response, that no such shipping service is defined in our API.
                            return "No such shipping service is defined in our API.";
                    }
                }
                else
                {
                    return "No such shipping service is defined in our API.";
                }
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                return "API failed to process your request.";
            }
        }

        private string ShipUsingFedExGround(int serviceID, double width, double height, double length, double weight)
        {
            try
            {
                // Make API call to FedEx Ground API with arguments from input.
                return "Success";
            } catch(Exception error)
            {
                // Log error into a text file or db.
                return "Failed";
            }
        }

        private string ShipUsingFedExAIR(int serviceID, double width, double height, double length, double weight)
        {
            try
            {
                // Make API call to FedEx AIR API with arguments from input.
                return "Success";
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                return "Failed";
            }
        }

        private string ShipUsingUPSExpress(int serviceID, double width, double height, double length, double weight)
        {
            try
            {
                // Make API call to UPS Express API with arguments from input.
                return "Success";
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                return "Failed";
            }
        }

        private string ShipUsingUPS2DAY(int serviceID, double width, double height, double length, double weight)
        {
            try
            {
                // Make API call to UPS2DAY API with arguments from input.
                return "Success";
            }
            catch (Exception error)
            {
                // Log error into a text file or db.
                return "Failed";
            }
        }
    }
}
