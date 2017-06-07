"use strict";
(function(Window, ko) {
    Window.App = Window.App || {};

    ko.validation.init({
        insertMessages: false
    });

    Window.App.LuckyValidation = (function() {
        var extend = function(model) {
            model.name.extend({
                required: {
                    params: true,
                    message: 'Name is required'
                },
                maxLength: {
                    params: 50,
                    message: 'Name Max length is 50 chars'
                }
            });
            model.description.extend({
                required: {
                    params: true,
                    message: 'Description is required'
                }
            });

            model.errors = ko.validation.group(model);
        };

        return {
            extend: extend
        };
    })();
})(Window, ko);