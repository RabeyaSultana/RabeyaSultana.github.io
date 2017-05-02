using HRManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRManagementSystem.Controllers
{
    public class EmployeeViewController : ApiController
    {
        HRMSContext db = new HRMSContext();

         public IQueryable<EmployeeView> GetEmployeeView()
        {
            var query = db.SalaryDetails.Select(
                d => new EmployeeView
                {
                    empId=d.EmployeeDetail.empId,
                    eName = d.EmployeeDetail.eName,
                    eMobile = d.EmployeeDetail.eMobile,
                    eEmail = d.EmployeeDetail.eEmail,
                    eDesignation = d.EmployeeDetail.eDesignation,
                    BasicPay=d.EmployeeDetail.BasicPay,
                    NetPay = d.NetPay
                   
                }
                );

            return query.AsQueryable();
        }
         
    }
}
