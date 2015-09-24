angular.module("ViewDirectives", [])
    .directive("listView", function($http){
        return{
            restrict: "E",
            templateUrl: "../html/Views/list-applications.html",
            controller: function($scope){
                $scope.items = [];
            },
            controllerAs: "list",
            link: function(scope, element, attributes){
                scope.$on("filter", function(e, items){
                   console.log(items);
                  scope.items = items;
                })
                var SrcDatabase = attributes.src;
                $http.get(SrcDatabase).success( function (data){
                    for (item in data)
                    {
                        scope.items.push(data[item]);
                    }
                })
            }
        }
    })
    .directive("searchForm", function(){
        return{
            restrict: "E",
            templateUrl: "../html/Forms/search-form.html",
            controller: function()
            {
                this.filterObject = {};
                this.filterObject.subject = "";
                this.filterObject.newInterval = {};
                this.filterObject.newInterval.startDate = null;
                this.filterObject.newInterval.endDate = null;
            },
            controllerAs: "search"
        }
    })
    .directive("editForm", function(){
        return{
            restrict: "E",
            templateUrl: "../html/Forms/application-edit-form.html"
        }
    })
    .directive("addForm", function(){
        return{
            restrict: "E",
            templateUrl: "../html/Forms/application-add-form.html"
        }
    })
