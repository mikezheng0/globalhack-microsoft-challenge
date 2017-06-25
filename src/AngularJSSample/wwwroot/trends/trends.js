angular.module('myApp.view1')
.directive('trends', function() {
    return {
    restrict: 'E',
    transclude: true,
    controller: ['$scope', function TrendController($scope) {
      $scope.angryPercentage = 50;
      $scope.happyPercentage = 20;
    }],
    templateUrl: './trends/trends.html'
  };
});