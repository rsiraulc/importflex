using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ImportFlex.Account
{
    public static class HttpResponseBaseExtensions
    {
        public static int SetAuthCookie(this HttpResponse responseBase, string name, bool rememberMe, string userData, string fullname)
        {
            // In order to pickup the settings from config, we create a default cookie and use its values to create a 
            // new one.
            var cookie = FormsAuthentication.GetAuthCookie(name, rememberMe);
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, DateTime.Now, DateTime.Now.AddHours(3),
                ticket.IsPersistent, userData, ticket.CookiePath);
            var encTicket = FormsAuthentication.Encrypt(newTicket);
            // Use existing cookie. Could create new one but would have to copy settings over...
            cookie.Value = encTicket;
            responseBase.Cookies.Add(cookie);
            return encTicket.Length;
        }
    }
}