/// <reference path="../App/app.js" />
/// <reference path="../Factory/hrmSvc.js" />




app.controller('hrmCtrl', function ($scope, hrmSvc, $http, $window, $route) {

    //Empolyee Details
    $scope.getallEmpDetails = function () {
        (new hrmSvc()).$getallEmpDetails()
        .then(function (data) {
            $scope.employees = data.value;
        })
    }
    //----------------------------------------

    //----dropDown--------
    //$scope.items=['A+','A-','B+','O+']
    ////----------


    $scope.saveEmpDetails = function () {

        var imageToLoad = document.getElementById('pic1');
        var imageDataUrl = ConvertImageToBase64(imageToLoad, 'pic1');

        var newData = $scope.currentEmp;
        newData.eImage = imageDataUrl;
        return (new hrmSvc({
            "eName": newData.eName,
            "eGender": newData.eGender,
            "eDOB": newData.eDOB,
            "MarritualStatus": newData.MarritualStatus,
            "ePresentAddress": newData.ePresentAddress,
            "ePermanentAddress": newData.ePermanentAddress,
            "eBloodGroup": newData.eBloodGroup,
            "eMobile": newData.eMobile,
            "eEmail": newData.eEmail,
            "eNationality": newData.eNationality,
            "eNID": newData.eNID,
            "BasicPay": newData.BasicPay,
            "eReligion": newData.eReligion,
            "eDesignation": newData.eDesignation,
            "eDOJ": newData.eDOJ,
            "eQualification": newData.eQualification,
            "eExperience": newData.eExperience,
            "eContactPerson": newData.eContactPerson,
            "eLoan": newData.eLoan,
            "eLoanDescription": newData.eLoanDescription,
            "eExteaCurriculam": newData.eExteaCurriculam,
            "eExtraCurriculamDescription": newData.eExtraCurriculamDescription,
            "eImage": newData.eImage

        })).$saveEmpDetails()
        .then(function (data) {
            $scope.currentEmp = {};
            $scope.getallEmpDetails();
        });
    }
    //---------------------------------------------------

    $scope.updateEmpDetails = function () {
        var newData = $scope.currentEmp;
        if (newData) {
            (new hrmSvc({
                "empId": newData.empId,
                "eName": newData.eName,
                "eGender": newData.eGender,
                "eDOB": newData.eDOB,
                "MarritualStatus": newData.MarritualStatus,
                "ePresentAddress": newData.ePresentAddress,
                "ePermanentAddress": newData.ePermanentAddress,
                "eBloodGroup": newData.eBloodGroup,
                "eMobile": newData.eMobile,
                "eEmail": newData.eEmail,
                "eNationality": newData.eNationality,
                "eNID": newData.eNID,
                "BasicPay": newData.BasicPay,
                "eReligion": newData.eReligion,
                "eDesignation": newData.eDesignation,
                "eDOJ": newData.eDOJ,
                "eQualification": newData.eQualification,
                "eExperience": newData.eExperience,
                "eContactPerson": newData.eContactPerson,
                "eLoan": newData.eLoan,
                "eLoanDescription": newData.eLoanDescription,
                "eExteaCurriculam": newData.eExteaCurriculam,
                "eExtraCurriculamDescription": newData.eExtraCurriculamDescription,
                "eImage": newData.eImage,

            })).$updateEmpDetails({ key: newData.empId })
        .then(function (data) {
            $scope.currentEmp = {};
            $scope.getallEmpDetails();

        });
        }
    }

    //==========================================================

    $scope.queryEmp = function () {

        var con = this.emp;
        return (new hrmSvc({})).$queryEmp({ key: con.empId })
        .then(function (data) {
            $scope.currentEmp = data;
        });
    }

    //==========================================================

    $scope.removeEmpDetails = function () {
        var con = this.currentEmp;
        if (confirm('Are you sure?')) {
            var con = this.emp;
            return (new hrmSvc({

            })).$removeEmpDetails({ key: con.empId })
        .then(function (data) {
            $scope.getallEmpDetails();

        });
        }
    }

    //===================================================

    $scope.queryEmpDetailsView = function () {

        url = "http://localhost:33306/Api/EmployeeView";
        $http.get(url)
     .success(function (resp) {
         $scope.list = resp;
     });

    }
    //-----------------------Candidate --------------------------------------

    $scope.getallCandidate = function () {
        (new hrmSvc()).$getallCandidate()
        .then(function (data) {
            $scope.candidates = data.value;
        })
    }

    //--------------------------------------------------------------

    $scope.saveCandidate = function () {
        var imageToLoad = document.getElementById('pic');
        var imageDataUrl = ConvertImageToBase64(imageToLoad, 'pic');

        var newData = $scope.currentCant;
        newData.eImage = imageDataUrl;


        return (new hrmSvc({
            "name": newData.name,
            "fatherName": newData.fatherName,
            "motherName": newData.motherName,
            "email": newData.email,
            "Designation": newData.Designation,
            "mobNo": newData.mobNo,
            "dob": newData.dob,
            "gender": newData.gender,
            "nationality": newData.nationality,
            "NID": newData.NID,
            "marritualStatus": newData.marritualStatus,
            "religion": newData.religion,
            "quota": newData.quota,
            "TemAddress": newData.TemAddress,
            "ParAddress": newData.ParAddress,
            "examination": newData.examination,
            "result": newData.result,
            "university": newData.university,
            "passingYear": newData.passingYear,
            "groupSubject": newData.groupSubject,
            "eImage": newData.eImage
        })).$saveCandidate()
        .then(function (data) {
            alert("You can print applicant by log in");
            $scope.currentCant = {};
            $scope.getallCandidate();
        });
    }

    //----------------------------------------

    $scope.updateCandidate = function () {
        var newData = $scope.currentCant;
        if (newData) {
            (new hrmSvc({
                "cno": newData.cno,
                "name": newData.name,
                "fatherName": newData.fatherName,
                "motherName": newData.motherName,
                "email": newData.email,
                "Designation": newData.Designation,
                "mobNo": newData.mobNo,
                "dob": newData.dob,
                "gender": newData.gender,
                "nationality": newData.nationality,
                "NID": newData.NID,
                "marritualStatus": newData.marritualStatus,
                "religion": newData.religion,
                "quota": newData.quota,
                "TemAddress": newData.TemAddress,
                "ParAddress": newData.ParAddress,
                "examination": newData.examination,
                "result": newData.result,
                "university": newData.university,
                "passingYear": newData.passingYear,
                "groupSubject": newData.groupSubject,
                "eImage": newData.eImage

            })).$updateCandidate({ key: newData.cno })
        .then(function (data) {
            $scope.currentCant = {};
            $scope.getallCandidate();

        });
        }
    }

    //==========================================================
    $scope.queryCandidate = function () {
        var con = this.can;
        return (new hrmSvc({

        })).$queryCandidate({ key: con.cno })
        .then(function (data) {
            $scope.currentCant = data;
        });
    }

    //=======================================================

    $scope.removeCandidate = function () {
        var cn = this.currentCant;
        if (confirm('Are you sure?')) {
            var cn = this.can;
            return (new hrmSvc({

            })).$removeCandidate({ key: cn.cno })
        .then(function (data) {
            $scope.getallCandidate();

        });
        }
    }

    //==============================Jobpost==================

    $scope.getallJob = function () {
        (new hrmSvc()).$getallJob()
        .then(function (data) {
            $scope.jobpost = data.value;
        })
    }
    //-----------------------save------------------------
    $scope.saveJob = function () {

        var newData = $scope.currentJob;
        return (new hrmSvc({
            "JobDate": newData.JobDate,
            "JobTitle": newData.JobTitle,
            "Designation": newData.Designation,
            "Descriptions": newData.Descriptions,
            "Vacancies": newData.Vacancies,
            "LastDateForApply": newData.LastDateForApply,
            "Location": newData.Location,
        })).$saveJob()
        .then(function (data) {
            $scope.currentJob = {};
            $scope.getallJob();
        });
    }

    //---------------------update---------------------------------

    $scope.updateJob = function () {
        var con = $scope.currentJob;
        if (con) {
            (new hrmSvc({
                "JobId": con.JobId,
                "JobDate": con.JobDate,
                "JobTitle": con.JobTitle,
                "Descriptions": con.Descriptions,
                "Vacancies": con.Vacancies,
                "LastDateForApply": con.LastDateForApply,
                "Location": con.Location,

            })).$updateJob({ key: con.JobId })
        .then(function (data) {
            $scope.currentJob = {};
            $scope.getallJob();

        });
        }
    }
    //------------------search--------------------------------

    $scope.queryJob = function () {
        var con = this.job;
        return (new hrmSvc({

        })).$queryJob({ key: con.JobId })
        .then(function (data) {
            $scope.currentJob = data;
        });
    }

    //---------------------delete----------------------------

    $scope.removeJob = function () {
        var con = this.currentJob;
        if (confirm('Are you sure?')) {
            var con = this.job;
            return (new hrmSvc({

            })).$removeJob({ key: con.JobId })
        .then(function (data) {
            $scope.getallJob();

        });
        }
    }
    //-----------------------------Get Employee Name-----
    //$scope.getEmployeeName = function () {
    //    var con = this.currentSal;
    //    return (new hrmSvc({

    //    })).$queryJob({ key: con.empId })
    //    .then(function (data) {
    //        $scope.currentSal.empName = data;
    //    });
    //}
    //---------------Salary Calculation-------------------
    //---------HRA-------
    $scope.RastioHRA = function (BasicPay) {
        $scope.currentSal.HRA = parseFloat(BasicPay) * 40 / 100;
        $scope.currentSal.MedicalAllowance = parseFloat(BasicPay) * 10 / 100;
        $scope.currentSal.Convayence = parseFloat(BasicPay) * 10 / 100;
        $scope.currentSal.ProvidentFund = parseFloat(BasicPay) * 15 / 100;
        $scope.currentSal.Tax = parseFloat(BasicPay) * 5 / 100;


        $scope.currentSal.TotalEarnings = (parseFloat(BasicPay) + parseFloat($scope.currentSal.HRA) + parseFloat($scope.currentSal.MedicalAllowance) + parseFloat($scope.currentSal.Convayence)) / 30;

        $scope.currentSal.TotalDeduction = (parseFloat($scope.currentSal.ProvidentFund) + parseFloat($scope.currentSal.Tax)) / 30;

        $scope.currentSal.grossPay = (parseFloat($scope.currentSal.TotalEarnings) - parseFloat($scope.currentSal.TotalDeduction));
        if (totalPresent==0) {
            $scope.currentSal.NetPay = (parseFloat($scope.currentSal.calDays) * parseFloat($scope.currentSal.grossPay)) * parseFloat(totalPresent);
        }
        else {
            $scope.currentSal.NetPay = parseFloat($scope.currentSal.calDays) * parseFloat($scope.currentSal.grossPay);
        }

        //alert($scope.currentSal.NetPay);                                    

    }


    //------------------Working Days----------------

    $scope.monthNames = [{ name: 'none' },
        {
            mNum: '01',
            name: 'January',
            days: 23,
            Hdays: 8,

        }, {
            mNum: '02',
            name: 'February',
            days: 19,
            Hdays: 9,

        },

    {
        mNum: '03',
        name: 'March',
        days: 21,
        Hdays: 10,

    },
    {
        mNum: '04',
        name: 'April',
        days: 21,
        Hdays: 9,

    },
    {
        mNum: '05',
        name: 'May',
        days: 22,
        Hdays: 9,

    },
    {
        mNum: '06',
        name: 'June',
        days: 22,
        Hdays: 8,

    },
    {
        mNum: '07',
        name: 'July',
        days: 23,
        Hdays: 8,

    },
    {
        mNum: '08',
        name: 'August',
        days: 19,
        Hdays: 12,

    },
    {
        mNum: '09',
        name: 'September',
        days: 22,
        Hdays: 8,

    },
    {
        mNum: '10',
        name: 'October',
        days: 21,
        Hdays: 10,

    },
    {
        mNum: '11',
        name: 'November',
        days: 22,
        Hdays: 8,

    },
    {
        mNum: '12',
        name: 'December',
        days: 21,
        Hdays: 10,

    }];

    $scope.selectedItem = $scope.monthNames[1]


    //============================================================
    $scope.getallSalary = function () {
        (new hrmSvc()).$getallSalary()
        .then(function (data) {
            $scope.salaries = data.value;
        })
    }

    //==========================Save==========================================
    $scope.ShowDate = new Date();
    var sdate = new Date();
    $scope.saveSalary = function () {

        var newData = $scope.currentSal;
        newData.BasicPay = parseFloat(newData.BasicPay, 10).toFixed(2);
        newData.HRA = parseFloat(newData.HRA, 10).toFixed(2);
        newData.MedicalAllowance = parseFloat(newData.MedicalAllowance, 10).toFixed(2);
        newData.Convayence = parseFloat(newData.Convayence, 10).toFixed(2);
        newData.ProvidentFund = parseFloat(newData.ProvidentFund, 10).toFixed(2);
        newData.TotalEarnings = parseFloat(newData.TotalEarnings, 10).toFixed(2);
        newData.TotalDeduction = parseFloat(newData.TotalDeduction, 10).toFixed(2);
        newData.NetPay = parseFloat(newData.NetPay, 10).toFixed(2);
        newData.Tax = parseFloat(newData.Tax, 10).toFixed(2);


        return (new hrmSvc({
            //"SalaryId": newData.SalaryId,
            "sReciptNo": newData.sReciptNo,
            "sDate": sdate.getFullYear() + '-' + ('0' + (sdate.getMonth() + 1)).slice(-2) + '-' + ('0' + sdate.getDate()).slice(-2),
            "empId": newData.empId,
            "BasicPay":newData.BasicPay,
            "HRA": newData.HRA,
            "MedicalAllowance": newData.MedicalAllowance,
            "Convayence": newData.Convayence,
            "ProvidentFund": newData.ProvidentFund,
            "Tax": newData.Tax,
            "TotalEarnings": newData.TotalEarnings,
            "TotalDeduction": newData.TotalDeduction,
            "NetPay": newData.NetPay,
        })).$saveSalary()
        .then(function (data) {
            $scope.currentSal = {};
            $scope.getallSalary();
            $scope.refreshSalary();

        });
    }

    //---------------------update---------------------------------

    $scope.updateSalary = function () {
        var newData = $scope.currentSal;
        if (newData) {
            (new hrmSvc({
                "SalaryId": newData.SalaryId,
                "sReciptNo": newData.sReciptNo,
                "sDate": date.getFullYear() + '-' + ('0' + (date.getMonth() + 1)).slice(-2) + '-' + ('0' + date.getDate()).slice(-2),
                "empId": newData.empId,
                "HRA": newData.HRA,
                "MedicalAllowance": newData.MedicalAllowance,
                "Convayence": newData.Convayence,
                "ProvidentFund": newData.ProvidentFund,
                "Tax": newData.Tax,
                "TotalEarnings": newData.TotalEarnings,
                "TotalDeduction": newData.TotalDeduction,
                "NetPay": newData.NetPay,
            })).$updateSalary({ key: newData.SalaryId })
        .then(function (data) {
            $scope.currentSal = {};
            $scope.getallSalary();

        });
        }
    }

    //------------------search--------------------------------

    $scope.queryEmpDetails = function () {
        var con = this.currentSal;

        var idn = parseInt(con.empId)

        return (new hrmSvc({


        })).$queryEmpDetails({ key: idn })
        .then(function (data) {

            $scope.currentSal.empBasicPay = data.BasicPay;
            $scope.currentSal.empName = data.eName;
            $scope.presentDayById(data.empId);
            $scope.RastioHRA(data.BasicPay);

        });
    }

    $scope.emps = [];
    var totalPresent = 0;
    //var totalAbsent = 0;
    var m = "";
    $scope.presentDayById = function (idn) {

        $http.get("http://localhost:33306/api/AttendenceView/" + idn)
       .then(function (response) {
           $scope.emps = response.data;

           for (var i = 0; i < $scope.emps.length; i++) {

               if ($scope.emps[i].aDate.substring(5, 7) == $scope.selectedItem.mNum) {

                   totalPresent += $scope.emps[i].Status;

               }
           }

           $scope.currentSal.TotalPresent = totalPresent;
           $scope.currentSal.AbsentDay = $scope.selectedItem.days - totalPresent;
           $scope.currentSal.calDays = $scope.selectedItem.Hdays + totalPresent;
           //$scope.currentSal.calDays = $scope.selectedItem.Hdays;

       }, function (response) {
           //
       });


    }


    //---------------------delete----------------------------
    $scope.removeSalary = function () {
        var con = this.currentSal;
        if (confirm('Are you sure?')) {
            var con = this.salary;
            return (new hrmSvc({

            })).$removeSalary({ key: con.SalaryId })
        .then(function (data) {
            $scope.getallSalary();

        });
        }
    }

    //----------SalaryView---------------------

    $scope.showSalary = function () {

        url = "http://localhost:33306/Api/SalaryView";
        $http.get(url)
     .success(function (resp) {
         $scope.salaryView = resp;
     });

    }

    //---------refreshSalary-------------

    $scope.refreshSalary = function () {
        var con = this.emp;
        $route.reload();
    }


    //-----------printSalary------------

    $scope.printIt = function () {
        var table = document.getElementById("printArea").innerHTML;
        var myWindow = $window.open('', '', 'width=800, height=600');
        myWindow.document.write(table);
        myWindow.print();
    };

    //---------------------Attendence----------------------------
    $scope.ShowDate = new Date();
    //$scope.date = new Date();  
    //------------
    $scope.getallAttendence = function () {
        (new hrmSvc()).$getallAttendence()
        .then(function (data) {
            $scope.attendence = data.value;
        })
    }

    //---------------------query----------------------------

    $scope.queryEmpAtt = function () {
        var con = this.emp;
        $scope.currentAtten = con;

    }

    //-----------------------save------------------------
    $scope.saveAttendence = function () {
        var date = new Date();

        var newData = $scope.currentAtten;
        return (new hrmSvc({

            "empId": newData.empId,
            "aDate": date.getFullYear() + '-' + ('0' + (date.getMonth() + 1)).slice(-2) + '-' + ('0' + date.getDate()).slice(-2),
            "aTime": date.getHours() + ':' + ('0' + (date.getMinutes() + 1)).slice(-2),
            "Status": newData.Status

        })).$saveAttendence()
        .then(function (data) {
            $scope.currentAtten = {};

        });
    }

    //------------------View---------------------------
    $scope.allAttendenceView = function () {

        url = "http://localhost:33306/Api/AttendenceView";
        $http.get(url).success(function (resp) {
            $scope.Atten = resp;

        });
        //$scope.Atten.count();
    }


    //$scope.queryAttendenceView = function (idn) {

    //    url = "http://localhost:33306/Api/AttendenceView/";
    //    $http.get(url + idn).then(function (res) {
    //        $scope.TotalPresent = res.data;
    //    }, function (res) {


    //    });
    //}

});


//====================================================================
function ConvertImageToBase64(imageToConvertBase64, picture) {
    var drawCanvas = document.createElement("canvas");
    var p = document.getElementById(picture);
    drawCanvas.width = 150;
    drawCanvas.height = 150;
    var copyImageToCanvas = drawCanvas.getContext("2d");

    copyImageToCanvas.drawImage(p, 0, 0, 150, 150);
    var dataUrlOfImage = drawCanvas.toDataURL("image/png");
    return dataUrlOfImage.replace(/^data:image\/(png|jpg);base64,/, "");
}

//==============================================================

function readURL(input, t) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#' + t)
                .attr('src', e.target.result)
                .width(150)
                .height(150);
        };

        reader.readAsDataURL(input.files[0]);
        input.value = '';
    }
}


