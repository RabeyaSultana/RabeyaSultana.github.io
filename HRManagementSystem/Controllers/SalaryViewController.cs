using HRManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRManagementSystem.Controllers
{
    public class SalaryViewController : ApiController
    {
        HRMSContext db = new HRMSContext();

        public IQueryable<SalaryView> GetAllEmployeeView()
        {
            var query = db.SalaryDetails.Select
                (d => new SalaryView {
                    empId=d.EmployeeDetail.empId,
   
                     eName=d.EmployeeDetail.eName,
                      eDesignation=d.EmployeeDetail.eDesignation,
                    BasicPay = d.EmployeeDetail.BasicPay,
                       TotalEarnings=d.TotalEarnings,
                       TotalDeduction=d.TotalDeduction,
                        NetPay=d.NetPay
                });
            return query.AsQueryable();
        }
    }
}
