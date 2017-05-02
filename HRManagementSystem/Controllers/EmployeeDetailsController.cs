using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using HRManagementSystem;

namespace HRManagementSystem.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using HRManagementSystem;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<EmployeeDetail>("EmployeeDetails");
    builder.EntitySet<Attendence_Detail>("Attendence_Details"); 
    builder.EntitySet<SalaryDetail>("SalaryDetails"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EmployeeDetailsController : ODataController
    {
        private HRMSContext db = new HRMSContext();

        // GET: odata/EmployeeDetails
        [EnableQuery]
        public IQueryable<EmployeeDetail> GetEmployeeDetails()
        {
            return db.EmployeeDetails;
        }

        // GET: odata/EmployeeDetails(5)
        [EnableQuery]
        public SingleResult<EmployeeDetail> GetEmployeeDetail([FromODataUri] int key)
        {
            return SingleResult.Create(db.EmployeeDetails.Where(employeeDetail => employeeDetail.empId == key));
        }

        // PUT: odata/EmployeeDetails(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<EmployeeDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(key);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            patch.Put(employeeDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(employeeDetail);
        }

        // POST: odata/EmployeeDetails
        public IHttpActionResult Post(EmployeeDetail employeeDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeDetails.Add(employeeDetail);
            db.SaveChanges();

            return Created(employeeDetail);
        }

        // PATCH: odata/EmployeeDetails(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<EmployeeDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(key);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            patch.Patch(employeeDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(employeeDetail);
        }

        // DELETE: odata/EmployeeDetails(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(key);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            db.EmployeeDetails.Remove(employeeDetail);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/EmployeeDetails(5)/AttendenceDetails
        [EnableQuery]
        public IQueryable<AttendenceDetail> GetAttendenceDetails([FromODataUri] int key)
        {
            return db.EmployeeDetails.Where(m => m.empId == key).SelectMany(m => m.AttendenceDetails);
        }

        // GET: odata/EmployeeDetails(5)/SalaryDetails
        [EnableQuery]
        public IQueryable<SalaryDetail> GetSalaryDetails([FromODataUri] int key)
        {
            return db.EmployeeDetails.Where(m => m.empId == key).SelectMany(m => m.SalaryDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeDetailExists(int key)
        {
            return db.EmployeeDetails.Count(e => e.empId == key) > 0;
        }
    }
}
