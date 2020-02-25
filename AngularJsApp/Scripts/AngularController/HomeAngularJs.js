var app = angular.module("HomeApp", []);

app.controller("HomeController", function ($scope, $http) {
    //setting the button text to save
    $scope.btntext = "Save";

    // Creating data
    $scope.savedata = function () {
        $scope.btntext = "Please Wait..";
        $http({
            method: 'POST',
            url: '/Home/Add_record',
            data: $scope.registration
        }).then(function successCallback(response) {
            
            $scope.btntext = "Save";
            $scope.registration = null;
            alert(response.data);
        }, function errorCallback () {
            alert('Failed');
        });
    };

    // Get the data and display it in a coloumn
    $http.get("/Home/Get_data").then(function (response) {

        $scope.record = response.data;
    }, function (error) {
            alert("failed");
    });

    //To update to get the initial view 
    $scope.loadrecord = function (Id) {

        $http.get("/Home/Get_dataById?Id=" + Id).then(function (response) {

            $scope.registration = response.data;
        }, function (error) {
                alert("Failed");
        });
    };


    // delete record.
    $scope.deleterecord = function (Id) {

        $http.get("/Home/Delete_record?Id=" + Id).then(function (response) {

            alert(response.data);

            $http.get("/Home/Get_data").then(function (response) {

                $scope.record = response.data;
            }, function (error) {
                alert("failed");
            });

        }, function (error) {
            alert("Failed");
        });
    };

    // after loading the data , change and update
    $scope.updatedata = function () {
        $scope.btntext = "Please Wait..";
        $http({
            method: 'POST',
            url: '/Home/Update_record',
            data: $scope.registration
        }).then(function successCallback(response) {

            $scope.btntext = "Update";
            $scope.registration = null;
            alert(response.data);
        }, function errorCallback() {
            alert('Failed');
        });
    };

});