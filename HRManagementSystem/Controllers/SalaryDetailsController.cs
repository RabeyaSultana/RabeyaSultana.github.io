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
    builder.EntitySet<SalaryDetail>("SalaryDetails");
    builder.EntitySet<EmployeeDetail>("EmployeeDetails"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class SalaryDetailsController : ODataController
    {
        private HRMSContext db = new HRMSContext();

        // GET: odata/SalaryDetails
        [EnableQuery]
        public IQueryable<SalaryDetail> GetSalaryDetails()
        {
            return db.SalaryDetails;
        }

        // GET: odata/SalaryDetails(5)
        [EnableQuery]
        public SingleResult<SalaryDetail> GetSalaryDetail([FromODataUri] int key)
        {
            return SingleResult.Create(db.SalaryDetails.Where(salaryDetail => salaryDetail.SalaryId == key));
        }

        // PUT: odata/SalaryDetails(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<SalaryDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SalaryDetail salaryDetail = db.SalaryDetails.Find(key);
            if (salaryDetail == null)
            {
                return NotFound();
            }

            patch.Put(salaryDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(salaryDetail);
        }

        // POST: odata/SalaryDetails
        public IHttpActionResult Post(SalaryDetail salaryDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SalaryDetails.Add(salaryDetail);
            db.SaveChanges();

            return Created(salaryDetail);
        }

        // PATCH: odata/SalaryDetails(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<SalaryDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SalaryDetail salaryDetail = db.SalaryDetails.Find(key);
            if (salaryDetail == null)
            {
                return NotFound();
            }

            patch.Patch(salaryDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(salaryDetail);
        }

        // DELETE: odata/SalaryDetails(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            SalaryDetail salaryDetail = db.SalaryDetails.Find(key);
            if (salaryDetail == null)
            {
                return NotFound();
            }

            db.SalaryDetails.Remove(salaryDetail);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/SalaryDetails(5)/EmployeeDetail
        [EnableQuery]
        public SingleResult<EmployeeDetail> GetEmployeeDetail([FromODataUri] int key)
        {
            return SingleResult.Create(db.SalaryDetails.Where(m => m.SalaryId == key).Select(m => m.EmployeeDetail));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalaryDetailExists(int key)
        {
            return db.SalaryDetails.Count(e => e.SalaryId == key) > 0;
        }
    }
}
