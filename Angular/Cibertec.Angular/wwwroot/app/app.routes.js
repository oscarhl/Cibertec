(function () {
    'use strict';

    angular.module('app').config(routeconfig);

    routeconfig.$inject = ['$stateProvider','$urlRouterProvider']

    function routeconfig($stateProvider,$urlRouterProvider) {
        $stateProvider
            .state("home", {
                url: "/home",
                templateUrl:"app/home.html"
            })
            .state("otherwise", {
                url: "/",
                templateUrl:"app/home.html"
            })
    }

})();
