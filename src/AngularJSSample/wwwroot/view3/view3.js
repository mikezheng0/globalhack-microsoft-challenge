'use strict';

angular.module('myApp.view3', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/view3', {
    templateUrl: 'view3/view3.html',
    controller: 'View3Ctrl'
  });
}])

    .controller('View3Ctrl', ['$scope', '$http', function ($scope, $http) {
        $scope.labels = ["4 Hours Ago", "8 Hours Ago", "12 Hours Ago", "16 Hours Ago", "20 Hours Ago"];
    $scope.series = ['Happy', 'Anger', 'Neutral'];
    $scope.data = [
        [],
        [],
        []
    ];
    $scope.onClick = function (points, evt) {
        console.log(points, evt);
    };
    $scope.datasetOverride = [{ yAxisID: 'y-axis-1' }, { yAxisID: 'y-axis-2' }];
    $scope.options = {
        legend: {
            display: true,
            position: 'right',
        },
        scales: {
            yAxes: [
                {
                    id: 'y-axis-1',
                    type: 'linear',
                    display: true,
                    position: 'left'
                },
                {
                    id: 'y-axis-2',
                    type: 'linear',
                    display: true,
                    position: 'right'
                }
            ]
        }
    };
    $http.get("/home/emotiontime/", {}).then(function (data) {
        if (data.status == 200) {
            for (var i=0; i < data.data.emotions.length; i++) {
                $scope.data[0].push(data.data.emotions[i].emotionCounts.happiness);
                $scope.data[1].push(data.data.emotions[i].emotionCounts.anger);
                $scope.data[2].push(data.data.emotions[i].emotionCounts.neutral);
            }
        }
    })

}]);