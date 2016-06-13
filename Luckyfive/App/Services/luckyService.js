"use strict";
luckyModule.factory('luckyService', function ($http, $location) {
    return App.luckyService($http, $location);
});

(function (app) {
    var luckyService = function ($http, $location) {
        var self = this;

        self.getTopLyckyAds = function () {
            // return promisse;
        };

        return this;
    };
    app.luckyService = luckyService;
}(window.App));