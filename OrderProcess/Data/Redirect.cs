using System;
using Microsoft.AspNet.Identity.EntityFramework;
using OrderProcess.Data.Interface;

namespace OrderProcess.Data
{
    public class Redirect : IRedirect
    {

        /// <summary>
        /// Uses the role name that the user logged in with to redirect them to the correct page.
        /// </summary>
        /// <param name="role">Supplied from the AccountController. The role that the current user is.</param>
        /// <returns></returns>
        public string LoginRedirect(IdentityRole role)
        {
            string output = String.Empty;

            switch (role.Name)
            {
                case "Admin":
                    output = "/LogisticsAdministrator/Index";
                    break;
                case "ClerkRole":
                    output = "/Clerk/Index";
                    break;
                case "DeliveryDriverRole":
                    output = "/DeliveryDriver/Index";
                    break;
                case "ExternalRole":
                    output = "/ExternalUser/Index";
                    break;
                case "MetricsRole":
                    output = "/MetricsUser/Index";
                    break;
                case "StoreroomDriverRole":
                    output = "/StoreroomDriver/Index";
                    break;
                default:
                    output = "/Home";
                    break;
            }
            return output;
        }
    }
}