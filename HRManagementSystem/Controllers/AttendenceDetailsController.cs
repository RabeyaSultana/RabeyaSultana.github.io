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
    builder.EntitySet<AttendenceDetail>("AttendenceDetails");
    builder.EntitySet<EmployeeDetail>("EmployeeDetails"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class AttendenceDetailsController : ODataController
    {
        private HRMSContext db = new HRMSContext();
        

        // GET: odata/AttendenceDetails
        [EnableQuery]
        public IQueryable<AttendenceDetail> GetAttendenceDetails()
        {
            return db.AttendenceDetails;
        }

        // GET: odata/AttendenceDetails(5)
        [EnableQuery]
        public SingleResult<AttendenceDetail> GetAttendenceDetail([FromODataUri] int key)
        {
            return SingleResult.Create(db.AttendenceDetails.Where(attendenceDetail => attendenceDetail.empId == key));
        }

        // PUT: odata/AttendenceDetails(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<AttendenceDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AttendenceDetail attendenceDetail = db.AttendenceDetails.Find(key);
            if (attendenceDetail == null)
            {
                return NotFound();
            }

            patch.Put(attendenceDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendenceDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(attendenceDetail);
        }

        // POST: odata/AttendenceDetails
        public IHttpActionResult Post(AttendenceDetail attendenceDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
           
            }

            db.AttendenceDetails.Add(attendenceDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AttendenceDetailExists(attendenceDetail.empId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }

            }

            return Created(attendenceDetail);
        }

        private bool AttendenceDetailExists(int? nullable)
        {
            throw new NotImplementedException();
        }

        // PATCH: odata/AttendenceDetails(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<AttendenceDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AttendenceDetail attendenceDetail = db.AttendenceDetails.Find(key);
            if (attendenceDetail == null)
            {
                return NotFound();
            }

            patch.Patch(attendenceDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendenceDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                    
                }
              
            }

            return Updated(attendenceDetail);
        }

        // DELETE: odata/AttendenceDetails(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            AttendenceDetail attendenceDetail = db.AttendenceDetails.Find(key);
            if (attendenceDetail == null)
            {
                return NotFound();
            }

            db.AttendenceDetails.Remove(attendenceDetail);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/AttendenceDetails(5)/EmployeeDetail
        [EnableQuery]
        public SingleResult<EmployeeDetail> GetEmployeeDetail([FromODataUri] int key)
        {
            return SingleResult.Create(db.AttendenceDetails.Where(m => m.empId == key).Select(m => m.EmployeeDetail));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttendenceDetailExists(int key)
        {
            return db.AttendenceDetails.Count(e => e.empId == key) > 0;
        }

    }

}
