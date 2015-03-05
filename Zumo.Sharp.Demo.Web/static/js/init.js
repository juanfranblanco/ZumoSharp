//configuring dependencies of the module
angular.module('ZumoDemo', ['ui.router', 'ezfb', 'ngSanitize', 'ui.bootstrap']);

angular.module("ZumoDemo")
    .config(function ($FBProvider) {
        $FBProvider.setInitParams({
        	appId: 'myFBAppId'
        });
    }); 