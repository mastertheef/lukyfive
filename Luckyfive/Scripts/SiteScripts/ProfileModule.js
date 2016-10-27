"use strict";
(function(Window, ko) {
    Window.App = Window.App || {};
    Window.App.ProfileModule = (function() {
        var viewModel = {
            City: ko.observable(''),
            Name: ko.observable(''),
            Phone: ko.observable(''),
            modelLoaded: ko.observable(false)

        };
    })();
})(Window, ko);