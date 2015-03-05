using System;
using System.Security.Principal;
using Zumo.Sharp.Authentication;

namespace Zumo.Sharp
{
    public class ZumoIdentity : IIdentity
    {
             
        public ZumoIdentity(JsonWebToken jsonWebToken)
        {
            if (jsonWebToken == null) throw new ArgumentNullException("jsonWebToken");
            Initialise(jsonWebToken);
        }

        public string Name { get; private set; }

        public string UserId { get; private set; }
        public string AuthenticationType { get; private set; }
        public bool IsAuthenticated { get; private set; }

        public dynamic Credentials { get; private set; }

        private void Initialise(JsonWebToken jsonWebToken)
        {
            this.IsAuthenticated = true;
            this.AuthenticationType = jsonWebToken.Claims.Audience;
            this.Name = jsonWebToken.Claims.UserId;
            this.UserId = jsonWebToken.Claims.UserId;
            this.Credentials = jsonWebToken.Claims.Credentials;
        }
    }
}