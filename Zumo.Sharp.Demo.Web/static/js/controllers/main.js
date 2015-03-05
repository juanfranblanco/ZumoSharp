
angular.module('ZumoDemo').controller('mainCtrl', ['facebookLoginService', '$scope', '$rootScope', '$state', function (facebookLoginService, $scope, $state, $rootScope) {
    $scope.login = function () {
        facebookLoginService.login(function () {
            facebookLoginService.updateLoginFBStatus().then(function (data) { return facebookLoginService.loginApplication(data); }).then(function (data) { return facebookLoginService.updateApiFBMe(data); }).then(
                function() {
                    $rootScope.$apply();
                });
        });
    };

}]);