"use strict";
angular
    .module('app.routes', ['ngRote'])
    .config(function ($routeProvider) {
        when('/', {
            templatgeUrl: 'templates/home/home.html',
            controller: 'homeController'
        })
    });