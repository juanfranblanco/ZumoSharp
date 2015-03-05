angular.module("ZumoDemo").
    factory("facebookLoginService", ["$FB", 'userService', '$rootScope', '$q', 'mobileServiceClient', function ($FB, userService, $rootScope, $q, mobileServiceClient) {

        function updateApiFBMe(userService) {
            var deferred = $q.defer();

            $FB.api('/me', function (res) {
                userService.username = res.name;
                userService.facebookId = res.id;;
                deferred.resolve(userService);
            });

            return deferred.promise;
        }

        function updateLoginFBStatus() {
            var deferred = $q.defer();

            $FB.getLoginStatus(function (res) {
                if (res.status === 'connected') {
                    userService.isLogonFacebook = true;
                    userService.facebookAccessToken = res.authResponse.accessToken;
                    deferred.resolve(userService);
                } else {
                    userService.clearCurrentUser();
                    deferred.resolve(userService);
                }
            }
            );
            return deferred.promise;
        }

        function loginMobileServices(userService) {

            var deferred = $q.defer();
            if (userService.isLogonFacebook) {
                var client = mobileServiceClient;
                if (client.currentUser === null) {
                    client.login('facebook', { access_token: userService.facebookAccessToken }, null,
                        function (error) {
                            if (error) {
                                deferred.resolve(userService);
                            } else {
                                userService.isLogged = true;
                                userService.isLogonApplication = true;
                                deferred.resolve(userService);
                            }
                        });
                } else {
                    userService.isLogged = true;
                    userService.isLogonApplication = true;
                    deferred.resolve(userService);
                }
            } else {
                deferred.resolve(userService);
            }
            return deferred.promise;
        }


        function login(more) {
            $FB.login(function (res) {
                if (res.authResponse) {
                    more();
                }
            }, { scope: 'email' });
        }


        var facebookLoginService = {
            login: function (more) { login(more); },
            userService: userService,
            updateLoginFBStatus: function () { return updateLoginFBStatus(); },
            loginApplication: function (loginStatus) { return loginMobileServices(loginStatus); },
            updateApiFBMe: function (userService) { return updateApiFBMe(userService); }
        };

        return facebookLoginService;
    }]);

