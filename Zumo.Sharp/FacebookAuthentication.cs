using System.Threading.Tasks;
using Facebook;

namespace Zumo.Sharp.Authentication
{
	public class FacebookAuthentication
	{
		private readonly string _appId;
		private readonly string _appSecret;

		public FacebookAuthentication(string appId, string appSecret)
		{
			_appId = appId;
			_appSecret = appSecret;
		}

		public async Task<string> GetExtendedAccessTokenAsync(string shortLivedToken)
		{
			var client = new FacebookClient();
			string extendedToken = "";

			dynamic result = await client.GetTaskAsync("/oauth/access_token", new
			{
				grant_type = "fb_exchange_token",
				client_id = _appId,
				client_secret = _appSecret,
				fb_exchange_token = shortLivedToken
			});
			extendedToken = result.access_token;

			return extendedToken;
		}

		public Task<dynamic> GetMeAsync(string accessToken)
		{
			var client = new FacebookClient(accessToken);
			return client.GetTaskAsync("me");
		}

		public async Task<dynamic> GetCredentialsFromAccessTokenAsync(string accessToken)
		{
			var extendedAccessToken = await GetExtendedAccessTokenAsync(accessToken);
			var me = await GetMeAsync(accessToken);
			return new
			{
				facebook = new
				{
					userId = "Facebook:" + me.id,
					accessToken = extendedAccessToken
				}
			};
		}

		public async Task<string> GetExtendedProviderTokenFromClientRequestAsync(string accessToken)
		{
			return await GetExtendedAccessTokenAsync(accessToken);
		}


	}
}
	
