"use strict";
(function(Window, ko) {
    Window.App = Window.App || {};

    Window.App.MyAdvertismentsModule = (function() {
        var viewModel = {
            myAdvs: ko.observableArray()
        };

        var loadAdvertisments = function () {
            return Window.App.LuckyService.GetMyAdvertisments().then(function (data) {
                viewModel.myAdvs(data);
            });
        };

        var init = function () {
            loadAdvertisments().then(ko.applyBindings.bind(null, viewModel));
        };

        return {
            init: init
        };
    })();
})(Window, ko);