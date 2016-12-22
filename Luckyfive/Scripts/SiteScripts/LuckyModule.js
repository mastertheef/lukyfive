"use strict";
(function(Window, ko) {
    Window.App = Window.App || {};
    Window.App.LuckyModule = (function() {
        var viewModel = {
            name: ko.observable(''),
            description: ko.observable('')
        };

        

        var init = function () {
            Dropzone.options.autoProcessQueue = false;
            ko.applyBindings(viewModel);
        };

        return {
            init: init
        };
    })();
})(Window, ko);