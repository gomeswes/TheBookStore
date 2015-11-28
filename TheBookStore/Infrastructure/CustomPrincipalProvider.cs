using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using TheBookStore.Contracts;

namespace TheBookStore.Infrastructure
{
    public class CustomPrincipalProvider : IPrincipalProvider
    {

        private const string Username = "fanier";
        private const string Password = "supersecretpassword";

        /// <summary>
        /// Receives the credencials and validates
        /// </summary>
        /// <param name="username">Username credential</param>
        /// <param name="password">Password credential</param>
        /// <returns>Returns null if the credentials were invalid</returns>
        public IPrincipal CreatePrincipal(string username, string password)
        {
            if (username != Username || password != Password)
            {
                return null;
            }

            var identity = new GenericIdentity(Username);
            IPrincipal principal = new GenericPrincipal(identity, new[] { "User" });
            return principal;
        }
    }
}