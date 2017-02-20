"use strict";
(function (Window) {
    Window.App = Window.App || {};
    Window.App.LuckyService = (function () {
        var createLucky = function (data) {
           return $.ajax({
                method: 'POST',
                url: 'CreateLucky',
                data: data
            });
        };

        return {
            CreateLucky: createLucky
        };
    })();
})(Window);