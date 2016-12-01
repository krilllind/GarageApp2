(function () {
    var app = angular.module("garage_app", []);

    app.controller("garage_controller", function ($scope, $http) {
        $scope.Filters = {};
        $scope.Vehicles = {};
        $scope.Search;

        //$scope.$watch("filters", FilterOut, true);

        // Get all filters
        $http.get("/Garage/GetFilters/").success(function (data) {
            if (data != null || data != "undefined") {
                $scope.Filters = data;
            }
        });

        // On init load all Vehicles
        $http.get("/Garage/GetAllVehicles/").success(function (data) {
            if (data != null || data != "undefined") {
                $scope.Vehicles = data;
            }
        });

        // On reset button click
        $("#reset-all-filters").click(function () {
            var checked = $(this).prop("checked");

            angular.forEach($scope.Filters.VehicleTypes, function (val, key) {
                $scope.Filters.VehicleTypes[key] = checked;
            });

            angular.forEach($scope.Filters.VehicleColors, function (val, key) {
                $scope.Filters.VehicleColors[key] = checked;
            });

            angular.forEach($scope.Filters.FilterDates, function (val, key) {
                $scope.Filters.FilterDates[key] = false;
            });

            $("input:checkbox").not($(this)).prop("checked", checked);
            $scope.Filters.FilterDates["None"] = true;
            $scope.Filters.Date = "None";
            $("input#None").prop("checked", true);
        });
    });

    app.controller("add_vehicle", function ($scope, $http) {
        $scope.New = {};
        $scope.Data = {
            Owners: {},
            Types:  {},
            Colors: {}
        };

        $http.get("/Garage/GetAllOwners/").success(function (data) {
            if (data != null || data != "undefined") {
                $scope.Data.Owners = data;
            }
        });

        $http.get("/Garage/GetAllVehicleTypes/").success(function (data) {
            if (data != null || data != "undefined") {
                $scope.Data.Types = data;
            }
        })

        $scope.SubmitForm = function(e) {
            e.preventDefault();

            alert("Soft");

            $http.post().success(function (data) {
                
            })
            .error(function(data) {
                swal({
                    title: 'Error!',
                    text: 'That Vehicle is already in the garage',
                    type: 'error',
                    confirmButtonText: 'Continue'
                });
            });
        }
    });
}());