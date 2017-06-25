'use strict';

angular.module('myApp.view4', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/view4', {
    templateUrl: 'view4/view4.html',
    controller: 'View4Ctrl'
  });
}])

    .controller('View4Ctrl', ['$scope', 'WebcamService', '$http', function ($scope, WebcamService, $http) {
        $scope.webcam = WebcamService.webcam;
        //override function for be call when capture is finalized
        $scope.webcam.success = function (image, type) {
            $scope.photo = image;
            $scope.fotoContentType = type;
            $scope.showweb = false;
        };

 }]);