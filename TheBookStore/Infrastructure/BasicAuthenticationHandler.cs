using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TheBookStore.Contracts;
using TheBookStore.Models;

namespace TheBookStore.Infrastructure
{
    public class BasicAuthenticationHandler : DelegatingHandler
    {
        private const string basicAuthResponseHeader = "WWW-Authenticate";
        private const string basicAuthResponseHeaderValue = "Basic";
        private readonly IPrincipalProvider principalProvider;

        public BasicAuthenticationHandler(IPrincipalProvider principalProvider)
        {
            this.principalProvider = principalProvider;
        }

        /// <summary>
        /// Extract the credencials values from the authentication header.
        /// </summary>
        /// <param name="authHeader">The parameters of the authorization http header.</param>
        /// <returns>A object of Credentials with the values filled. Null if the credential values were not found.</returns>
        private Credentials ParseAuthorizationHeader(string authHeader)
        {
            var credentials = Encoding.ASCII.GetString(Convert.FromBase64String(authHeader)).Split(':');
            
            if (CheckCredentialsInvalid(credentials))
            {
                return null;
            }

            return new Credentials
            {
                Username = credentials[0],
                Password = credentials[1]
            };
        }

        private bool CheckCredentialsInvalid(string[] credentials)
        {
            return credentials.Length != 2 ||
                string.IsNullOrWhiteSpace(credentials[0]) ||
                string.IsNullOrWhiteSpace(credentials[1]);
        }

        /// <summary>
        /// Get the authorization http header from the request validates and fills the principal credential.
        /// </summary>
        /// <param name="request">The request being made</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A http response massage informing if the authentication was sucessful or not.</returns>
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authValue = request.Headers.Authorization;

            if (authValue != null && !string.IsNullOrWhiteSpace(authValue.Parameter))
            {
                var parsedCredentials = ParseAuthorizationHeader(authValue.Parameter);
                if (parsedCredentials != null)
                {
                    request.GetRequestContext().Principal = 
                            principalProvider
                                .CreatePrincipal(parsedCredentials.Username, 
                                                    parsedCredentials.Password);
                }
            }

            return await base.SendAsync(request, cancellationToken)
                    .ContinueWith(task =>
                    {
                        var response = task.Result;
                        if(response.StatusCode == HttpStatusCode.Unauthorized
                            && !response.Headers.Contains(basicAuthResponseHeader))
                        {
                            response.Headers.Add(basicAuthResponseHeader, basicAuthResponseHeaderValue);
                        }

                        return response;
                    });
        }
    }
}