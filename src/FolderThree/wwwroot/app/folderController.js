(function () {
    'use strict';

    var controllerId = 'folderController';

    angular.module('app').controller(controllerId,
        ['$scope',
          '$http',
          '$location',
          'factory',
          folderController]);

    function folderController($scope, $http, $location, factory) {
        function loadRootFolder() {
            factory.getMock($location.$$path).success(function (data) {
                $scope.folders = data;
                // If the first launch of the application is to change the URL to the root directory
                if ($location.url() === '')
                    $location.path('/#' + $scope.folders.Path);
            }).error(function (error) {
                console.log('ERROR: ', error);
            });
        }

        // Call by click on the link
        $scope.update = function (name) {
            var currentPath = $location.$$path + '/' + name;
            factory.getMock(currentPath).success(function (data) {
                $scope.folders = data;
                $location.path(currentPath);;
            });
        }

        // Call when the controller is loaded
        loadRootFolder();
    }
})();
