"use strict";
(function(Window, ko) {
    Window.App = Window.App || {};
    ko.validation.init({
        insertMessages: false
    });

    Window.App.ProfileValidation = (function () {
        var makeRequired = function (field, message) {
            field.extend({
                required: {
                    params: true
                }
            });
            field.validationMessage = ko.observable(message);
            return field;
        };

        ko.validation.rules['mustEqual'] = {
            validator: function (val, otherVal) {
                return val === otherVal;
            },
            message: 'Passwords must match'
        };

        ko.validation.registerExtenders();

        var extend = function (model) {
            makeRequired(model.name, 'Name is required');
            makeRequired(model.phone, 'Phone is required');
            makeRequired(model.selectedCountry, 'Country is required');
            makeRequired(model.selectedRegion, 'Region is required');
            makeRequired(model.selectedCity, 'City is required');

            makeRequired(model.password, 'Password is required');
            makeRequired(model.newPassword, 'New Password is required');
            makeRequired(model.confirmNewPassword, 'Confirm New Password is required');

            model.newPassword.extend({
                minLength: {
                    params: 6,
                    message: 'Password length must be equal or bigger than 6'
                },
            }),

            model.confirmNewPassword.extend({
                mustEqual: model.newPassword
            });

            model.newEmail.extend({
                email: {
                    message: 'New Email should be a correct email',
                }
            });

            model.isValid = function () {
                return model.name.isValid() &&
                    model.phone.isValid() &&
                    model.selectedCountry.isValid() &&
                    model.selectedRegion.isValid() &&
                    model.selectedCity.isValid();
            };

            model.isPasswordsValid = function () {
                return model.password.isValid() &&
                    model.newPassword.isValid() &&
                    model.confirmNewPassword.isValid()
            };
        };

        return {
            Extend: extend
        };
    })();
})(Window, ko)