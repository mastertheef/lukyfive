"use strict"
//angular
//    .module('app.routes', ['ngRote'])
//    .config(function ($routeProvider) {
       
//    });
var appMainModule = angular.module('main',
    [
        'ngRoute',
//        'app.routes',
    ]);

appMainModule.controller("homeController", function ($scope) {
    $scope.luckyAppointments = [];
    $scope.testMessage = "Some test message";
});