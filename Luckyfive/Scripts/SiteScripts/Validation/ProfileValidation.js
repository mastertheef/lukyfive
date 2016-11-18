"use strict";
(function(Window) {
    Window.App = Window.App || {};
    Window.App.ProfileValidation = (function () {
        var makeRequired = function (field, message) {
            field.extend({
                required: {
                    params: true,
                    message: message
                }
            });
            return field;
        };

        var extend = function (model) {
            makeRequired(model.name, 'Name is required');
            makeRequired(model.phone, 'Phone is required');
            makeRequired(model.selectedCountry, 'Country is required');
            makeRequired(model.selectedRegion, 'Region is required');
            makeRequired(model.selectedCity, 'City is required');

            model.isValid = function() {
                return model.name.isValid() &&
                    model.phone.isValid() &&
                    model.selectedCountry.isValid() &&
                    model.selectedRegion.isValid() &&
                    model.selectedCity.isValid();
            }
        };

        return {
            Extend: extend
        };
    })();
})(Window)