"use strict";
(function(Window, ko) {
    Window.App = Window.App || {};
    Window.App.LuckyModule = (function() {
        var viewModel = {
            name: ko.observable(''),
            description: ko.observable(''),
            loading: ko.observable(false),
            success: ko.observable(false),
        };

        var isInEditMode = false;
        var photosArray = [];
        var advertismentId = 0;
        Window.App.LuckyValidation.extend(viewModel);

        var luckyService = Window.App.LuckyService;
        var myDropzone = {};

        var uploadFiles = function () {
            myDropzone.processQueue();
        };

        viewModel.onSaveButtonClick = function () {
            if (viewModel.errors().length === 0) {
                var data = {
                    Name: viewModel.name(),
                    Description: viewModel.description()
                };
                viewModel.loading(true);
                if (!isInEditMode) {
                    luckyService.CreateLucky(data)
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
                    data.id = advertismentId;
                    luckyService.EditLucky(data, photosArray)
                        .then(uploadFiles)
                        .then(function () {
                            viewModel.loading(false);
                            viewModel.success(true);
                        });
                }
            } else {
                viewModel.errors.showAllMessages();
            }
        };

        var applyPhotosToDropzone = function (photos) {
           
            for (var i = 0; i < photos.length; i++) {
                var photo = photos[i];
                var mockFile = {
                    id: photo.Id,
                    name: i + ".jpg",
                    size: 12345,
                    type: 'image/jpeg',
                    status: Dropzone.ADDED,
                    url: photo.Url
                };
                myDropzone.emit("addedfile", mockFile);

                myDropzone.createThumbnailFromUrl(mockFile, photo.Url, null, true);

                myDropzone.emit("complete", mockFile);
                myDropzone.files.push(mockFile);

                var existingFileCount = 1; 
                myDropzone.options.maxFiles = myDropzone.options.maxFiles - existingFileCount;

                photosArray.push({
                    id: photo.Id,
                    name: photo.Url.split('/').pop(),
                    shouldDelete: false
                });
            }
        };

        var init = function (id) {
            Dropzone.options.dropzoneForm = {
                addRemoveLinks: true,
                autoProcessQueue: false,
                uploadMultiple: true,
                paramName: "files",
                acceptedFiles: "image/*",
                maxFiles: 10,
                init: function () {
                    if (!id) {
                        this.on("complete",
                            function(file) {
                                this.removeFile(file);
                            });
                    } else {
                        isInEditMode = true;
                        advertismentId = id;
                        this.on("removedfile",
                            function(file) {
                                for (var i = 0; i < photosArray.length; i++) {
                                    if (photosArray[i].id === file.id) {
                                        photosArray[i].shouldDelete = true;
                                        break;
                                    }
                                }
                            });
                    }
                    myDropzone = this;
                }
            };
            
            if (id) {
                luckyService.GetAdvertismentById(id)
                    .then(function(result) {
                        if (result.success) {
                            viewModel.name(result.data.Name);
                            viewModel.description(result.data.Description);
                        }
                    })
                    .then(luckyService.GetAdvertismentPhotos.bind(this, id))
                    .then(function(data) {
                        
                        ko.applyBindings(viewModel);
                        applyPhotosToDropzone(data);
                    });
            } else {
                ko.applyBindings(viewModel);
            }
        };

        return {
            init: init
        };
    })();
})(Window, ko);