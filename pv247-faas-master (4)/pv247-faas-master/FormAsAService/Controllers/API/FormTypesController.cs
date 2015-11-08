using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Model;

namespace FormAsAService.Controllers
{
    public class FormTypesController : ApiController
    {
        private FormAsAServiceDbContext db = new FormAsAServiceDbContext();

        // GET: api/FormTypes
        public IQueryable<FormType> GetFormTypes()
        {
            return db.FormTypes.Include(f => f.ElementTypes);
        }

        // GET: api/FormTypes/5
        [ResponseType(typeof(FormType))]
        public async Task<IHttpActionResult> GetFormType(int id)
        {
            FormType formType = await db.FormTypes.FindAsync(id);
            if (formType == null)
            {
                return NotFound();
            }

            return Ok(formType);
        }

        // PUT: api/FormTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFormType(int id, FormType formType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != formType.Id)
            {
                return BadRequest();
            }

            db.Entry(formType).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FormTypes
        [ResponseType(typeof(FormType))]
        public async Task<IHttpActionResult> PostFormType(FormType formType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FormTypes.Add(formType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("API Default", new { id = formType.Id }, formType);
        }

        // DELETE: api/FormTypes/5
        [ResponseType(typeof(FormType))]
        public async Task<IHttpActionResult> DeleteFormType(int id)
        {
            FormType formType = await db.FormTypes.FindAsync(id);
            if (formType == null)
            {
                return NotFound();
            }

            db.FormTypes.Remove(formType);
            await db.SaveChangesAsync();

            return Ok(formType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FormTypeExists(int id)
        {
            return db.FormTypes.Count(e => e.Id == id) > 0;
        }
    }
}