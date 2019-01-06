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


        public List<Model.Vehiculo> ListarVehiculos()
        {
            ProyectoMVC.AccesoADatos.GestorDeVehiculos elGestor = new AccesoADatos.GestorDeVehiculos();
            return elGestor.ObtenerTodosLosVehiculos();
        }
        public void Agregar(ProyectoMVC.Model.Vehiculo elNuevoVehiculo)
        {
            ProyectoMVC.AccesoADatos.GestorDeVehiculos elGestor = new AccesoADatos.GestorDeVehiculos();
            elNuevoVehiculo.estado = (byte)EstadoDelVehiculo.Disponible;
            elGestor.Agregar(elNuevoVehiculo);
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
