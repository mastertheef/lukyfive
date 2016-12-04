﻿"use strict";
(function(Window, ko) {
    Window.App = Window.App || {};
    ko.validation.init({
        insertMessages: false
    });

    Window.App.ProfileValidation = (function () {
        ko.validation.rules['emailUsed'] = {
            async: true,
            validator: function (val, parms, callback) {
                var defaults = {
                    url: '/Account/IsEmailUsed',
                    type: 'POST',
                    data: {email: val},
                    success: function (data) {
                        callback(data.result);
                    },
                    fail: function () {
                        callback(true);
                    }

                };

                var options = $.extend(defaults, parms);

                $.ajax(options);
            },
            message: 'This Email is used.'
        };

        ko.validation.registerExtenders();

        var makeRequired = function (field, message) {
            field.extend({
                required: {
                    params: true,
                }
            });
            field.validationMessage = ko.observable(message);
            return field;
        };

        var extend = function (model) {
            makeRequired(model.name, 'Name is required');
            makeRequired(model.phone, 'Phone is required');
            makeRequired(model.selectedCountry, 'Country is required');
            makeRequired(model.selectedRegion, 'Region is required');
            makeRequired(model.selectedCity, 'City is required');

            model.newEmail.extend({
                email: {
                    message: 'New Email should be a correct email',
                },
                emailUsed: false
            });

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
})(Window, ko)