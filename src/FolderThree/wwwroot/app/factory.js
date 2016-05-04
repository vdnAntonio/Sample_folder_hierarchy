(function () {
    'use strict';

    var serviceId = 'factory';

    angular.module('app').factory(serviceId,
        ['$http', factory]);

    function factory($http) {

        function getMock(path) {
           return $http({
                method: 'POST',
                url: '/api/folder/',
                data: {Path: path}
            });
        }

        var service = {
            getMock: getMock
        };

        return service;
    }
})();
