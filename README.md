ZumoSharp
=========
You love Windows Azure Mobile Services but you wish:
* You could integrate your current web site with the Javascript, .Net, IOS and Android Azure Mobile Service Client and also integrate with Azure Mobile Services through the same authentication mechanism.
* Future proof the integration with WAMS server for your new website and / or mobile application by leveraging the client and authentication.

### What it does
Implementation of JWT (Json web token) and Authentication of Azure Mobile Services in .Net. Currently facebook is the only authentication provider implemented.

### What it will do
Implement other authentication providers, serious refactoring, migration to Asp.Net vNext .net Core

### What it won't do
Replace Azure  Mobile Services general capabilities for push notifications, api generation

## Warning
Please ensure you use HTTPS when exchanging tokens 

#### Azure mobile services
 + Source: https://github.com/Azure/azure-mobile-services
 + Documentation: http://azure.microsoft.com/en-us/documentation/services/mobile-services/

### Quick instructions setup of the demo project

In Zumo.Sharp.Demo  change the following configurations:

#### Web.Config / Server
| Key   |      Description     |
|----------|:-------------:|------:|
| ApplicationMasterKey |  This is your Azure Mobile Services Master Key |
| ApplicationKey |    This is your application key, used as well in the client   |
| FacebookAppId | Facebook app id, only used if you are authenticating here instead of WAMS |
| FacebookSecret | Facebook secret, only used if you are authenticating here instead of WAMS |
| JWTExpiryInMinutes | When do you want the token to expire,  only used if you are authenticating here instead of WAMS|

#### Client / Angularjs
#####  Zumo.Sharp.Demo.Web / static / js / init.js 
```
angular.module("ZumoDemo") 
     .config(function ($FBProvider) { 
          $FBProvider.setInitParams({ 
              appId: 'YourFacebookAppId' 
        }); 
    });  

```
##### Zumo.Sharp.Demo.Web / static / js / services / mobileServiceClient.js 
We have 2 mobile services clients (for demo purposes) one pointing to Azure and the other to the web api

```
angular.module("ZumoDemo").factory("mobileServiceClient", [function () {
    var MobileServiceClient = WindowsAzure.MobileServiceClient;
    var client = new WindowsAzure.MobileServiceClient(
    "https://musicaplaylist.azure-mobile.net/",
    "YourWAMSAPIKEY"
);
    return client;
}]);

angular.module("ZumoDemo").factory("mobileServiceClientWebApi", [function () {
	var MobileServiceClient = WindowsAzure.MobileServiceClient;
	var client = new WindowsAzure.MobileServiceClient(
    "/",
    "YourWAMSAPIKEY"
);
	return client;
}]);
```
### WAMS Api
Create an Api call in Azure Mobile Services call "demo" so we can and use this as get:
```
exports.get = function(request, response) {
    response.send(statusCodes.OK, [
	{
		CustomerId: "1",
		Name: "Azure Mobile Services connection"
	},
    {
		CustomerId: "2",
		Name: "Azure Mobile Services connection"
	}
    ]
);
};
```
### Quick overview
##### Zumo.Sharp.Demo.Web / Controllers / ZumoSharpDemoLoginController.cs 

To support Facebook authentication it inherits from the generic LoginController implemented in ZumoSharp / Zumo.Sharp.AspNet / Controllers / LoginController.cs to support facebook authentication.

#####  Zumo.Sharp.Demo.Web / Controllers / DemoController.cs 
Demo controller has the attribute **Zumo.Sharp.AspNet.ZumoAuthorisationFilter** to enable Zumo authorisation checks.
 
##TODO
* Refactoring
* Unit testing 
* IoC
* Logging
* User roles
* Other providers
