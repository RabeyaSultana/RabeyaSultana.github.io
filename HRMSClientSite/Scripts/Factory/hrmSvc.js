/// <reference path="../App/app.js" />



app.factory('hrmSvc', function ($resource) {

    var odataUrlEmpD = "http://localhost:33306/odata/EmployeeDetails";
    var odataUrlAdd = "http://localhost:33306/odata/addresses";
    var odataUrlAttend = "http://localhost:33306/odata/AttendenceDetails";
    var odataUrlCandidate = "http://localhost:33306/odata/Candidate_Detail";
    var odataUrlSalary = "http://localhost:33306/odata/SalaryDetails";
    var odataUrlJob = "http://localhost:33306/odata/JobPosteds";
    var odataUrlEmpLog = "http://localhost:33306/odata/EmployeeLogins";
    var odataUrlEdu = "http://localhost:33306/odata/educationDetails";
    var ApiUrlSalaryView = "http://localhost:33306/Api/SalaryView";
    var ApiUrlEmpView = "http://localhost:33306/Api/EmployeeView";
    var ApiUrlEmpAttView = "http://localhost:33306/Api/AttendenceView";


    return $resource("", {}, {
        //Employee Details
        'getallEmpDetails': { method: 'GET', url: odataUrlEmpD },
        'saveEmpDetails': { method: 'POST', url: odataUrlEmpD },
        'updateEmpDetails': { method: 'PUT', params: { key: "@key" }, url: odataUrlEmpD + "(:key)" },
        'queryEmp': { method: 'GET', params: { key: "@key" }, url: odataUrlEmpD + "(:key)" },
        'removeEmpDetails': { method: 'DELETE', params: { key: "@key" }, url: odataUrlEmpD + "(:key)" },

        //Employee Login
        'getallEmpLogin': { method: 'GET', url: odataUrlEmpLog },
        'saveEmpLogin': { method: 'POST', url: odataUrlEmpLog },
        'updateEmpLogin': { method: 'PUT', params: { key: "@key" }, url: odataUrlEmpLog + "(:key)" },
        'queryEmpLogin': { method: 'GET', params: { key: "@key" }, url: odataUrlEmpLog + "(:key)" },
        'removeEmpLogin': { method: 'DELETE', params: { key: "@key" }, url: odataUrlEmpLog + "(:key)" },

        //Address
        'getallAddress': { method: 'GET', url: odataUrlAdd },
        'saveAddress': { method: 'POST', url: odataUrlAdd },
        'updateAddress': { method: 'PUT', params: { key: "@key" }, url: odataUrlAdd + "(:key)" },
        'queryAddress': { method: 'GET', params: { key: "@key" }, url: odataUrlAdd + "(:key)" },
        'removeAddress': { method: 'DELETE', params: { key: "@key" }, url: odataUrlAdd + "(:key)" },

        //Attendence
        'getallAttendence': { method: 'GET', url: odataUrlAttend },
        'saveAttendence': { method: 'POST', url: odataUrlAttend },
        'updateAttendence': { method: 'PUT', params: { key: "@key" }, url: odataUrlAttend + "(:key)" },
        'queryEmpAtt': { method: 'GET', params: { key: "@key" }, url: odataUrlAttend + "(:key)" },
        'removeAttendence': { method: 'DELETE', params: { key: "@key" }, url: odataUrlAttend + "(:key)" },

        //Candidate
        'getallCandidate': { method: 'GET', url: odataUrlCandidate },
        'saveCandidate': { method: 'POST', url: odataUrlCandidate },
        'updateCandidate': { method: 'PUT', params: { key: "@key" }, url: odataUrlCandidate + "(:key)" },
        'queryCandidate': { method: 'GET', params: { key: "@key" }, url: odataUrlCandidate + "(:key)" },
        'removeCandidate': { method: 'DELETE', params: { key: "@key" }, url: odataUrlCandidate + "(:key)" },

        //JobPost
        'getallJob': { method: 'GET', url: odataUrlJob },
        'saveJob': { method: 'POST', url: odataUrlJob },
        'updateJob': { method: 'PUT', params: { key: "@key" }, url: odataUrlJob + "(:key)" },
        'queryJob': { method: 'GET', params: { key: "@key" }, url: odataUrlJob + "(:key)" },
        'removeJob': { method: 'DELETE', params: { key: "@key" }, url: odataUrlJob + "(:key)" },

        //Salary Details
        'getallSalary': { method: 'GET', url: odataUrlSalary },
        'saveSalary': { method: 'POST', url: odataUrlSalary },
        'updateSalary': { method: 'PUT', params: { key: "@key" }, url: odataUrlSalary + "(:key)" },
        'querySalary': { method: 'GET', params: { key: "@key" }, url: odataUrlSalary + "(:key)" },
        'removeSalary': { method: 'DELETE', params: { key: "@key" }, url: odataUrlSalary + "(:key)" },
        'queryEmpDetails': { method: 'GET', params: { key: "@key" }, url: odataUrlEmpD + "(:key)" },

        //Education
        'getallEducation': { method: 'GET', url: odataUrlEdu },
        'saveEducation': { method: 'POST', url: odataUrlEdu },
        'updateEducation': { method: 'PUT', params: { key: "@key" }, url: odataUrlEdu + "(:key)" },
        'queryEducation': { method: 'GET', params: { key: "@key" }, url: odataUrlEdu + "(:key)" },
        'removeEducation': { method: 'DELETE', params: { key: "@key" }, url: odataUrlEdu + "(:key)" },

        //salaryView
        'showSalary': { method: 'GET', url: ApiUrlSalaryView },
        //EmployeeView
        'queryEmpDetailsView': { method: 'GET', url: ApiUrlEmpView },
        //AttendenceView
        'queryAttendenceView': { method: 'GET', url: ApiUrlEmpAttView },


        
    });
});