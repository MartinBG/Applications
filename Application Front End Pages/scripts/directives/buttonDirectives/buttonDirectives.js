angular.module("buttonDirectives", ["routing"])
    .directive("editButton", function(){
        return{
            restrict: "A",
            controller: function(TransferData, $state){
                this.EditSth = function(item){
                    TransferData.setData(item);
                    $state.go('EditApplication');
                }
            },
            controllerAs: "edit"
        }
    })
    .directive("deleteButton", function () {
        return{
            restrict: "A",
            controller: function($http){
                this.Delete = function(item, items)
                {
                    $http({
                        method: "DELETE",
                        url: "http://localhost:64840/api/Applications/deleteApplication/" + item.Id
                    }).success(function(value){
                        console.log(value);
                        var index = items.indexOf(items);
                        items.splice(index,1);
                    })
                }
            },
            controllerAs: "delete"
        }
    })
    .directive("addButton", function(){
        return{
            restrict: "A",
            controller: function($state){
                this.GoToAdd = function()
                {
                    $state.go("AddApplication");
                }
            },
            controllerAs: "add"
        }
    })
    .directive("filterButton", function(){
        return{
            restrict: "A",
            controller: function($http, $rootScope){
                this.LoadNewContent = function(filterObject)
                {

                    if(filterObject.newInterval.startDate ==null || filterObject.newInterval.endDate == null)
                    {
                        filterObject.newInterval = null;
                        if(filterObject.subject == "")
                        {
                            filterObject = null;
                        }
                    }
                    $http({
                        method: "POST",
                        url: "http://localhost:64840/api/Applications/filterApplications",
                        data: filterObject
                    }).success(function(value) {
                        $rootScope.$broadcast("filter", value);
                    })
                }
            },
            controllerAs: "filter"
        }
    })

