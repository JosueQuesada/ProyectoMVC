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


        public List<Model.Clientes> ListarClientes()
        {
            ProyectoMVC.AccesoADatos.GestorDeClientes elGestor = new AccesoADatos.GestorDeClientes();
            return elGestor.ObtenerTodosLosClientes();
        }
        public void Agregar(ProyectoMVC.Model.Clientes elNuevoCliente)
        {
            ProyectoMVC.AccesoADatos.GestorDeClientes elGestor = new AccesoADatos.GestorDeClientes();
           // elNuevoCliente.estado = (byte) EstadoDelCliente.Disponible;
            elGestor.Agregar(elNuevoCliente);
        }
        public void Editar(Model.Clientes elCliente)
        {
            ProyectoMVC.AccesoADatos.GestorDeClientes elGestor = new AccesoADatos.GestorDeClientes();
            elGestor.Actualizar(elCliente);

        }
        public void ColocarEnPrestamo(int id)
        {
            ProyectoMVC.AccesoADatos.GestorDeClientes elGestor = new AccesoADatos.GestorDeClientes();
            ProyectoMVC.Model.Clientes elCliente = new Model.Clientes();

            elCliente = elGestor.ObtenerClientePorId(id);
           // elCliente.estado = (byte) EstadoDelCliente.conPrestamo;
            elGestor.CambioDeEstado(elCliente);
        }
    }
}
