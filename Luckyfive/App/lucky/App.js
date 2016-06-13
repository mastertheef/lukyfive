"use strict";
var luckyModule = angular.module('luckyModule', ['common']);
luckyModule.config(function ($routeProvider,
                             $locationProvider) {
    $routeProvider.when('/lucky', {
        templateUrl: '/App/lucky/Views/LuckyHome.html',
        controller: 'luckyHomeController'
    });
});