'use strict';
var app = angular.module('AdminApp', ['ngRoute', 'ngAnimate', 'LocalStorageModule', 'angular-loading-bar']);

var serviceBase = '/';

app.config(function ($routeProvider, $locationProvider) {
    console.log($routeProvider)
    $routeProvider.when("/admin", {
        controller: "homeController",
        templateUrl: "/appAdmin/views/home.html"
    });
    $routeProvider.when("/admin/category", {
        controller: "categoryController",
        templateUrl: "/appAdmin/views/category-list.html"
    });
    $routeProvider.otherwise({ redirectTo: "/admin" });
    $locationProvider.html5Mode(true);
});

app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();    
}]);

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
