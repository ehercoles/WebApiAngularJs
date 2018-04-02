var BookstoreApp = angular.module('BookstoreApp', ['ngRoute', 'BookControllers']);
BookstoreApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/list',
        {
            templateUrl: 'Book/list.html',
            controller: 'ListController'
        }).
        when('/create',
        {
            templateUrl: 'Book/edit.html',
            controller: 'EditController'
        }).
        when('/edit/:id',
        {
            templateUrl: 'Book/edit.html',
            controller: 'EditController'
        }).
        when('/delete/:id',
        {
            templateUrl: 'Book/delete.html',
            controller: 'DeleteController'
        }).
        otherwise(
        {
            redirectTo: '/list'
        });
}]);
