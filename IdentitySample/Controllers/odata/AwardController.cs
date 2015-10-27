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
    public class AwardController : ODataController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET odata/Award
        [EnableQuery(MaxExpansionDepth = 2)]
        public IHttpActionResult GetAward()
        {
            return Ok(db.Awards);
        }

        // GET odata/Award(5)
        [EnableQuery(MaxExpansionDepth = 2)]
        public async Task<IHttpActionResult> GetAward([FromODataUri] string key)
        {
            var award = await db.Awards.FindAsync(key);
            if (award == null)
            {
                return NotFound();
            }

            return Ok(award);
        }

        // PUT odata/Award(5)
        //[Authorize]
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromODataUri] string key, Award model)//[FromODataUri] string key,
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != model.Id)
            {
                return BadRequest();
            }

            var category = await db.Awards.FindAsync(model.Id);

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
        public async Task<IHttpActionResult> Post(Award model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                model.Create(db);

                db.Awards.Add(model);

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
        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<Award> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var award = await db.Awards.FindAsync(key);
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
            Award award = await db.Awards.FindAsync(key);

            if (award == null)
            {
                return NotFound();
            }

            try
            {
                db.Awards.Remove(award);
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