using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WEBAPP_API_SP.Models;

namespace WEBAPP_API_SP.Controllers
{
    public class CalculoController : Controller
    {
        // GET: Calculo
        public ActionResult Index ()
        {
            IEnumerable<Calculo> calculos;
            HttpResponseMessage response = GlobalVariables.webapiClient.GetAsync("Calculo").Result;
            calculos = response.Content.ReadAsAsync<IEnumerable<Calculo>>().Result;

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
                HttpResponseMessage response = GlobalVariables.webapiClient.PostAsJsonAsync("Calculo", calculo).Result;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calculo/Edit/5
        public ActionResult Edit(int id)
        {
            //var c = new Calculo();
            //HttpClient client = s.Initial();
            //HttpResponseMessage res = await client.GetAsync("Calculo/" + id);

            //if (res.IsSuccessStatusCode)
            //{
            //    var results = res.Content.ReadAsStringAsync().Result;
            //    c = JsonConvert.DeserializeObject<Calculo>(results);
            //}

            return View();
        }

        // POST: Calculo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Calculo calculo)
        {
            try
            {
                // TODO: Add update logic here
                //HttpClient client = s.Initial();
                //HttpResponseMessage response = client.PutAsJsonAsync("Calculo/" + calculo.Id, calculo).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calculo/Delete/5
        public ActionResult Delete(int id)
        {
            
            HttpResponseMessage response = GlobalVariables.webapiClient.GetAsync("Calculo/" + id).Result;
            List<Calculo> calculos = response.Content.ReadAsAsync<List<Calculo>>().Result;
            var calculo = calculos[0];

            return View(calculo);
        }

        // POST: Calculo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Calculo calculo)
        {
            try
            {
                // TODO: Add delete logic here
                HttpResponseMessage response = GlobalVariables.webapiClient.DeleteAsync("Calculo/" + calculo.Id).Result;

                if (response.Equals("404"))
                {
                    return View();
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
