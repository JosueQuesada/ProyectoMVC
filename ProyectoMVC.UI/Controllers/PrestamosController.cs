using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVC.UI.Controllers
{
    public class PrestamosController : Controller
    {
        // GET: Prestamos
        public ActionResult ListarPrestamos()
        {
            ProyectoMVC.LogicaDeNegocios.CordinadorDePrestamos cordinadorDePrestamos = new LogicaDeNegocios.CordinadorDePrestamos();
           List<Model.Prestamos> laListaDePrestamos = cordinadorDePrestamos.ListarPrestamos();
            return View(laListaDePrestamos);
        }

        // GET: Prestamos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Prestamos/Create
        public ActionResult Crear()
        {
            ProyectoMVC.LogicaDeNegocios.CordinadorDeClientes cordinadorDeClientes = new LogicaDeNegocios.CordinadorDeClientes();
            var miLista = cordinadorDeClientes.ListarClientes();
            SelectList miListaDeCedulas = new SelectList(miLista, "cedula", "cedula");
            ViewBag.miLista = miListaDeCedulas;

            ProyectoMVC.LogicaDeNegocios.CordinadorDeVehiculos cordinadorDeVehiculos = new LogicaDeNegocios.CordinadorDeVehiculos();
            var miListaDePlacas = cordinadorDeVehiculos.ListarVehiculos();
            SelectList miListaDeCedulasSelectList = new SelectList(miListaDePlacas, "numeroDePlaca", "numeroDePlaca");
            ViewBag.miListaPlacas = miListaDeCedulasSelectList;
            return View();
        }

        // POST: Prestamos/Create
        [HttpPost]
        public ActionResult Crear(ProyectoMVC.Model.Prestamos elNuevoPrestamo)
        {
            try
            {
                ProyectoMVC.LogicaDeNegocios.CordinadorDePrestamos cordinadorDePrestamos = new LogicaDeNegocios.CordinadorDePrestamos();
                elNuevoPrestamo.dias = 1;
                cordinadorDePrestamos.Agregar(elNuevoPrestamo);

                return RedirectToAction("ListarPrestamos");
            }
            catch
            {
                return View();
            }
        }

        // GET: Prestamos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Prestamos/Edit/5
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

        // GET: Prestamos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Prestamos/Delete/5
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
