angular.module("routing", ['ui.router', 'TransferDataService'])
    .config(function($stateProvider, $urlRouterProvider){
        $stateProvider
            .state("Applications", {
                url: "/Applications",
                templateUrl: "../html/Views/list-view.html"
            })
            .state('EditApplication', {
                url:"/EditApplication",
                templateUrl: "../html/Views/edit-application.html",
                controller: function($scope, TransferData, $http, $state)
                {
                    this.Application = TransferData.getData();

                    this.Submit = function(item)
                    {
                        $http({
                            method: "PUT",
                            url: "http://localhost:64840/api/Applications/updateApplication/" + item.Id,
                            data: item
                        }).success(function(value){
                            console.log(value);
                            $state.go("Applications");
                        })
                    }

                    this.Cancel = function()
                    {
                        $state.go("Applications");
                    }
                },
                controllerAs: "editView"
            })
            .state('AddApplication', {
                url:"/AddApplication",
                templateUrl: "../html/Views/add-application.html",
                controller: function($scope, $state, $http){
                    $scope.Application ={}
                    $scope.Application.Sender = "";
                    $scope.Application.Subject = "";
                    $scope.PostDate = null;

                    this.Submit = function()
                    {
                        console.log($scope.Application);
                        $http({
                            method: "POST",
                            url: "http://localhost:64840/api/Applications/postApplication",
                            data: $scope.Application
                        }).success(function(value){
                            console.log(value);
                            $state.go("Applications");
                        })
                    }

                    this.Cancel = function()
                    {
                        $state.go("Applications");
                    }
                },
                controllerAs: "addView"
            })
        $urlRouterProvider.otherwise("Applications");
    });
