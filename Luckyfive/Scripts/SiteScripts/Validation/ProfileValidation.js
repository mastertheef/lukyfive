"use strict";
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
                        console.log(data);
                        callback(!data.result);
                    }
                };

                var options = $.extend(defaults, parms);

                $.ajax(options);
            },
            message: 'This email is already in use'
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
            makeRequired(model.newEmail, 'Email is required');

            model.newEmail.extend({
                email: {
                    params: true,
                    message: 'New Email should be a correct email'
                },
                emailUsed: true
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