angular.module('myApp.view1')
.directive('highlightFlags', function() {
    return {
    restrict: 'E',
    scope: {
      message: '='
    },
    transclude: true,
    controller: ['$scope', function FlagController($scope) {
        
    }],
    templateUrl: './highlight-flags/highlight-flags.html'
  };
});