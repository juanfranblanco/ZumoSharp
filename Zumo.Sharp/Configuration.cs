using System;
using System.Configuration;

namespace Zumo.Sharp.Authentication
{
    public class Configuration
    {

        /*
          <add key="ApplicationMasterKey" value=""/>
          <add key="FacebookAppId" value=""/>
          <add key="FacebookSecret" value=""/>
          <add key="ApplicationKey" value=""/>  
         */
        
        private const string ApplicationMasterKeySettingsName = "ApplicationMasterKey";
        
        private const string FacebookAppIdSettingsName = "FacebookAppId";
        
        private const string FacebookSecretSettingsName = "FacebookSecret";
        
        private const string ApplicationKeySetingsName = "ApplicationKey";

		private const string JWTExpiryInMinutesSettingsName = "JWTExpiryInMinutes";
        public static string GetApplicationMasterKey()
        {
            return ConfigurationManager.AppSettings[ApplicationMasterKeySettingsName];
        }

		public static int GetExpiryInMinutes()
		{
			return Int32.Parse(ConfigurationManager.AppSettings[JWTExpiryInMinutesSettingsName]);
			
		}

        public static string GetFacebookAppId()
        {
            return ConfigurationManager.AppSettings[FacebookAppIdSettingsName];
        }

        public static string GetFacebookSecret()
        {
            return ConfigurationManager.AppSettings[FacebookSecretSettingsName];
        }

        public static string GetApplicationKey()
        {
            return ConfigurationManager.AppSettings[ApplicationKeySetingsName];
        } 
    }
}
