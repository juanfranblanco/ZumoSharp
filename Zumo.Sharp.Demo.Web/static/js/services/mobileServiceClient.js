angular.module("ZumoDemo").factory("mobileServiceClient", [function () {
    var MobileServiceClient = WindowsAzure.MobileServiceClient;
    var client = new MobileServiceClient('/', 'xQssHJsoVJ5zNjRWxZcdozMNrxzVvB32');
    return client;
}]);