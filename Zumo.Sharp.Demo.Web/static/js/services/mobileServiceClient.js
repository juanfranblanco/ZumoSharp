angular.module("ZumoDemo").factory("mobileServiceClient", [function () {
    var MobileServiceClient = WindowsAzure.MobileServiceClient;
    var client = new WindowsAzure.MobileServiceClient(
    "https://yourazuremobile.azure-mobile.net/",
    "xQswHJXoVJIGYjQWoWxeozTIjTkEvB31"
);
    return client;
}]);


angular.module("ZumoDemo").factory("mobileServiceClientWebApi", [function () {
	var MobileServiceClient = WindowsAzure.MobileServiceClient;
	var client = new WindowsAzure.MobileServiceClient(
    "/",
    "xQswHJXoVJIGYjQWoWxeozTIjTkEvB31"
);
	return client;
}]);