angular.module('myApp.view1')
.directive('mainGraph', function() {
    return {
    restrict: 'E',
    transclude: true,
    controller: ['$scope', function MyTabsController($scope) {
        $scope.labels = ["Download Sales", "In-Store Sales", "Mail-Order Sales"];
        $scope.data = [300, 500, 100];
        $scope.datasetOverride =  [{ borderWidth: 0.5 }, { borderWidth: 1 },{borderWidth: 1}];
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