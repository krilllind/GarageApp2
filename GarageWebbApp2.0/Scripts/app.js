var app = angular.module("garage_app", []);

app.controller("garage_controller", function ($scope, $http) {
    $scope.vehicles = [];
    $scope.filters = {};

    // Filter out selections on checkbox check
    $scope.$watch("filters", FilterOut, true);

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

    // On reset button click
    $("#reset-all-filters").click(function () {
        var checked = $(this).prop("checked");

        angular.forEach($scope.filters.VehicleTypes, function (val, key) {
            $scope.filters.VehicleTypes[key] = checked;
        });

        angular.forEach($scope.filters.VehicleColors, function (val, key) {
            $scope.filters.VehicleColors[key] = checked;
        });

        $("input:radio").find("#None").prop("checked", true);
        $("input:checkbox").not($(this)).prop("checked", checked);
        FilterOut();
    });

    function FilterOut() {
        $http.get("/Garage/ListVehicles/", {
            params: { filter: $scope.filters }
        }).success(function (data) {
            if (data != null || data != "undefined") {
                $scope.vehicles = data;
            }
        });
    }
});