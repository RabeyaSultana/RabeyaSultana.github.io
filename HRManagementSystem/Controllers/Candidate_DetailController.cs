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
    builder.EntitySet<Candidate_Detail>("Candidate_Detail");
    builder.EntitySet<address>("addresses"); 
    builder.EntitySet<educationDetail>("educationDetails"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class Candidate_DetailController : ODataController
    {
        private HRMSContext db = new HRMSContext();

        // GET: odata/Candidate_Detail
        [EnableQuery]
        public IQueryable<Candidate_Detail> GetCandidate_Detail()
        {
            return db.Candidate_Details;
        }

        // GET: odata/Candidate_Detail(5)
        [EnableQuery]
        public SingleResult<Candidate_Detail> GetCandidate_Detail([FromODataUri] int key)
        {
            return SingleResult.Create(db.Candidate_Details.Where(candidate_Detail => candidate_Detail.cno == key));
        }

        // PUT: odata/Candidate_Detail(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Candidate_Detail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Candidate_Detail candidate_Detail = db.Candidate_Details.Find(key);
            if (candidate_Detail == null)
            {
                return NotFound();
            }

            patch.Put(candidate_Detail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Candidate_DetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(candidate_Detail);
        }

        // POST: odata/Candidate_Detail
        public IHttpActionResult Post(Candidate_Detail candidate_Detail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Candidate_Details.Add(candidate_Detail);
            db.SaveChanges();

            return Created(candidate_Detail);
        }

        // PATCH: odata/Candidate_Detail(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Candidate_Detail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Candidate_Detail candidate_Detail = db.Candidate_Details.Find(key);
            if (candidate_Detail == null)
            {
                return NotFound();
            }

            patch.Patch(candidate_Detail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Candidate_DetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(candidate_Detail);
        }

        // DELETE: odata/Candidate_Detail(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Candidate_Detail candidate_Detail = db.Candidate_Details.Find(key);
            if (candidate_Detail == null)
            {
                return NotFound();
            }

            db.Candidate_Details.Remove(candidate_Detail);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Candidate_Detail(5)/addresses
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Candidate_DetailExists(int key)
        {
            return db.Candidate_Details.Count(e => e.cno == key) > 0;
        }
    }
}
