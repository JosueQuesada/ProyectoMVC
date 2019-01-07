using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMVC.LogicaDeNegocios
{
    public class CordinadorDeVehiculos
    {
        public Model.Vehiculo ObternerVehiculoPorId(int id)
        {
            ProyectoMVC.AccesoADatos.GestorDeVehiculos elGestor = new AccesoADatos.GestorDeVehiculos();

            return elGestor.ObtenerVehiculoPorId(id);
        }

        public int ObtenerIdVehiculoPorNumeroDePlaca(String numeroDePlaca)
        {


            ProyectoMVC.AccesoADatos.GestorDeVehiculos gestorDeVehiculos = new AccesoADatos.GestorDeVehiculos();
            int idVehiculo = 0;

            idVehiculo = gestorDeVehiculos.ObtenerIdPorNumeroDePlaca(numeroDePlaca);
            return idVehiculo;


        }

        public List<Model.Vehiculo> ListarVehiculos()
        {
            ProyectoMVC.AccesoADatos.GestorDeVehiculos elGestor = new AccesoADatos.GestorDeVehiculos();
            return elGestor.ObtenerTodosLosVehiculos();
        }
        public List<Model.Vehiculo> ListarVehiculosDisponibles()
        {
            ProyectoMVC.AccesoADatos.GestorDeVehiculos elGestor = new AccesoADatos.GestorDeVehiculos();
            return elGestor.ObtenerTodosLosVehiculosDisponibles();
        }


        public void Agregar(ProyectoMVC.Model.Vehiculo elNuevoVehiculo)
        {
            ProyectoMVC.AccesoADatos.GestorDeVehiculos elGestor = new AccesoADatos.GestorDeVehiculos();
            elNuevoVehiculo.estado = (byte)EstadoDelVehiculo.Disponible;
            elGestor.Agregar(elNuevoVehiculo);
        }
        public void ColocarEnDisponible(int id)
        {
            ProyectoMVC.AccesoADatos.GestorDeVehiculos elGestor = new AccesoADatos.GestorDeVehiculos();
            ProyectoMVC.Model.Vehiculo elVehiculo = new Model.Vehiculo();

            elVehiculo = elGestor.ObtenerVehiculoPorId(id);
            elVehiculo.estado = (byte)EstadoDelCliente.Disponible;
            elGestor.CambioDeEstado(elVehiculo);
        }

        public void ColocarEnPrestamo(int id)
        {
            ProyectoMVC.AccesoADatos.GestorDeVehiculos elGestor = new AccesoADatos.GestorDeVehiculos();
            ProyectoMVC.Model.Vehiculo elVehiculo = new Model.Vehiculo();

            elVehiculo = elGestor.ObtenerVehiculoPorId(id);
            elVehiculo.estado = (byte)EstadoDelCliente.conPrestamo;
            elGestor.CambioDeEstado(elVehiculo);
        }

        public void ColocarEnEliminado(int id)
        {
            ProyectoMVC.AccesoADatos.GestorDeVehiculos elGestor = new AccesoADatos.GestorDeVehiculos();
            ProyectoMVC.Model.Vehiculo elVehiculo = new Model.Vehiculo();

            elVehiculo = elGestor.ObtenerVehiculoPorId(id);
            elVehiculo.estado = (byte)EstadoDelCliente.eliminado;
            elGestor.CambioDeEstado(elVehiculo);
        }
    }
}
