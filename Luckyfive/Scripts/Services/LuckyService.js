"use strict";
requirejs([],
    function () {
        var luckyService = (function () {
            var createLucky = function (data) {
                return $.ajax({
                    method: 'POST',
                    url: 'CreateLucky',
                    data: data
                });
            };

            var editLucky = function (data, photos) {
                return $.ajax({
                    method: 'POST',
                    url: '/Lucky/EditLucky',
                    data: { data: data, photos: photos }
                });
            };

            var getMyAdvertisments = function () {
                return $.ajax({
                    method: 'POST',
                    url: 'GetMyAdvertisments'
                });
            };

            var getAdvertismentById = function (id) {
                return $.ajax({
                    method: 'POST',
                    url: '/Lucky/GetAdvertismentById',
                    data: { id: id }
                });
            };

            var getAdvertismentPhotos = function (advId) {
                return $.ajax({
                    method: 'POST',
                    url: '/Lucky/GetAdvertismentPhotos',
                    data: { id: advId }
                });
            }

            return {
                CreateLucky: createLucky,
                EditLucky: editLucky,
                GetMyAdvertisments: getMyAdvertisments,
                GetAdvertismentById: getAdvertismentById,
                GetAdvertismentPhotos: getAdvertismentPhotos
            };
        })();

        return luckyService;
    });
