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
        function ThrowError() {
            $scope.ErrorMessage = "Something went wroooong!";

            swal({
                title: 'Error!',
                text: 'Something went wrong!',
                type: 'error',
                confirmButtonText: 'Continue'
            });
        }

        var SetOwners = function (response) {
            console.log(response);
            $scope.Data.Owners = response.data;
        }

        var SetVehicleTypes = function (response) {
            $scope.Data.VehicleTypes = response.data;
        }

        var SetVehicleColors = function (response) {
            $scope.Data.VehicleColors = response.data;
        }

        var AddedNewObj = function () {
            swal({
                title: 'Added!',
                text: 'New vehicle has been added!',
                type: 'success',
                confirmButtonText: 'Continue'
            });
        }

        $scope.New = {};
        $scope.Data = {};

        $http.get("/Garage/GetAllOwners/")
            .then(SetOwners, ThrowError);

        $http.get("/Garage/GetAllVehicleTypes/")
            .then(SetVehicleTypes, ThrowError);

        $http.get("/Garage/GetAllVehicleColors/")
            .then(SetVehicleColors, ThrowError);

        $scope.SubmitForm = function (newObj) {
            newObj.Vehicle_ID = newObj.Vehicle_ID.toUpperCase();
            $http.post("/Garage/AddVehicle/", {
                data: newObj
            }).then(AddedNewObj, ThrowError);
        }
    });
}());