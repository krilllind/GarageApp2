(function () {
    var app = angular.module("garage_app", ['ngAnimate']);

    function ThrowError() {
        swal({
            title: 'Error!',
            text: 'Something went wrong!',
            type: 'error',
            confirmButtonText: 'Continue'
        });
    }

    app.controller("garage_controller", function ($scope, $http) {
        var RemoveObj = function (elId) {
            swal({
                title: 'Are you sure?',
                text: "After removing this vehicle from the garage you can't revert back!",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Remove'
            }).then(function () {
                $http.post("/Garage/DeleteVehicle/", {
                    data: elId
                }).success(function () {
                    swal({
                        title: 'Deleted!',
                        text: 'Your vehicle has been removed.',
                        type: 'success'
                    }).then(function () {
                        window.location.reload();
                    });
                }).error(ThrowError);
            });
        }

        var EditObj = function (elId) {
            window.location.href = "/Garage/Edit/" + elId;
        }

        var SetFilters = function (response) {
            $scope.Filters = response.data;
        }

        var SetVehicles = function(response) {
            $scope.Vehicles = response.data;
        }

        $scope.Filters = {};
        $scope.Vehicles = {};
        $scope.Search = "";
        $scope.RemoveObj = RemoveObj;
        $scope.EditObj = EditObj;

        $http.get("/Garage/GetFilters/")
            .then(SetFilters, ThrowError);

        $http.get("/Garage/GetAllVehicles/")
            .then(SetVehicles, ThrowError);

        //$scope.$watch("filters", FilterOut, true);

        //// On reset button click
        //$("#reset-all-filters").click(function () {
        //    var checked = $(this).prop("checked");

        //    angular.forEach($scope.Filters.VehicleTypes, function (val, key) {
        //        $scope.Filters.VehicleTypes[key] = checked;
        //    });

        //    angular.forEach($scope.Filters.VehicleColors, function (val, key) {
        //        $scope.Filters.VehicleColors[key] = checked;
        //    });

        //    angular.forEach($scope.Filters.FilterDates, function (val, key) {
        //        $scope.Filters.FilterDates[key] = false;
        //    });

        //    $("input:checkbox").not($(this)).prop("checked", checked);
        //    $scope.Filters.FilterDates["None"] = true;
        //    $scope.Filters.Date = "None";
        //    $("input#None").prop("checked", true);
        //});
    });

    app.controller("add_vehicle", function ($scope, $http) {
        var SetOwners = function (response) {
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
                timer: 2500,
                confirmButtonText: 'Continue'
            }).then(function () { },
                function (dismiss) {
                    if (dismiss === 'timer') {
                        window.location.href = window.location.pathname.substring(0, window.location.pathname.lastIndexOf('/') + 1);
                    }
                }
            );
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
            }).success(AddedNewObj).error(ThrowError);
        }
    });

    app.controller("garage_edit", function ($scope, $http) {
        var Vehicle_ID = window.location.pathname.split('/').slice(-1).pop();

        var SetVehicle = function (response) {
            $scope.Vehicles = response.data;
            console.log($scope.Vehicles);
        }

        var SetVehicleTypes = function (response) {
            $scope.Data.VehicleTypes = response.data;
        }

        var SetOwners = function (response) {
            $scope.Data.Owners = response.data;
        }

        var SetVehicleColors = function (response) {
            $scope.Data.VehicleColors = response.data;
        }

        var SubmitForm = function (Vehicles) {
            console.log(Vehicles);
        }

        $scope.Vehicles = {};
        $scope.Data = {};
        $scope.Updates = {};

        $http.get("/Garage/GetVehicle/", {
            params: {
                data: Vehicle_ID
            }
        }).then(SetVehicle, ThrowError);

        $http.get("/Garage/GetAllVehicleTypes/")
            .then(SetVehicleTypes, ThrowError);

        $http.get("/Garage/GetAllOwners/")
            .then(SetOwners, ThrowError);

        $http.get("/Garage/GetAllVehicleColors/")
            .then(SetVehicleColors, ThrowError);
    });
}());