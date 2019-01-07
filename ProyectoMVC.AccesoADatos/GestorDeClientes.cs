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

        public int ObtenerIdPorNumeroDeCedula(string numeroDeCedula)
        {
            try
            {
                var db = new Context();

                IQueryable<int> resultado = from c in db.Clientes
                                            where c.cedula.Equals(numeroDeCedula)
                                            select c.id;

                return resultado.FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.Write(e);
                return 0;
            }
        }

        public List<Model.Clientes> ObtenerTodosLosClientes()
        {
            var db = new Context();
            var resultado = db.Clientes.Where(elEstado => elEstado.estado == 1 || elEstado.estado ==2).ToList();
            return resultado;
        }

        public List<Model.Clientes> ObtenerTodosLosDisponibles()
        {
            var db = new Context();
            var resultado = db.Clientes.Where(elEstado => elEstado.estado == 1).ToList();
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
