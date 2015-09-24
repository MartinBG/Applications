angular.module("TransferDataService", [])
    .service("TransferData", function(){
        var data = {};
        this.setData = function(newData)
        {
            console.log("setData");
            console.log(newData);
            data = newData;
        }
        this.getData = function()
        {
            console.log("getData");
            console.log(data);
            return data;
        }
    })