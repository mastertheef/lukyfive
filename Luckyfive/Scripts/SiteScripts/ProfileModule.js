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
            showSaveSpinner: ko.observable(false),
            name: ko.observable(''),
            phone: ko.observable(''),

            newEmail: ko.observable('')
        };

        Window.App.ProfileValidation.Extend(viewModel);

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
            viewModel.selectedRegion(undefined);
            viewModel.selectedCity(undefined);
            return Window.App.GeoDataModule.getRegions(viewModel.selectedCountry())
                .then(function (data) {
                    if (data && data.response && data.response.items) {
                        viewModel.regions(data.response.items);
                        viewModel.regionsLoaded(true);
                    }
                    viewModel.showRegionsSpinner(false);
                });

        };

        viewModel.onRegionChange = function () {
            viewModel.showCitiesSpinner(true);
            viewModel.citiesLoaded(false);
            viewModel.selectedCity(undefined);
            return Window.App.GeoDataModule.getCities(viewModel.selectedCountry(), viewModel.selectedRegion())
                .then(function (data) {
                    if (data && data.response && data.response.items) {
                        viewModel.cities(data.response.items);
                        viewModel.citiesLoaded(true);
                    }
                    viewModel.showCitiesSpinner(false);
                });
        };

        viewModel.onSaveButtonClick = function () {

            if (viewModel.isValid()) {
                var data = {
                    UserId: '',
                    CountryId: viewModel.selectedCountry(),
                    RegionId: viewModel.selectedRegion(),
                    CityId: viewModel.selectedCity(),
                    ContactName: viewModel.name(),
                    Phone: viewModel.phone()
                };
                viewModel.showSaveSpinner(true);
                Window.App.ProfileModuleService.SaveProfileSettings(data)
                    .then(function (result) {
                        viewModel.showSaveSpinner(false);
                    });
            }
        };

        viewModel.newEmail.isValidating.subscribe(function (isValidating) {
            if (!isValidating && viewModel.newEmail.isValid()) {
                Window.App.ProfileModuleService.ChangeEmail(viewModel.newEmail())
                    .then(function (result) {
                        console.log(result);
                    });
            }
        });

        viewModel.onChangeEmailClick = function () {
            viewModel.newEmail.isValidating(true);
        };

        var loadData = function () {
            $('#phone').mask('+999 99 999 9999');
            ko.applyBindings(viewModel);

            Window.App.GeoDataModule.getCountries()
            .then(function (data) {
                if (data && data.response && data.response.items) {
                    viewModel.countries(data.response.items);
                }
            })
            .then(function () {
                Window.App.ProfileModuleService.GetProfileSettings()
                    .then(function (result) {
                        if (result) {
                            viewModel.name(result.ContactName);
                            viewModel.phone(result.Phone);
                            viewModel.selectedCountry(result.CountryId);
                            viewModel.onCountryChange()
                                .then(function () {
                                    viewModel.selectedRegion(result.RegionId);
                                })
                                .then(viewModel.onRegionChange)
                            .then(function () {
                                viewModel.selectedCity(result.CityId);
                                viewModel.loaded(true);
                            });
                        }
                        else {
                            viewModel.loaded(true);
                        }
                    });
            });
        };

        return {
            loadData: loadData
        };
    })();
})(Window, ko);