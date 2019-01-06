using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVC.UI.Controllers
{
    public class VehiculoController : Controller
    {
        // GET: Vehiculo
        public ActionResult ListarVehiculos()
        {

            ProyectoMVC.LogicaDeNegocios.CordinadorDeVehiculos elCordinador = new LogicaDeNegocios.CordinadorDeVehiculos();
            List<ProyectoMVC.Model.Vehiculo> laListaDeVehiculos = new List<Model.Vehiculo>();
            laListaDeVehiculos = elCordinador.ListarVehiculos();
            return View(laListaDeVehiculos);
        }

        // GET: Vehiculo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vehiculo/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Vehiculo/Create
        [HttpPost]
        public ActionResult Crear(ProyectoMVC.Model.Vehiculo elVehiculo)
        {
            try
            {
                ProyectoMVC.LogicaDeNegocios.CordinadorDeVehiculos elCordinador = new LogicaDeNegocios.CordinadorDeVehiculos();
                elCordinador.Agregar(elVehiculo);

                return RedirectToAction("ListarVehiculos");
            }
            catch
            {
                return View();
            }
        }


 
        public ActionResult Eliminar(int id)
        {
            try
            {
                ProyectoMVC.LogicaDeNegocios.CordinadorDeVehiculos cordinadorDeVehiculos = new LogicaDeNegocios.CordinadorDeVehiculos();
                cordinadorDeVehiculos.ColocarEnEliminado(id);

                return RedirectToAction("ListarVehiculos");
            }
            catch
            {
                return View();
            }
        }
    }
}
