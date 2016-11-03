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
            citiesLoaded: ko.observable(false),
            countries: ko.observableArray([]),
            regions: ko.observableArray([]),
            cities: ko.observableArray([]),
            selectedCountry: ko.observable(),
            selectedRegion: ko.observable(),
            selectedCity: ko.observable(),
            showRegionsSpinner: ko.observable(false),
            showCitiesSpinner: ko.observable(false),
            name: ko.observable(''),
            phone: ko.observable('')
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

        viewModel.onRegionChange = function () {
            viewModel.showCitiesSpinner(true);
            viewModel.citiesLoaded(false);
            Window.App.GeoDataModule.getCities(viewModel.selectedCountry(), viewModel.selectedRegion())
                .then(function (data) {
                    if (data && data.response && data.response.items) {
                        viewModel.cities(data.response.items);
                        viewModel.showCitiesSpinner(false);
                        viewModel.citiesLoaded(true);
                    }
                });
        };

        var loadData = function () {
            $('#phone').mask('+999 99 999 9999');
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