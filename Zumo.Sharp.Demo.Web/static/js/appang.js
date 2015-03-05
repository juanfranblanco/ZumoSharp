/// <reference path="../client/MobileServices.Web-1.0.0.js" />
/// <reference path="../libs/angular/angular.js" />

'use strict';

angular.module('ZumoDemo').factory("authenticationService", ['facebookLoginService', 'userService', '$rootScope', '$q', 'mobileServiceClient', function (facebookLoginService, userService, $rootScope, $q, mobileServiceClient) {

    function login() {
        
    }

    function updateLoginStatus() {
        
        return facebookLoginService.updateLoginFBStatus().then(function(data) { return facebookLoginService.loginApplication(data); });
    
    }

    var authenticationService = {
        login: function(more) { login(more); },
        updateLoginStatus: function() { updateLoginStatus(); }
        
    };

    return authenticationService;

}]);

//configuring the module with the states (config only uses providers)
angular.module('ZumoDemo')
  .config(
    ['$stateProvider', '$urlRouterProvider', '$httpProvider', 
      function ($stateProvider, $urlRouterProvider, $httpProvider ) {
        
      	  $urlRouterProvider.otherwise("/");
			
          $stateProvider.state("app",
          {
              abstract: true,
              templateUrl: 'static/partials/maintop.html',
              controller: "mainCtrl",
          });
          
          $stateProvider.state("app.authenticated",
          {
              abstract: true,
              templateUrl: 'static/partials/authenticatedpage.html',
          });


          $stateProvider.state("app.authenticated.demo",
          {
              url: "/",
              templateUrl: 'static/partials/customers.html',
              controller: 'demoCtrl',
              resolve: {
                  getLoginStatus: ['facebookLoginService', function (facebookLoginService) {
                      return facebookLoginService.updateLoginFBStatus().then(function (data) { return facebookLoginService.loginApplication(data); }).then(function (data) { return facebookLoginService.updateApiFBMe(data); });
                  }]
              }
          });
      }
     ]);

 //run module
angular.module('ZumoDemo').run(
      ['$rootScope', '$state', '$stateParams', '$location', 'userService',
      function ($rootScope, $state, $stateParams, $location, userService  ) {
          $rootScope.$state = $state;
          $rootScope.$stateParams = $stateParams;
          $rootScope.$userService = userService;
          $rootScope.$location = $location;
          $rootScope.userService = userService;

 } ]);
