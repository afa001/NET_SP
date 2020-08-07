using ASP_NET.Models;
using ASP_NET.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET.Controllers
{
    public class CalculoController : Controller
    {
        Conexion conexion = new Conexion();
        Operacion operacion = new Operacion();
        Calculo calculo = new Calculo();

        // GET: Calculo
        public ActionResult Index()
        {
            DataSet ds = conexion.Select();
            ViewBag.emp = ds.Tables[0];
            return View();
        }

        //Create
        // GET: Calculo/Calcular
        public ActionResult Calcular()
        {
            return View();
        }

        // POST: Calculo/Calcular
        [HttpPost]
        public ActionResult Calcular(string usuario, int limite)
        {
            int suma = 0;
            
            //validacion numeros positivos
            if (limite > 0)
            {
                //suma de positivos menores al limite
                for (int i = 1; i <= limite; i++)
                {
                    //validacion multiplos 3 o 5 de cada numero positivo menor al limite
                    if (i % 3 == 0 || i % 5 == 0)
                    {
                       suma += i;
                    }
                }
            }
            //ViewModel objeto, necesario para mostrar el resultado del calculo en la vista
            operacion.Resultado = suma.ToString();

            //Guardamos el calculo en base de datos, con procedimientos almacenados
            calculo.Respuesta = suma;
            calculo.FechaHora = DateTime.Now;
            calculo.UsuarioId = 1;

            conexion.Insert(calculo);

            return View(operacion);
        }

        //// GET: Calculo/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Calculo/Create
        //[HttpPost]
        //public ActionResult Create(Calculo calculo)
        //{
        //    try
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Calculo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Calculo/Edit/5
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

        // GET: Calculo/Delete/5
        public ActionResult Delete(int id)
        {
            return View(conexion.SelectId(id));
        }

        // POST: Calculo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Calculo calculo)
        {
            try
            {
                // TODO: Add delete logic here
                conexion.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
