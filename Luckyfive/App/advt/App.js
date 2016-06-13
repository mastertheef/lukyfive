'use strict';
var advtModule = angular.module('advt', ['common']);
advtModule.config(function ($routeProvider, $locationProvider) { 
    $routeProvider.when('/advt', {
        templateUrl: '',
        controller: 'advtController'
    });
});