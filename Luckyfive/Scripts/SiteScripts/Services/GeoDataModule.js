"use strict";
(function (Window, $) {
    Window.App = Window.App || {};
    Window.App.GeoDataModule = (function () {
        var getCountries = function () {
            return $.ajax({
                method: 'GET',
                dataType: 'jsonp',
                crossDomain: true,
                url: 'http://api.vk.com/method/database.getCountries?v=5.5&need_all=1&count=1000',
                header: 'Accept-language: en\r\n"Cookie: remixlang=$lang\r\n"'
            });
        };

        return {
            getCountries: getCountries
        };
    })();
})(Window, jQuery);