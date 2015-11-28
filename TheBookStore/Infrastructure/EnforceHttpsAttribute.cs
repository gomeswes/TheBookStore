using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace TheBookStore.Infrastructure
{
    /// <summary>
    /// Attribute coded to enforce de use of the https protocol on requests.
    /// </summary>
    public class EnforceHttpsAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Verifies if the Request Uri scheme uses Https, if not, send a response message informing the need.
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    ReasonPhrase = "Https required!"
                };
            }
            else {
                base.OnAuthorization(actionContext);
            }
        }

    }
}