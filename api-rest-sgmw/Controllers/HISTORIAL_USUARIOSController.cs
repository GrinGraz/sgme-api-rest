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
using api_rest_sgmw;

namespace api_rest_sgmw.Controllers
{
    public class HISTORIAL_USUARIOSController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();

        /// <summary>
        /// Lista todos los usuarios
        /// </summary>
        /// <returns></returns>
        // GET: api/HISTORIAL_USUARIOS
        public IQueryable<HISTORIAL_USUARIOS> GetHISTORIAL_USUARIOS()
        {
            return db.HISTORIAL_USUARIOS;
        }

        /// <summary>
        /// Lista el historial de usuario por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/HISTORIAL_USUARIOS/5
        [ResponseType(typeof(HISTORIAL_USUARIOS))]
        public IHttpActionResult GetHISTORIAL_USUARIOS(int id)
        {
            HISTORIAL_USUARIOS hISTORIAL_USUARIOS = db.HISTORIAL_USUARIOS.Find(id);
            if (hISTORIAL_USUARIOS == null)
            {
                return NotFound();
            }

            return Ok(hISTORIAL_USUARIOS);
        }

        /// <summary>
        /// Actualiza/reemplaza el historial de usuarios
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hISTORIAL_USUARIOS"></param>
        /// <returns></returns>
        // PUT: api/HISTORIAL_USUARIOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHISTORIAL_USUARIOS(int id, HISTORIAL_USUARIOS hISTORIAL_USUARIOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hISTORIAL_USUARIOS.ID)
            {
                return BadRequest();
            }

            db.Entry(hISTORIAL_USUARIOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HISTORIAL_USUARIOSExists(id))
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

        /// <summary>
        /// Crea un historial de usuarios
        /// </summary>
        /// <param name="hISTORIAL_USUARIOS"></param>
        /// <returns></returns>
        // POST: api/HISTORIAL_USUARIOS
        [ResponseType(typeof(HISTORIAL_USUARIOS))]
        public IHttpActionResult PostHISTORIAL_USUARIOS(HISTORIAL_USUARIOS hISTORIAL_USUARIOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HISTORIAL_USUARIOS.Add(hISTORIAL_USUARIOS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hISTORIAL_USUARIOS.ID }, hISTORIAL_USUARIOS);
        }

        /// <summary>
        /// Elimina un historial de usuarios
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/HISTORIAL_USUARIOS/5
        [ResponseType(typeof(HISTORIAL_USUARIOS))]
        public IHttpActionResult DeleteHISTORIAL_USUARIOS(int id)
        {
            HISTORIAL_USUARIOS hISTORIAL_USUARIOS = db.HISTORIAL_USUARIOS.Find(id);
            if (hISTORIAL_USUARIOS == null)
            {
                return NotFound();
            }

            db.HISTORIAL_USUARIOS.Remove(hISTORIAL_USUARIOS);
            db.SaveChanges();

            return Ok(hISTORIAL_USUARIOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HISTORIAL_USUARIOSExists(int id)
        {
            return db.HISTORIAL_USUARIOS.Count(e => e.ID == id) > 0;
        }
    }
}