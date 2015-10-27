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
    public class ProductController : ODataController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET odata/Award
        [EnableQuery(MaxExpansionDepth = 2)]
        public IHttpActionResult GetProduct()
        {
            return Ok(db.Products);
        }

        // GET odata/Award(5)
        [EnableQuery(MaxExpansionDepth = 2)]
        public async Task<IHttpActionResult> GetProduct([FromODataUri] string key)
        {
            var award = await db.Products.FindAsync(key);
            if (award == null)
            {
                return NotFound();
            }

            return Ok(award);
        }

        // PUT odata/Award(5)
        [Authorize]
        public async Task<IHttpActionResult> Put([FromODataUri] string key, Product model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != model.Id)
            {
                return BadRequest();
            }

            var product = await db.Products.FindAsync(model.Id);
            if (product == null)
            {
                return NotFound();
            }
           
            try
            {
                product.Modify(model, db);
                //db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Updated(model);
        }

        // POST odata/Award
        [Authorize]
        public async Task<IHttpActionResult> Post(Product model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                model.Create(db);
                db.Products.Add(model);

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
        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<Product> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var award = await db.Products.FindAsync(key);
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
        public async Task<IHttpActionResult> Delete([FromODataUri] string key)
        {
            Product product = await db.Products.FindAsync(key);

            if (product == null)
            {
                return NotFound();
            }

            try
            {
                db.Products.Remove(product);
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