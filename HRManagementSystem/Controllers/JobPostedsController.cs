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
    builder.EntitySet<JobPosted>("JobPosteds");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class JobPostedsController : ODataController
    {
        private HRMSContext db = new HRMSContext();

        // GET: odata/JobPosteds
        [EnableQuery]
        public IQueryable<JobPosted> GetJobPosteds()
        {
            return db.JobPosteds;
        }

        // GET: odata/JobPosteds(5)
        [EnableQuery]
        public SingleResult<JobPosted> GetJobPosted([FromODataUri] int key)
        {
            return SingleResult.Create(db.JobPosteds.Where(jobPosted => jobPosted.JobId == key));
        }

        // PUT: odata/JobPosteds(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<JobPosted> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            JobPosted jobPosted = db.JobPosteds.Find(key);
            if (jobPosted == null)
            {
                return NotFound();
            }

            patch.Put(jobPosted);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobPostedExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(jobPosted);
        }

        // POST: odata/JobPosteds
        public IHttpActionResult Post(JobPosted jobPosted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JobPosteds.Add(jobPosted);
            db.SaveChanges();

            return Created(jobPosted);
        }

        // PATCH: odata/JobPosteds(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<JobPosted> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            JobPosted jobPosted = db.JobPosteds.Find(key);
            if (jobPosted == null)
            {
                return NotFound();
            }

            patch.Patch(jobPosted);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobPostedExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(jobPosted);
        }

        // DELETE: odata/JobPosteds(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            JobPosted jobPosted = db.JobPosteds.Find(key);
            if (jobPosted == null)
            {
                return NotFound();
            }

            db.JobPosteds.Remove(jobPosted);
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

        private bool JobPostedExists(int key)
        {
            return db.JobPosteds.Count(e => e.JobId == key) > 0;
        }
    }
}
