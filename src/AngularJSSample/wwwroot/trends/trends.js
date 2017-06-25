angular.module('myApp.view1')
.directive('trends', function() {
    return {
    restrict: 'E',
    transclude: true,
    controller: ['$scope', function TrendController($scope) {
    }],
    templateUrl: './trends/trends.html'
  };
});