"use strict";
(function(Window, ko) {
    Window.App = Window.App || {};
    Window.App.ProfileModule = (function() {
        var viewModel = {
            City: ko.observable(''),
            Name: ko.observable(''),
            Phone: ko.observable(''),
            modelLoaded: ko.observable(false),

            countries: ko.observableArray([]),




        };

        var loadData = function () {
            Window.App.GeoDataModule.getCountries()
                .then(function (data) {
                    if (data && data.response && data.response.items) {
                        viewModel.countries(data.response.items);
                    }

                    ko.applyBindings(viewModel);
                });
        };

        return {
            loadData: loadData
        };
    })();
})(Window, ko);