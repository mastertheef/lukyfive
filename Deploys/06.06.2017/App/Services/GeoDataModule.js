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

        var getRegions = function(countryId) {
            var url = 'http://api.vk.com/method/database.getRegions?v=5.5&need_all=1&offset=0&count=1000&country_id=' + countryId;
            return $.ajax({
                method: 'GET',
                dataType: 'jsonp',
                crossDomain: true,
                url: url,
                header: 'Accept-language: en\r\n"Cookie: remixlang=$lang\r\n"'
            });
        };

        var getCities = function(countryId, regionId) {
            var url = 'http://api.vk.com/method/database.getCities?v=5.5&country_id=' + countryId + '&region_id=' + regionId + '&offset=0&need_all=1&count=1000';
            return $.ajax({
                method: 'GET',
                dataType: 'jsonp',
                crossDomain: true,
                url: url,
                header: 'Accept-language: en\r\n"Cookie: remixlang=$lang\r\n"'
            });
        };

        return {
            getCountries: getCountries,
            getRegions: getRegions,
            getCities: getCities
        };
    })();
})(Window, jQuery);