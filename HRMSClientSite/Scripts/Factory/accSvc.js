/// <reference path="../App/app.js" />


app.factory('accSvc', function ($resource) {
    var userUrl = "http://localhost:33306/odata/EmployeeLogins/";

    return $resource("", {}, {
        'signUpUser': { method: "POST", url: userUrl }//,



    });
});
