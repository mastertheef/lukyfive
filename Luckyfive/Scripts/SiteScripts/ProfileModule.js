"use strict";
(function (Window, ko) {
    Window.App = Window.App || {};
    Window.App.ProfileModule = (function () {
        var viewModel = {
            City: ko.observable(''),
            Name: ko.observable(''),
            Phone: ko.observable(''),
            modelLoaded: ko.observable(false),
            loaded: ko.observable(false),
            regionsLoaded: ko.observable(false),
            countries: ko.observableArray([]),
            regions: ko.observableArray([]),
            selectedCountry: ko.observable(),
            selectedRegion: ko.observable(),
            selectedCity: ko.observable(),
            showRegionsSpinner: ko.observable(false)
        };

        viewModel.countrySelected = ko.computed(function () {
            return this.selectedCountry() !== undefined &&
                this.selectedCountry() !== null &&
                this.selectedCountry() !== '';
        }, viewModel);

        viewModel.regoinSelected = ko.computed(function () {
            return this.selectedRegion() !== undefined &&
                this.selectedRegion() !== null &&
                this.selectedRegion() !== '';
        }, viewModel);

        viewModel.onCountryChange = function () {
            viewModel.showRegionsSpinner(true);
            viewModel.regionsLoaded(false);
            Window.App.GeoDataModule.getRegions(viewModel.selectedCountry())
                .then(function (data) {
                    if (data && data.response && data.response.items) {
                        viewModel.regions(data.response.items);
                        viewModel.showRegionsSpinner(false);
                        viewModel.regionsLoaded(true);
                    }
                });

        };

        var loadData = function () {
            ko.applyBindings(viewModel);
            Window.App.GeoDataModule.getCountries()
                .then(function (data) {
                    if (data && data.response && data.response.items) {
                        viewModel.countries(data.response.items);

                    }

                    viewModel.loaded(true);
                });
        };

        return {
            loadData: loadData
        };
    })();
})(Window, ko);