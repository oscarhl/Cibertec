(function () {

    angular.module('app').factory('dataService', dataService);
    dataService.$inject = ['$http'];

    function dataService($http) {
        var service = {};
        service.getData = getData;
        service.postData = postData;
        service.putData = putData;
        service.deleteData = deleteData;

        return service;

        function getData() {
            return $http.get(url);
        }

        function postData() {
            return $http.post(url,data);
        }

        function putData() {
            return $http.put(url,data);
        }

        function deleteData() {
            return $http.delete(url,data);
        }
    }


})();