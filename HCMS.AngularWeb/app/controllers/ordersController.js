'use strict';
app.controller('ordersController', ['$scope', '$location', 'authService', 'ordersService', function ($scope, $location, authService, ordersService) {
    $scope.orders = [];
    //if (!authService.authentication.isAuth) {
    //    authService.authentication.referredUrl = $location.path();
    //    $location.path('/login');
    //}

    $scope.orders = [];

    ordersService.getOrders().then(function (results) {

        $scope.orders = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

   
}]);