'use strict';

angular.module('myApp.view1', ['ngRoute','chart.js'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/view1', {
    templateUrl: 'view1/view1.html',
    controller: 'View1Ctrl'
  });
}])

    .controller('View1Ctrl', ['$scope', 'WebcamService', '$http', function ($scope, WebcamService, $http) {

        $scope.labels = [];
        $scope.data = [];
        $scope.webcam = WebcamService.webcam;
        //override function for be call when capture is finalized
        $scope.webcam.success = function(image, type) {
          $scope.photo = image;
          $scope.fotoContentType = type;
          $scope.showweb = false;
        };

        $http.get("/home/todayinteractions").then(function (data) {
            if (data.status == 200) {
                var total = 0;
                for (var key in data.data) {
                    $scope.labels.push(key);
                    $scope.data.push(data.data[key]);
                    total += data.data[key];
                }
                $scope.angryPercentage = data.data.anger / total * 100;
                $scope.happyPercentage = data.data.happiness / total * 100;
            }   
        })
}]);