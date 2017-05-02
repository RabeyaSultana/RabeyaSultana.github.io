using HRManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace HRManagementSystem.Controllers
{
    public class AttendenceViewController : ApiController
    {
        HRMSContext db= new HRMSContext();
        public IQueryable<AttendenceView> GetAttendenceView()
        {
            var query = db.AttendenceDetails.Select(
               d => new AttendenceView
               {
                   empId = d.EmployeeDetail.empId,
                   eName = d.EmployeeDetail.eName,
                   eDesignation = d.EmployeeDetail.eDesignation,
                   Status = d.Status,
                   aDate = d.aDate,
                   aTime = d.aTime
               }
                );
            return query.AsQueryable();
        }

        [ResponseType(typeof(AttendenceView))]
        public IQueryable<AttendenceView> GetAttnceView(int id)
        {
            var query = db.AttendenceDetails.Select(
               d => new AttendenceView
               {
                   empId = d.EmployeeDetail.empId,
                   eName = d.EmployeeDetail.eName,
                   eDesignation = d.EmployeeDetail.eDesignation,
                   Status = d.Status,
                   aDate = d.aDate,
                   aTime = d.aTime
               }
                ).Where(d => d.empId == id);
            return query.AsQueryable();
        }

       
    }
}
