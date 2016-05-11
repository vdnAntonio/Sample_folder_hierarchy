(function() {
    'use strict';
    var app = angular.module('app', ['ngRoute']);

    app.config(function($routeProvider) {
        $routeProvider
            .otherwise({
                templateUrl: 'app/views/folder.html',
                controller: 'folderController'
            });

    });
})();