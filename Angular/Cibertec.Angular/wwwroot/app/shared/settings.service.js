(function () {
    'use strict';

    angular.module('app').factory('ConfigService', ConfigService)

    function ConfigService() {
        var service = {};

        var apiUrl = undefined;
        var isLogged = false;
        service.setLogin = setLogin;
        service.getLogin = getLogin;
        service.setApiUrl = setApiUrl;
        service.getApiUrl = getApiUrl;

        return service;

        function setLogin() {
            isLogged = state;
        }

        function getLogin() {
            return isLogged;
        }

        function getApiUrl() {
            return apiUrl;
        }

        function setApiUrl() {
            apiUrl = Url;
        }

        

    }

})();