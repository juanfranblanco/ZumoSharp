
angular.module('ZumoDemo').controller('demoCtrl', ['$scope', 'mobileServiceClient', 'userService', '$rootScope', 'mobileServiceClientWebApi',
function ($scope, mobileServiceClient, userService, $rootScope, mobileServiceClientWebApi) {
	$scope.$watch('$userService.isLogged', function (newValue, oldValue) {
		if (newValue) {
			updateCustomers();
		}
	});

	if (userService.isLogged) {
		updateCustomers();
	}
    
	$scope.userService = userService;

	function updateCustomers() {

		mobileServiceClientWebApi.currentUser = mobileServiceClient.currentUser;

		mobileServiceClientWebApi.invokeApi("demo", {
			method: "get"
		}).done(function (results) {

			$scope.customersWebApi = results.result;
			$scope.$apply();

		}, function (err) {
			alert("Error: " + err);
		});

		mobileServiceClient.invokeApi("demo", {
			method: "get"
		}).done(function (results) {

			$scope.customers = results.result;
			$scope.$apply();

		}, function (err) {
			alert("Error: " + err);
		});
	}

}]);

