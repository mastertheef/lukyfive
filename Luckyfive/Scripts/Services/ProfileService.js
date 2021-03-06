﻿define('Scripts/Services/profileService', ['jquery'], function ($) {
    "use strict";
    var profileService = function () {

        var getProfileSettings = function () {
            return $.ajax({
                method: 'POST',
                url: 'GetProfileSettings'
            });
        };

        var saveProfileSettings = function (data) {
            return $.ajax({
                method: 'POST',
                url: 'SaveProfileSettings',
                data: data,
                dataType: 'json'
            });
        };

        var changeEmail = function (newEmail) {
            return $.ajax({
                method: 'POST',
                url: 'ChangeEmail',
                data: { newEmail: newEmail },
                dataType: 'json'
            });
        };

        var changePassword = function (oldPass, newPass) {
            return $.ajax({
                method: 'POST',
                url: 'ChangePassword',
                data: { oldPassword: oldPass, newPassword: newPass },
                dataType: 'json'
            });
        };

        return {
            getProfileSettings: getProfileSettings,
            saveProfileSettings: saveProfileSettings,
            changeEmail: changeEmail,
            changePassword: changePassword
        }
    };
    return profileService();
});
