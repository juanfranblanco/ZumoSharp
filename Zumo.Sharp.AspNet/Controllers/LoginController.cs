using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Zumo.Sharp.Authentication;

namespace Zumo.Sharp.AspNet.Controllers
{
    [RoutePrefix("login")]
    public class LoginController : ApiController
    {
        [Route("facebook")]
        public async Task<dynamic> LoginFacebook(JObject requestData)
        {
            //{"user":{"userId":"Facebook:xxx"},"authenticationToken":"xxxx"}
            if (requestData["access_token"] != null)
            {
                var token = requestData["access_token"].Value<string>();
                var facebookAuhenticator = new FacebookAuthentication(Authentication.Configuration.GetFacebookAppId(), Authentication.Configuration.GetFacebookSecret());
                var credentials = await facebookAuhenticator.GetCredentialsFromAccessTokenAsync(token);
                var jsonWebtoken = ZumoJsonWebTokenBuilder.CreateJsonWebToken(GetExpirationInMinutes(), ZumoAudience.Facebook, credentials);
                return new { user = new { userId = jsonWebtoken.Claims.UserId }, authenticationToken = jsonWebtoken.GetToken() };

            }

            return null;
        }

		public double GetExpirationInMinutes()
		{
			var expirationBuilder = new ExpirationBuilder();
			return expirationBuilder.GetExpirationDateUnix(Authentication.Configuration.GetExpiryInMinutes());
        }
    }
}
