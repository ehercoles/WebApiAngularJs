var BookControllers = angular.module("BookControllers", []);
// this controller call the api method and display the list of books  
// in list.html  
BookControllers.controller("ListController", ['$scope', '$http',
    function ($scope, $http) {
        $http({
            method: 'GET',
            url: '/api/book'
        }).then(function (response) {
            $scope.books = response.data;
        });
    }
]);
// this controller call the api method and display the record of selected book  
// in delete.html and provide an option for delete  
BookControllers.controller("DeleteController", ['$scope', '$http', '$routeParams', '$location',
    function ($scope, $http, $routeParams, $location) {
        $scope.id = $routeParams.id;
        $http.get('/api/book/' + $routeParams.id).success(function (data) {
            $scope.name = data.Name;
            $scope.price = data.Price;
            $scope.active = data.IsActive;
        });
        $scope.delete = function () {
            $http.delete('/api/Book/' + $scope.id).success(function (data) {
                $location.path('/list');
            }).error(function (data) {
                $scope.error = "An error has occured while deleting book! " + data;
            });
        };
    }
]);
// this controller call the api method and display the record of selected book  
// in edit.html and provide an option for create and modify the book and save the book record  
BookControllers.controller("EditController", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {
        $scope.id = 0;
        $scope.save = function () {
            var obj = {
                BookId: $scope.BookId,
                Name: $scope.Name,
                Price: $scope.Price,
                IsActive: $scope.IsActive
            };
            if ($scope.id == 0) {
                $http.post('/api/Book/', obj).success(function (data) {
                    $location.path('/list');
                }).error(function (data) {
                    $scope.error = "An error has occured while adding book! " + data.ExceptionMessage;
                });
            }
            else {
                $http.put('/api/Book/', obj).success(function (data) {
                    $location.path('/list');
                }).error(function (data) {
                    console.log(data);
                    $scope.error = "An Error has occured while Saving customer! " + data.ExceptionMessage;
                });
            }
        }
        if ($routeParams.id) {
            $scope.id = $routeParams.id;
            $scope.title = "Edit Book";
            $http.get('/api/book/' + $routeParams.id).success(function (data) {
                BookId: $scope.BookId;
                Name: $scope.Name;
                Price: $scope.Price;
                IsActive: $scope.IsActive;
            });
        }
        else {
            $scope.title = "Create New Book";
        }
    }
]);
