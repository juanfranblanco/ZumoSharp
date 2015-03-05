namespace Zumo.Sharp.Authentication
{
    public class ZumoJsonWebTokenBuilder
    {
        public static JsonWebToken CreateJsonWebToken(double expiryMinutes, string audience, dynamic credentials)
        {
            //audience provider enum, credentials to use enum to get userId
            var claims = CreateClaims(expiryMinutes, audience, credentials.facebook.userId);
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