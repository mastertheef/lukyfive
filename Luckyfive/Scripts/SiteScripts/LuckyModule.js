"use strict";
(function(Window, ko) {
    Window.App = Window.App || {};
    Window.App.LuckyModule = (function() {
        var viewModel = {
            name: ko.observable(''),
            description: ko.observable('')
        };


        var init = function () {
            Dropzone.options.dropzoneForm = {
                paramName: "files",
                acceptedFiles: "image/*",
                maxFiles: 10
               
            };
            ko.applyBindings(viewModel);
        };

        return {
            init: init
        };
    })();
})(Window, ko);