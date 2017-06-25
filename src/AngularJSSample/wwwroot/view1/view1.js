'use strict';

angular.module('myApp.view1', ['ngRoute','chart.js'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/view1', {
    templateUrl: 'view1/view1.html',
    controller: 'View1Ctrl'
  });
}])

.controller('View1Ctrl', ['$scope', 'WebcamService',function($scope, WebcamService) {
    $scope.webcam = WebcamService.webcam;
    //override function for be call when capture is finalized
    $scope.webcam.success = function(image, type) {
      $scope.photo = image;
      $scope.fotoContentType = type;
      $scope.showweb = false;
    };
}]);