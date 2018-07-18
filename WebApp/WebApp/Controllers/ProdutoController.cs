using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProdutoController : Controller
    {
        HttpClient client = new HttpClient();
        public string _hostService;

        public ProdutoController()
        {
            _hostService = WebConfigurationManager.AppSettings["hostService"];


        }

        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_hostService);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = client.GetAsync("api/categoria/GetAll").Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    WebApp.Response _response = JsonConvert.DeserializeObject<WebApp.Response>(result);

                    if (_response.IsSucess)
                    {
                        List<CategoriaViewModel> objetoRetorno = JsonConvert.DeserializeObject<List<CategoriaViewModel>>(_response.Data);

                        List<SelectListItem> ls = new List<SelectListItem>();

                        foreach (var item in objetoRetorno)
                        {
                            ls.Add(new SelectListItem() { Text = item.Nome, Value = item.ID.ToString() });

                        }
                        ViewData["category"] = ls;
                    }

                }
                else
                {
                    //Console.WriteLine("Internal server Error");
                }
            }

            return View();

        }






        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ProdutoViewModel novoProd = new ProdutoViewModel()
                {
                    IdCategoria = int.Parse(collection["IdCategoria"]),
                    DataAtualizacao = DateTime.Now.ToString(),
                    Descricao = collection["Descricao"],
                    Nome = collection["Nome"],
                    PrecoUnitarioCompra = decimal.Parse(collection["PrecoUnitarioCompra"]),
                    PrecoUnitarioVenda = decimal.Parse(collection["PrecoUnitarioVenda"]),
                    Quantidade = int.Parse(collection["Quantidade"])
                };


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_hostService);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsync("api/produto/Post", new StringContent(JsonConvert.SerializeObject(novoProd))).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        WebApp.Response _response = JsonConvert.DeserializeObject<WebApp.Response>(result);

                        if (_response.IsSucess)
                        {
                            List<CategoriaViewModel> objetoRetorno = JsonConvert.DeserializeObject<List<CategoriaViewModel>>(_response.Data);

                            List<SelectListItem> ls = new List<SelectListItem>();

                            foreach (var item in objetoRetorno)
                            {
                                ls.Add(new SelectListItem() { Text = item.Nome, Value = item.ID.ToString() });

                            }
                            ViewData["category"] = ls;
                        }

                    }
                    else
                    {
                        //Console.WriteLine("Internal server Error");
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
