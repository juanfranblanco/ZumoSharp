angular.module("ZumoDemo")
           .factory("userService", [function () {
               var sdo = {
                   isLogged: false,

                   clearCurrentUser: function () {
                       this.isLogged = false;
                       this.isLogonFacebook = false;
                       this.isLogonApplication = false;
                       this.facebookAccessToken = false;
                       this.username = '';
                       this.facebookId = '';
                   },

                   isLogonApplication: false,
                   isLogonFacebook: false,
                   facebookAccessToken: '',
                   username: '',
                   facebookId: ''
               };

               return sdo;
           }]);








