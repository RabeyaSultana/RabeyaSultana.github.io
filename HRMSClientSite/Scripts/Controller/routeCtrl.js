/// <reference path="../angular.js" />


app.config(function ($routeProvider) {
    $routeProvider.

    //when('/admin', { templateUrl: '/Pages/AdminDashBoard.html', controller: 'accCtrl' }).
    //when('/dept', { templateUrl: '/Pages/DepartmentInfo.html', controller: 'accCtrl' }).
    //when('/emp', { templateUrl: 'Pages/EmployeeInfo1.html', controller: 'accCtrl' }).
    //when('/empnew', { templateUrl: 'Pages/EmployeeInfoNew.html', controller: 'accCtrl' }).
    //when('/about', { templateUrl: 'Pages/About.html' }).
    //when('/cont', { templateUrl: 'Pages/Contact.html' }).
    //when('/home', { templateUrl: 'Pages/Home.html', controller: 'slideCtrl' }).
     when('/admin', { templateUrl: '/Pages/AdminDashBoard.html', controller: 'accCtrl' }).
        when('/empdetail', { templateUrl: 'Forms/EmployeeDetailsInfo.html', controller: 'hrmCtrl' }).
        when('/EmployeeDetailsList', { templateUrl: 'Forms/EmployeeviewList.html', controller: 'hrmCtrl' }).
         when('/jobposted', { templateUrl: 'Forms/JobPosted.html', controller: 'hrmCtrl' }).
         when('/canList', { templateUrl: 'Forms/CandidateList.html', controller: 'hrmCtrl' }).
         when('/JobList', { templateUrl: 'Forms/JobList.html', controller: 'hrmCtrl' }).
        when('/candetail', { templateUrl: 'Forms/CandidateDetails.html', controller: 'hrmCtrl' }).
         when('/ApplicantCopy', { templateUrl: 'Forms/ApplicantCopy.html', controller: 'hrmCtrl' }).
        when('/Atten', { templateUrl: 'Forms/Attendence.html', controller: 'hrmCtrl' }).
        when('/AttenView', { templateUrl: 'Forms/AttendenceView.html', controller: 'hrmCtrl' }).
        when('/salaryCal', { templateUrl: 'Forms/SalaryCalculate.html', controller: 'hrmCtrl' }).
        when('/salary', { templateUrl: 'Forms/SalaryDetails.html', controller: 'hrmCtrl' }).
        when('/salaryStr', { templateUrl: 'Forms/SalaryView.html', controller: 'hrmCtrl' }).
    otherwise({ redirectTo: '/home' });
});