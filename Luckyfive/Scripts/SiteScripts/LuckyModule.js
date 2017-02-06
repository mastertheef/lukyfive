"use strict";
(function(Window, ko) {
    Window.App = Window.App || {};
    Window.App.LuckyModule = (function() {
        var viewModel = {
            name: ko.observable(''),
            description: ko.observable('')
        };

        var myDropzone = {};

        var uploadFiles = function () {
            // todo: show spinner, show confirm if no images, change spinner message
            myDropzone.processQueue();
        };

        viewModel.onSaveButtonClick = function () {
            var data = {
                Name: viewModel.name(),
                Description: viewModel.description()
            };
            Window.App.LuckyService.CreateLucky(data)
                .then(uploadFiles);
        };

        var init = function () {
            Dropzone.options.dropzoneForm = {
                autoProcessQueue: false,
                uploadMultiple: true,
                paramName: "files",
                acceptedFiles: "image/*",
                maxFiles: 10,
                init: function () {
                    myDropzone = this;
                }
            };
            ko.applyBindings(viewModel);
        };

        return {
            init: init
        };
    })();
})(Window, ko);