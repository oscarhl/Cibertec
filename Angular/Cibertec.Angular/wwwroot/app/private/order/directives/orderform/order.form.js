(function () {
    'use strict';
    angular.module('app')
        .directive('orderForm', orderForm);
    function orderForm() {
        return {
            restrict: 'E',
            scope: {
                order: '='
            },
            templateUrl: 'app/private/order/directives/orderform/order-form.html'
        };
    }
})();