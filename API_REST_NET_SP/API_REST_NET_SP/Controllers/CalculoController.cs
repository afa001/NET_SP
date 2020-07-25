using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API_REST_NET_SP.Models;

namespace API_REST_NET_SP.Controllers
{
    public class CalculoController : ApiController
    {
        private bdIndraEntities1 db = new bdIndraEntities1();

        // GET: api/Calculo
        public IHttpActionResult GetCalculo()
        {
            //sp
            var emp = db.GetCalculo().ToList();
            return Ok(emp);
        }

        // GET: api/Calculo/5
        [ResponseType(typeof(Calculo))]
        public IHttpActionResult GetCalculo(int id)
        {
            var emp = db.GetIdCalculo(id);
            if (emp == null)
            {
                return NotFound();
            }

            return Ok(emp);
        }

        // PUT: api/Calculo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCalculo(int id, Calculo calculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calculo.Id)
            {
                return BadRequest();
            }

            db.Entry(calculo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculoExists(id))
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

        // POST: api/Calculo
        [ResponseType(typeof(Calculo))]
        [HttpPost]
        public IHttpActionResult PostCalculo(Calculo calculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var calculoId = db.InsertCalculo(calculo.Respuesta,calculo.FechaHora,calculo.UsuarioId);

            //db.Calculo.Add(calculo);
            //db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = calculo.Id }, calculo);
        }

        // DELETE: api/Calculo/5
        [ResponseType(typeof(Calculo))]
        [HttpDelete]
        public IHttpActionResult DeleteCalculo(int id)
        {
            /*var calculo = db.GetIdCalculo(id);
            if (calculo == null)
            {
                return NotFound();
            }*/

            var emp = db.DeleteCalculo(id);
            //db.Calculo.Remove(calculo);
            //db.SaveChanges();

            return Ok(emp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CalculoExists(int id)
        {
            return db.Calculo.Count(e => e.Id == id) > 0;
        }
    }
}