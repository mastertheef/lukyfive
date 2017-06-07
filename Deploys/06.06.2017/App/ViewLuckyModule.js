"use strict";
(function(Window, ko) {
    Window.App = Window.App || {};
    Window.App.ViewLuckyModule = (function() {
        var viewModel = {
            loading: ko.observable(false),
            name: ko.observable(''),
            description: ko.observable(''),
            mainPhoto: ko.observable(''),
            photoes: ko.observableArray([]),
            endDate: ko.observable(''),
            daysLeft: ko.observable
        };

        var init = function(id) {
            Window.App.LuckyService.GetAdvertismentById(id)
                .then(function(result) {
                    if (result.success) {
                        viewModel.name(result.data.Name);
                        viewModel.description(result.data.Description);
                        viewModel.endDate(result.data.EndDate);
                        viewModel.daysLeft(result.data.DaysLeft);
                    }
                })
                .then(Window.App.LuckyService.GetAdvertismentPhotos.bind(this, id))
                .then(function(result) {
                    for (var i = 0; i < result; i++) {
                        if (result[i].First) {
                            viewModel.mainPhoto(result[i].Url);
                        }
                        viewModel.photoes.push(result[i].Url);
                    }
                    ko.applyBindings(viewModel);
                });
        };

        return {
            init: init
        };
    })();
})(Window, ko);