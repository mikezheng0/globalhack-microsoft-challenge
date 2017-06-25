angular.module('myApp.view1')
.directive('smartFilter', function() {
    return {
    restrict: 'E',
    transclude: true,
    controller: ['$scope', function SmartFilterController($scope) {
        
    }],
    templateUrl: './smart-filter/smart-filter.html'
  };
});