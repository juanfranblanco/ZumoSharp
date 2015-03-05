using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Zumo.Sharp.Authentication;

namespace Zumo.Sharp.AspNet.Handlers
{
    public class ZumoAuthenticationTokenRequestInspector
    {
        public const string ZUMO_AUTH = "X-ZUMO-AUTH";

        public ZumoIdentity ExtractIdentity(HttpRequestMessage request)
        {
            ZumoIdentity identity = null;

            var accessToken = GetAccessToken(request);

            if (accessToken != null)
            {
                var jsonWebToken = CreateJsonWebToken(accessToken);

                if (jsonWebToken != null)
                {
                    identity = new ZumoIdentity(jsonWebToken);
                }
            }

            return identity;
        }

        private static string GetAccessToken(HttpRequestMessage request)
        {
            IEnumerable<string> accessToken = new List<string>();

            var found = request.Headers.TryGetValues(ZUMO_AUTH, out accessToken);
            if (!found) return null;
            return accessToken.FirstOrDefault();

        }

        private static JsonWebToken CreateJsonWebToken(string accessToken)
        {
            JsonWebToken jsonWebToken = null;
            try
            {
                //TODO.. JsonWebToken.Create 
                jsonWebToken = new JsonWebToken(accessToken, Configuration.GetApplicationMasterKey());
				if (jsonWebToken.IsExpired) jsonWebToken = null;
            }
            catch
            {
                //TODO:pokemon need a logger and good exceptions
            }
            return jsonWebToken;
        }
    }
}
