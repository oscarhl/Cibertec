﻿(function () {
    'use strict';

    angular.module('app').config(routeconfig);

    routeconfig.$inject = ['$stateProvider','$urlRouterProvider']

    function routeconfig($stateProvider,$urlRouterProvider) {
        $stateProvider
            .state("home", {
                url: "/home",
                templateUrl:"app/home.html"
            })

            .state("login", {
                url: "/login",
                templateUrl: "app/public/login/index.html"
            })
            .state("product", {
                url: "/product",
                templateUrl: 'app/private/product/index.html'
            })
            .state("otherwise", {
                url: "/",
                templateUrl:"app/home.html"
            })
    }

})();
