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
    public class ProdutoController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Produto
        /*public IQueryable<Produto> GetProdutos()
        {
            return db.Produtos;
        }

        // GET: api/Produto/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult GetProduto(int id)
        {
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        // PUT: api/Produto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduto(int id, Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produto.ID)
            {
                return BadRequest();
            }

            db.Entry(produto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
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
        */
        // POST: api/Produto
        [Route("api/produto/post")]
        public Response Post(string JsonProduto)
        {
            Produto produto = JsonConvert.DeserializeObject<Produto>(JsonProduto);
            Response resp = new Response() { IsSucess = true, Message = "Cadastro Realizado com sucesso.", Data = null };
            if (!ModelState.IsValid)
            {
                resp.IsSucess = false;
                resp.Data = BadRequest(ModelState).ToString();

                return resp;
            }

            db.Produtos.Add(produto);
            db.SaveChanges();
            resp.Data = produto.ID.ToString();

            return resp;
        }

        // DELETE: api/Produto/5
       /* [ResponseType(typeof(Produto))]
        public IHttpActionResult DeleteProduto(int id)
        {
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            db.Produtos.Remove(produto);
            db.SaveChanges();

            return Ok(produto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdutoExists(int id)
        {
            return db.Produtos.Count(e => e.ID == id) > 0;
        }*/
    }
}