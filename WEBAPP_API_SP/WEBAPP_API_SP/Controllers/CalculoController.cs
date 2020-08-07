using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WEBAPP_API_SP.Helper;
using WEBAPP_API_SP.Models;

namespace WEBAPP_API_SP.Controllers
{
    public class CalculoController : Controller
    {
        Service s = new Service();

        // GET: Calculo
        public async Task<ActionResult> Index(string usuario)
        {
            List<Calculo> calculos = new List<Calculo>();
            HttpClient client = s.Initial();
            HttpResponseMessage response;
            response = await client.GetAsync("api/Calculo");

            //validate parameter tipo
            if (!String.IsNullOrEmpty(usuario))
            {
                response = await client.GetAsync("api/Calculo/?usuario=" + usuario.ToString());
            }

            //validate api response
            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                calculos = JsonConvert.DeserializeObject<List<Calculo>>(results);
            }

            return View(calculos);
        }

        // GET: Calculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calculo/Create
        [HttpPost]
        public ActionResult Create(Calculo calculo)
        {
            try
            {
                // TODO: Add insert logic here
                HttpClient client = s.Initial();

                HttpResponseMessage response = client.PostAsJsonAsync("api/Calculo", calculo).Result;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calculo/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var c = new Calculo();
            HttpClient client = s.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Calculo/" + id);

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                c = JsonConvert.DeserializeObject<Calculo>(results);
            }

            return View(c);
        }

        // POST: Calculo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Calculo calculo)
        {
            try
            {
                // TODO: Add update logic here
                HttpClient client = s.Initial();
                HttpResponseMessage response = client.PutAsJsonAsync("api/Calculo/" + calculo.Id, calculo).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calculo/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var c = new Calculo();

            try
            {
                HttpClient client = s.Initial();
                HttpResponseMessage res = await client.GetAsync("api/Calculo/" + id);

                if (res.IsSuccessStatusCode)
                {
                    var results = res.Content.ReadAsStringAsync().Result;
                    c = JsonConvert.DeserializeObject<Calculo>(results);
                }
                return View(c);

            }
            catch (Exception)
            {

                return View(c);
            }
        }

        // POST: Calculo/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Calculo calculo)
        {
            try
            {
                // TODO: Add delete logic here
                HttpClient client = s.Initial();
                HttpResponseMessage response = await client.DeleteAsync("api/Calculo/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
