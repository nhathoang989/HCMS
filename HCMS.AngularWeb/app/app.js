'use strict';
var app = angular.module('AngularAuthApp', ['ngRoute', 'ngAnimate', 'LocalStorageModule', 'angular-loading-bar', 'angulike']);

var serviceBase = '/';//"http://localhost:9000/";//
app.config(function ($routeProvider, $locationProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

    $routeProvider.when("/orders", {
        controller: "ordersController",
        templateUrl: "/app/views/orders.html"
    });

    $routeProvider.when("/refresh", {
        controller: "refreshController",
        templateUrl: "/app/views/refresh.html"
    });

    $routeProvider.when("/tokens", {
        controller: "tokensManagerController",
        templateUrl: "/app/views/tokens.html"
    });

    $routeProvider.when("/associate", {
        controller: "associateController",
        templateUrl: "/app/views/associate.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });
    $locationProvider.html5Mode(true);
});

app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp',
    facebookAppId: '464285300363325'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

app.run([
      '$rootScope', function ($rootScope) {
          $rootScope.facebookAppId = '464285300363325'; // set your facebook app id here
          //console.log(app.scope());        
      }
]);

app.animation('.view', function () {
        return {
            enter: function (element, done) {                
                TweenLite.from(element[0], 1, {
                    opacity: 0,
                    onComplete: done
                });
            },
            leave: function (element, done) {
                //TweenLite.set(element[0], {
                //    position: 'absolute',
                //    top: 0
                //});
                TweenLite.to(element[0], 0.2, {
                    opacity: 0,
                    onComplete: done
                });
            }
        }
});
