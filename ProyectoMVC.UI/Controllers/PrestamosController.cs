using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVC.UI.Controllers
{
    public class PrestamosController : Controller
    {
       
        public ActionResult ListarPrestamos()
        {
            ProyectoMVC.LogicaDeNegocios.CordinadorDePrestamos cordinadorDePrestamos = new LogicaDeNegocios.CordinadorDePrestamos();
           List<Model.Prestamos> laListaDePrestamos = cordinadorDePrestamos.ListarPrestamosEnProceso();
            return View(laListaDePrestamos);
        }


        public ActionResult ListaDeClientes()
        {

            ProyectoMVC.LogicaDeNegocios.CordinadorDeClientes elCordinador = new LogicaDeNegocios.CordinadorDeClientes();
            List<ProyectoMVC.Model.Clientes> laListaDeClientes = new List<Model.Clientes>();
            laListaDeClientes = elCordinador.ListarClientes();
            return View(laListaDeClientes);
        }
     
        public ActionResult DetallesDelCliente(int id)
        {
            ProyectoMVC.LogicaDeNegocios.CordinadorDeClientes cordinadorDeClientes = new LogicaDeNegocios.CordinadorDeClientes();
            ProyectoMVC.Model.Clientes elCliente = new Model.Clientes();
            elCliente = cordinadorDeClientes.ObternerClientePorId(id);
            return View(elCliente);
        }
        public ActionResult ListarPrestamosFinalizados(string numeroDeCedula)
        {
            ProyectoMVC.LogicaDeNegocios.CordinadorDePrestamos cordinadorDePrestamos = new LogicaDeNegocios.CordinadorDePrestamos();
            List<Model.Prestamos> laListaDePrestamos = cordinadorDePrestamos.ListarPrestamosFinalizados(numeroDeCedula);
            return View(laListaDePrestamos);
        }

        public ActionResult Crear()
        {
            ProyectoMVC.LogicaDeNegocios.CordinadorDeClientes cordinadorDeClientes = new LogicaDeNegocios.CordinadorDeClientes();
            var miLista = cordinadorDeClientes.ListarClientesDisponibles();
            SelectList miListaDeCedulas = new SelectList(miLista, "cedula", "cedula");
            ViewBag.miLista = miListaDeCedulas;

            ProyectoMVC.LogicaDeNegocios.CordinadorDeVehiculos cordinadorDeVehiculos = new LogicaDeNegocios.CordinadorDeVehiculos();
            var miListaDePlacas = cordinadorDeVehiculos.ListarVehiculosDisponibles();
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
                elNuevoPrestamo.dias = cordinadorDePrestamos.CalcularDias(elNuevoPrestamo.fechaDeDevolucion,elNuevoPrestamo.fechaDePrestamo);
                elNuevoPrestamo.montoDePrestamo = cordinadorDePrestamos.CalcularMontoPrestamo(elNuevoPrestamo.dias);
                elNuevoPrestamo.montoACancelar = cordinadorDePrestamos.CalcularMontoACancelar(elNuevoPrestamo.montoDePrestamo,elNuevoPrestamo.prima);
                cordinadorDePrestamos.Agregar(elNuevoPrestamo);

                ProyectoMVC.LogicaDeNegocios.CordinadorDeVehiculos cordinadorDeVehiculos = new LogicaDeNegocios.CordinadorDeVehiculos();
                int idVehiculo = cordinadorDeVehiculos.ObtenerIdVehiculoPorNumeroDePlaca(elNuevoPrestamo.placaDelVehiculo);
                cordinadorDeVehiculos.ColocarEnPrestamo(idVehiculo);

                ProyectoMVC.LogicaDeNegocios.CordinadorDeClientes cordinadorDeClientes = new LogicaDeNegocios.CordinadorDeClientes();
                int idCliente = cordinadorDeClientes.ObtenerIdClientePorNumeroDeCedula(elNuevoPrestamo.cedulaDelCliente);
                cordinadorDeClientes.ColocarEnPrestamo(idCliente);

                return RedirectToAction("ListarPrestamos");
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Finalizar(int id)
        {

            ProyectoMVC.LogicaDeNegocios.CordinadorDePrestamos cordinadorDePrestamos = new LogicaDeNegocios.CordinadorDePrestamos();
            ProyectoMVC.Model.Prestamos elPrestamo = new Model.Prestamos();
            elPrestamo= cordinadorDePrestamos.ObternerPrestamoPorId(id);

            return View(elPrestamo);
        }

    
        [HttpPost]
        public ActionResult Finalizar(int id, ProyectoMVC.Model.Prestamos elPrestamo)
        {
            try
            {

                ProyectoMVC.LogicaDeNegocios.CordinadorDePrestamos cordinadorDePrestamos = new LogicaDeNegocios.CordinadorDePrestamos();
                elPrestamo.dias = cordinadorDePrestamos.CalcularDias(elPrestamo.fechaDeDevolucion, elPrestamo.fechaDePrestamo);
                elPrestamo.montoDePrestamo = cordinadorDePrestamos.CalcularMontoPrestamo(elPrestamo.dias);
                elPrestamo.montoACancelar = cordinadorDePrestamos.CalcularMontoACancelar(elPrestamo.montoDePrestamo, elPrestamo.prima);
                string numeroDePlaca = elPrestamo.placaDelVehiculo;
                string cedulaDelCliente = elPrestamo.cedulaDelCliente;
                cordinadorDePrestamos.Editar(elPrestamo);
                cordinadorDePrestamos.ColocarEnFinalizado(id);

                ProyectoMVC.LogicaDeNegocios.CordinadorDeVehiculos cordinadorDeVehiculos = new LogicaDeNegocios.CordinadorDeVehiculos();
                int idVehiculo = cordinadorDeVehiculos.ObtenerIdVehiculoPorNumeroDePlaca(numeroDePlaca);
                cordinadorDeVehiculos.ColocarEnDisponible(idVehiculo);

                ProyectoMVC.LogicaDeNegocios.CordinadorDeClientes cordinadorDeClientes = new LogicaDeNegocios.CordinadorDeClientes();
                int idCliente = cordinadorDeClientes.ObtenerIdClientePorNumeroDeCedula(cedulaDelCliente);
                cordinadorDeClientes.ColocarEnDisponible(idCliente);

                return RedirectToAction("ListarPrestamos");
            }
            catch
            {
                return View();
            }
        }

       
    }
}
