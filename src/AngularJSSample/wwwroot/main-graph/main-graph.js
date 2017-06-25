angular.module('myApp.view1')
.directive('mainGraph', function() {
    return {
    restrict: 'E',
    transclude: true,
    controller: ['$scope','$http', function MyTabsController($scope,$http) {
        $scope.options = {
            cutoutPercentage: 70,
            legend: {
                display: true,
                position: 'top',
            },
            title: {
                display: true,
                text: ''
            }
        }
        
    }],
    templateUrl: './main-graph/main-graph.html'
  };
});