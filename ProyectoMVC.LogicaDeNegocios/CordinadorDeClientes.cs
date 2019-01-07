using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMVC.LogicaDeNegocios
{
   public class CordinadorDeClientes
    {
        public Model.Clientes ObternerClientePorId(int id)
        {
            ProyectoMVC.AccesoADatos.GestorDeClientes elGestor = new AccesoADatos.GestorDeClientes();

            return elGestor.ObtenerClientePorId(id);
        }

        public int ObtenerIdClientePorNumeroDeCedula(String numeroDeCedula) {


            ProyectoMVC.AccesoADatos.GestorDeClientes gestorDeClientes = new AccesoADatos.GestorDeClientes();
            int idCliente = 0;

            idCliente = gestorDeClientes.ObtenerIdPorNumeroDeCedula(numeroDeCedula);
            return idCliente;


        }
        public List<Model.Clientes> ListarClientes()
        {
            ProyectoMVC.AccesoADatos.GestorDeClientes elGestor = new AccesoADatos.GestorDeClientes();
            return elGestor.ObtenerTodosLosClientes();
        }

        public List<Model.Clientes> ListarClientesDisponibles()
        {
            ProyectoMVC.AccesoADatos.GestorDeClientes elGestor = new AccesoADatos.GestorDeClientes();
            return elGestor.ObtenerTodosLosDisponibles();
        }
        public void Agregar(ProyectoMVC.Model.Clientes elNuevoCliente)
        {
            ProyectoMVC.AccesoADatos.GestorDeClientes elGestor = new AccesoADatos.GestorDeClientes();
            elNuevoCliente.estado = (byte) EstadoDelCliente.Disponible;
            elGestor.Agregar(elNuevoCliente);
        }
        public void Editar(Model.Clientes elCliente)
        {
            ProyectoMVC.AccesoADatos.GestorDeClientes elGestor = new AccesoADatos.GestorDeClientes();
            elGestor.Actualizar(elCliente);

        }

        public void ColocarEnDisponible(int id)
        {
            ProyectoMVC.AccesoADatos.GestorDeClientes elGestor = new AccesoADatos.GestorDeClientes();
            ProyectoMVC.Model.Clientes elCliente = new Model.Clientes();

            elCliente = elGestor.ObtenerClientePorId(id);
            elCliente.estado = (byte)EstadoDelCliente.Disponible;
            elGestor.CambioDeEstado(elCliente);
        }
        public void ColocarEnPrestamo(int id)
        {
            ProyectoMVC.AccesoADatos.GestorDeClientes elGestor = new AccesoADatos.GestorDeClientes();
            ProyectoMVC.Model.Clientes elCliente = new Model.Clientes();

            elCliente = elGestor.ObtenerClientePorId(id);
            elCliente.estado = (byte) EstadoDelCliente.conPrestamo;
            elGestor.CambioDeEstado(elCliente);
        }

        public void ColocarEnEliminado(int id)
        {
            ProyectoMVC.AccesoADatos.GestorDeClientes elGestor = new AccesoADatos.GestorDeClientes();
            ProyectoMVC.Model.Clientes elCliente = new Model.Clientes();

            elCliente = elGestor.ObtenerClientePorId(id);
            elCliente.estado = (byte)EstadoDelCliente.eliminado;
            elGestor.CambioDeEstado(elCliente);
        }
    }
}
