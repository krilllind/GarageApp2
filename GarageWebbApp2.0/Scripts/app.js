var app = angular.module("garage_app", []);

app.controller("garage_controller", function ($scope, $http) {
    $scope.vehicles = [];
    $scope.filters = {};

    // Filter out selections on checkbox check
    $scope.$watch("filters", function (data) {
        $http.get("/Garage/ListVehicles/", {
            params: { filter: $scope.filters }
        }).success(function (data) {
            if (data != null || data != "undefined") {
                $scope.vehicles = data;
            }
        });
    }, true);

    // Get all filters
    $http.get("/Garage/GetFilters/").success(function (data) {
        if (data != null || data != "undefined") {
            $scope.filters = data;
        }
    });

    // On init load all vehicles
    $http.get("/Garage/ListVehicles/", {
        params: { filter: $scope.filters }
    }).success(function (data) {
        if (data != null || data != "undefined") {
            $scope.vehicles = data;
        }
    });
});