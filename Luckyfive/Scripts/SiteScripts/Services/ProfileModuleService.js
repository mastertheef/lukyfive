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

        return {
            GetProfileSettings: getProfileSettings
        };
    })();
})(Window);