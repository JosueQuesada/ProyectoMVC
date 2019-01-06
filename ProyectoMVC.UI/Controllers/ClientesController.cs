using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVC.UI.Controllers
{
    public class ClientesController : Controller
    {
    
        public ActionResult ListaDeClientes()
        {

            ProyectoMVC.LogicaDeNegocios.CordinadorDeClientes elCordinador = new LogicaDeNegocios.CordinadorDeClientes();
            List<ProyectoMVC.Model.Clientes> laListaDeClientes = new List<Model.Clientes>();
            laListaDeClientes = elCordinador.ListarClientes();
            return View(laListaDeClientes);
        }


  
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ProyectoMVC.Model.Clientes elNuevoCliente)
        {
            try
            {
                ProyectoMVC.LogicaDeNegocios.CordinadorDeClientes elCordinadorDeClientes = new LogicaDeNegocios.CordinadorDeClientes();
                elCordinadorDeClientes.Agregar(elNuevoCliente);

                return RedirectToAction("ListaDeClientes");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Editar(int id)
        {
            ProyectoMVC.LogicaDeNegocios.CordinadorDeClientes cordinadorDeClientes = new LogicaDeNegocios.CordinadorDeClientes();
            ProyectoMVC.Model.Clientes elCliente = new Model.Clientes();
            elCliente= cordinadorDeClientes.ObternerClientePorId(id);
            return View(elCliente);
        }

        [HttpPost]
        public ActionResult Editar(int id, ProyectoMVC.Model.Clientes elCliente)
        {
            try
            {
                ProyectoMVC.LogicaDeNegocios.CordinadorDeClientes cordinadorDeClientes = new LogicaDeNegocios.CordinadorDeClientes();
                elCliente.id = id;
                cordinadorDeClientes.Editar(elCliente);

                return RedirectToAction("ListaDeClientes");
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
                ProyectoMVC.Model.Clientes elCliente = new Model.Clientes();
                ProyectoMVC.LogicaDeNegocios.CordinadorDeClientes cordinadorDeClientes = new LogicaDeNegocios.CordinadorDeClientes();
                cordinadorDeClientes.ColocarEnEliminado(id);

                return RedirectToAction("ListaDeClientes");
            }
            catch
            {
                return View();
            }
        }
    }
}
