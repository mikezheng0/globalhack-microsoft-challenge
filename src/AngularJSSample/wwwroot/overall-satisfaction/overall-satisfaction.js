angular.module('myApp.view1')
.directive('overallSatisfaction', function() {
    return {
    restrict: 'E',
    transclude: true,
    controller: ['$scope', function SatController($scope) {
        //$scope.labels = ["Download Sales", "In-Store Sales", "Mail-Order Sales"];
        $scope.percentage = 80;
        $scope.colors = ["#88a4db","#22222c"];
        $scope.data = [80, 20];
        $scope.options = {
            cutoutPercentage: 95,
            title: {
                display: true,
                text: ''
            },
            tooltips: {
                enabled:false
                
            }
        }
    }],
    templateUrl: './overall-satisfaction/overall-satisfaction.html'
  };
});