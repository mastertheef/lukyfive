"use strict";
(function(Window) {
    Window.App = Window.App || {};
    Window.App.ProfileModuleService = (function() {
        var getProfileSettings = function() {
            return $.ajax({
                method: 'POST',
                url: 'GetProfileSettings'
            });
        };

        var saveProfileSettings = function(data) {
            return $.ajax({
                method: 'POST',
                url: 'SaveProfileSettings',
                data: data,
                dataType: 'json'
            });
        };

        return {
            GetProfileSettings: getProfileSettings,
            SaveProfileSettings: saveProfileSettings
        };
    })();
})(Window);