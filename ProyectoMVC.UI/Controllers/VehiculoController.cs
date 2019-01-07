using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVC.UI.Controllers
{
    public class VehiculoController : Controller
    {

        public ActionResult ListarVehiculos()
        {

            ProyectoMVC.LogicaDeNegocios.CordinadorDeVehiculos elCordinador = new LogicaDeNegocios.CordinadorDeVehiculos();
            List<ProyectoMVC.Model.Vehiculo> laListaDeVehiculos = new List<Model.Vehiculo>();
            laListaDeVehiculos = elCordinador.ListarVehiculos();
            return View(laListaDeVehiculos);
        }


        public ActionResult Crear()
        {
            return View();
        }

 
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
