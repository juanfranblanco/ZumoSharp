
angular.module('ZumoDemo').controller('demoCtrl', ['$scope', 'mobileServiceClient', 'userService', '$rootScope',
function ($scope, mobileServiceClient, userService, $rootScope) {
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

