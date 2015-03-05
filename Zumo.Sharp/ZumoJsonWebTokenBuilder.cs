using System;

namespace Zumo.Sharp.Authentication
{
	public enum ZumoAudience
	{
		Facebook,
		Google,
		Twitter,
		Live
	}

	//TODO: Refactor introduce interface
	//TODO: Remove static
	//TODO: Add unit tests

	public class ZumoJsonWebTokenBuilder
	{
		public static string GetUserId(ZumoAudience audience, dynamic credentials)
		{
			switch (audience)
			{
				case ZumoAudience.Facebook:
					return credentials.facebook.userId;
				default:
					throw new NotImplementedException();
			}
		}

		public static JsonWebToken CreateJsonWebToken(double expiryMinutes, ZumoAudience audience, dynamic credentials)
		{
			var userId = GetUserId(audience, credentials);
			var claims = CreateClaims(expiryMinutes, audience.ToString(), credentials.facebook.userId);
			var envelope = CreateEnvelope();
			return new JsonWebToken(claims, credentials, envelope, Configuration.GetApplicationMasterKey());
		}

		public static JsonWebToken.JsonWebTokenClaims CreateClaims(double expiryMinutes, string audience, string userId)
		{
			return new JsonWebToken.JsonWebTokenClaims(expiryMinutes, "urn:microsoft:windows-azure:zumo", audience, userId, 1, null, null);
		}

		public static JsonWebToken.JsonWebTokenEnvelope CreateEnvelope()
		{
			return new JsonWebToken.JsonWebTokenEnvelope("JWT", "HS256", 0);
		}
	}
}