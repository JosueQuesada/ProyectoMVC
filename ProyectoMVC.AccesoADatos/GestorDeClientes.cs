using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMVC.AccesoADatos
{
   public class GestorDeClientes
    {
        public Model.Clientes ObtenerClientePorId(int id)
        {
            var db = new Context();
            var resultado = db.Clientes.Find(id);

            return resultado;
        }

        public List<Model.Clientes> ObtenerTodosLosClientes()
        {
            var db = new Context();
            var resultado = db.Clientes.ToList();
            return resultado;
        }

        public void Agregar(Model.Clientes elNuevoCliente)
        {
            var db = new Context();
            db.Clientes.Add(elNuevoCliente);
            db.Entry(elNuevoCliente).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();

        }
     
        public void Actualizar(Model.Clientes elCliente)
        {
            var clienteEnBaseDeDatos = ObtenerClientePorId(elCliente.id);

            clienteEnBaseDeDatos.pais = elCliente.pais;
            clienteEnBaseDeDatos.telefono = elCliente.telefono;


            var db = new Context();
            db.Entry(clienteEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void CambioDeEstado(Model.Clientes elCliente)
        {
            var clienteEnBaseDeDatos = ObtenerClientePorId(elCliente.id);

            clienteEnBaseDeDatos.estado = elCliente.estado;


            var db = new Context();
            db.Entry(clienteEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
