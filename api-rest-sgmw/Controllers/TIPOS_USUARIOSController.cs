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
    public class TIPOS_USUARIOSController : ApiController
    {
        private DB_9DAB36_LABORATORIOEntities db = new DB_9DAB36_LABORATORIOEntities();
        /// <summary>
        /// Lista todos los tipos de usuario
        /// </summary>
        /// <returns></returns>
        // GET: api/TIPOS_USUARIOS
        public IQueryable<TIPOS_USUARIOS> GetTIPOS_USUARIOS()
        {
            return db.TIPOS_USUARIOS;
        }

        /// <summary>
        /// Lista usuarios por ID
        /// </summary>
        /// <param name="id"></param>
        // GET: api/TIPOS_USUARIOS/5
        [ResponseType(typeof(TIPOS_USUARIOS))]
        public IHttpActionResult GetTIPOS_USUARIOS(int id)
        {
            TIPOS_USUARIOS tIPOS_USUARIOS = db.TIPOS_USUARIOS.Find(id);
            if (tIPOS_USUARIOS == null)
            {
                return NotFound();
            }

            return Ok(tIPOS_USUARIOS);
        }

        /// <summary>
        /// Actualiza/reemplaza un tipo de usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tIPOS_USUARIOS"></param>
        /// <returns></returns>
        // PUT: api/TIPOS_USUARIOS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTIPOS_USUARIOS(int id, TIPOS_USUARIOS tIPOS_USUARIOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tIPOS_USUARIOS.TIPO_USUARIO_ID)
            {
                return BadRequest();
            }

            db.Entry(tIPOS_USUARIOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TIPOS_USUARIOSExists(id))
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
        /// Crea un tipo de usuario
        /// </summary>
        /// <param name="tIPOS_USUARIOS"></param>
        /// <returns></returns>
        // POST: api/TIPOS_USUARIOS
        [ResponseType(typeof(TIPOS_USUARIOS))]
        public IHttpActionResult PostTIPOS_USUARIOS(TIPOS_USUARIOS tIPOS_USUARIOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TIPOS_USUARIOS.Add(tIPOS_USUARIOS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tIPOS_USUARIOS.TIPO_USUARIO_ID }, tIPOS_USUARIOS);
        }

        /// <summary>
        /// Elimina un tipo de usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/TIPOS_USUARIOS/5
        [ResponseType(typeof(TIPOS_USUARIOS))]
        public IHttpActionResult DeleteTIPOS_USUARIOS(int id)
        {
            TIPOS_USUARIOS tIPOS_USUARIOS = db.TIPOS_USUARIOS.Find(id);
            if (tIPOS_USUARIOS == null)
            {
                return NotFound();
            }

            db.TIPOS_USUARIOS.Remove(tIPOS_USUARIOS);
            db.SaveChanges();

            return Ok(tIPOS_USUARIOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TIPOS_USUARIOSExists(int id)
        {
            return db.TIPOS_USUARIOS.Count(e => e.TIPO_USUARIO_ID == id) > 0;
        }
    }
}