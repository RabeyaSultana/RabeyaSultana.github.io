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
    builder.EntitySet<EmployeeLogin>("EmployeeLogins");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EmployeeLoginsController : ODataController
    {
        private HRMSContext db = new HRMSContext();

        // GET: odata/EmployeeLogins
        [EnableQuery]
        public IQueryable<EmployeeLogin> GetEmployeeLogins()
        {
            return db.EmployeeLogins;
        }

        // GET: odata/EmployeeLogins(5)
        [EnableQuery]
        public SingleResult<EmployeeLogin> GetEmployeeLogin([FromODataUri] int key)
        {
            return SingleResult.Create(db.EmployeeLogins.Where(employeeLogin => employeeLogin.loginId == key));
        }

        // PUT: odata/EmployeeLogins(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<EmployeeLogin> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EmployeeLogin employeeLogin = db.EmployeeLogins.Find(key);
            if (employeeLogin == null)
            {
                return NotFound();
            }

            patch.Put(employeeLogin);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeLoginExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(employeeLogin);
        }

        // POST: odata/EmployeeLogins
        public IHttpActionResult Post(EmployeeLogin employeeLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeLogins.Add(employeeLogin);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployeeLoginExists(employeeLogin.loginId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(employeeLogin);
        }

        // PATCH: odata/EmployeeLogins(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<EmployeeLogin> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EmployeeLogin employeeLogin = db.EmployeeLogins.Find(key);
            if (employeeLogin == null)
            {
                return NotFound();
            }

            patch.Patch(employeeLogin);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeLoginExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(employeeLogin);
        }

        // DELETE: odata/EmployeeLogins(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            EmployeeLogin employeeLogin = db.EmployeeLogins.Find(key);
            if (employeeLogin == null)
            {
                return NotFound();
            }

            db.EmployeeLogins.Remove(employeeLogin);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeLoginExists(int key)
        {
            return db.EmployeeLogins.Count(e => e.loginId == key) > 0;
        }
    }
}
