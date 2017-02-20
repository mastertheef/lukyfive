"use strict";
(function(Window, ko) {
    Window.App = Window.App || {};
    Window.App.LuckyModule = (function() {
        var viewModel = {
            name: ko.observable(''),
            description: ko.observable(''),
            loading: ko.observable(false),
            success: ko.observable(false)
    };
        Window.App.LuckyValidation.extend(viewModel);

        var myDropzone = {};

        var uploadFiles = function () {
            // todo: show spinner, show confirm if no images, change spinner message
            myDropzone.processQueue();
        };

        viewModel.onSaveButtonClick = function () {
            if (viewModel.errors().length === 0) {
                var data = {
                    Name: viewModel.name(),
                    Description: viewModel.description()
                };
                viewModel.loading(true);
                Window.App.LuckyService.CreateLucky(data)
                    .then(uploadFiles)
                    .then(function() {
                        viewModel.loading(false);
                        viewModel.name('');
                        viewModel.description('');
                        viewModel.name.isModified(false);
                        viewModel.description.isModified(false);
                        myDropzone.removeAllFiles();
                        viewModel.success(true);
                    });
            } else {
                viewModel.errors.showAllMessages();
            }
        };

        var init = function () {
            Dropzone.options.dropzoneForm = {
                autoProcessQueue: false,
                uploadMultiple: true,
                paramName: "files",
                acceptedFiles: "image/*",
                maxFiles: 10,
                init: function () {
                    this.on("complete", function (file) {
                        this.removeFile(file);
                    });
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