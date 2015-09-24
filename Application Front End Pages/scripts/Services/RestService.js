angular.module('RestService',[])
    .service('RestService', function($http){
        return {
            update: function (Url, item) {
                $http({
                    method: "PUT",
                    url: Url,
                    data: item
                }).success(function (value) {
                    console.log(value);
                })
            },
            delete: function (Url) {
                $http({
                    method: "DELETE",
                    url: Url
                }).success(function (value) {
                    console.log(value);
                })
            },
            post: function(Url, item){
                $http({
                    method: "POST",
                    url: Url,
                    data: item
                }).success(function (value){
                    console.log(value);
                })
            }
        }
    });