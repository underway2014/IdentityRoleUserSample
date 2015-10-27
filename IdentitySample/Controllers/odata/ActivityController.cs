using IdentitySample.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.OData;

namespace IdentitySample.Controllers.odata
{
    public class ActivityController : ODataController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET odata/Award
        [EnableQuery(MaxExpansionDepth = 2)]
        public IHttpActionResult GetActivity()
        {
            return Ok(db.Activities);
        }

        // GET odata/Award(5)
        [EnableQuery(MaxExpansionDepth = 2)]
        public async Task<IHttpActionResult> GetActivity([FromODataUri] string key)
        {
            var award = await db.Activities.FindAsync(key);
            if (award == null)
            {
                return NotFound();
            }

            return Ok(award);
        }

        // PUT odata/Award(5)
        //[Authorize]
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromODataUri] string key, Activity model)//[FromODataUri] string key,
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != model.Id)
            {
                return BadRequest();
            }

            var category = await db.Activities.FindAsync(model.Id);

            if (category == null)
            {
                return NotFound();
            }

            category.Modify(model, db);
            //db.Entry(category).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Updated(model);
        }

        // POST odata/Award
        //[Authorize]
        [HttpPost]
        public async Task<IHttpActionResult> Post(Activity model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                model.Create(db);
                db.Activities.Add(model);

                await db.SaveChangesAsync();

                return Ok(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("PostError", ex.Message);

                return BadRequest(ModelState);
            }
        }

        // PATCH odata/Award(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<Activity> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var award = await db.Activities.FindAsync(key);
            if (award == null)
            {
                return NotFound();
            }

            patch.Patch(award);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Updated(award);
        }

        // DELETE odata/WeixinPage(5)
        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromODataUri] string key)
        {
            Activity award = await db.Activities.FindAsync(key);

            if (award == null)
            {
                return NotFound();
            }

            try
            {
                db.Activities.Remove(award);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

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
    }
}