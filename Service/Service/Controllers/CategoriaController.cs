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
using Service.Models;
using Newtonsoft.Json;
using Service.Results;

namespace Service.Controllers
{
    public class CategoriaController : ApiController
    {
        private Contexto db = new Contexto();
        [Route("api/categoria/{name}")]
        public Response GetAll()
        {
            Response response = new Response() { IsSucess = false, Data = null, Message = null };
            try
            {
                var categorias = db.Categorias.Where(c => c.Ativo == true).ToList();
                response.Data = JsonConvert.SerializeObject(categorias);
                response.Message = "OK";
                response.IsSucess = true;
                //return JsonConvert.SerializeObject(categorias);
            }
            catch (Exception ex)
            {
                response.Data = JsonConvert.SerializeObject(ex);

            }
            return response;
            //return JsonConvert.SerializeObject(response);
        }

        public string Get(int id)
        {
            Response response = new Response() { IsSucess = false, Data = null, Message = null };
            try
            {
                var categorias = db.Categorias.Where(c => c.Ativo == true && c.ID == id).FirstOrDefault();
                response.Data = JsonConvert.SerializeObject(categorias);
                response.Message = "OK";
                response.IsSucess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Data = JsonConvert.SerializeObject(ex);

            }

            return JsonConvert.SerializeObject(response);
        }

        /* private Contexto db = new Contexto();

        // GET: api/Categoria
        [HttpGet]
        public string GetCategorias()
        {
            var categoria = db.Categorias;
            return "teste";
        }

        // GET: api/Categoria/5
        [ResponseType(typeof(Categoria))]
        public IHttpActionResult GetCategoria(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        // PUT: api/Categoria/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoria(int id, Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.ID)
            {
                return BadRequest();
            }

            db.Entry(categoria).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        // POST: api/Categoria
        [ResponseType(typeof(Categoria))]
        public IHttpActionResult PostCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categorias.Add(categoria);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoria.ID }, categoria);
        }

        // DELETE: api/Categoria/5
        [ResponseType(typeof(Categoria))]
        public IHttpActionResult DeleteCategoria(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }

            db.Categorias.Remove(categoria);
            db.SaveChanges();

            return Ok(categoria);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriaExists(int id)
        {
            return db.Categorias.Count(e => e.ID == id) > 0;
        }*/
    }
}