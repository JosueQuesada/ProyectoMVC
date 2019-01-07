using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMVC.AccesoADatos
{
   public class GestorDePrestamos
    {

        public Model.Prestamos ObtenerPrestamoPorId(int id)
        {
            var db = new Context();
            var resultado = db.Prestamos.Find(id);

            return resultado;
        }

        public List<Model.Prestamos> ObtenerTodosLosPrestamos()
        {
            var db = new Context();
            var resultado = db.Prestamos.ToList();
            return resultado;
        }

        public List<Model.Prestamos> ObtenerPrestamoEnProceso()
        {
            var db = new Context();
            var resultado = db.Prestamos.Where(elEstado => elEstado.estado == 1).ToList();
            return resultado;
        }

        public List<Model.Prestamos> ObtenerPrestamoFinalizado(String numeroDeCedula)
        {
            try
            {
                var db = new Context();
                var resultado = db.Prestamos.Where(elEstado => elEstado.estado == 2 && elEstado.cedulaDelCliente.Equals(numeroDeCedula)).ToList();
                return resultado;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }

        public void Agregar(Model.Prestamos elNuevoPrestamo)
        {
            var db = new Context();
            db.Prestamos.Add(elNuevoPrestamo);
            db.Entry(elNuevoPrestamo).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();

        }

        public void Actualizar(Model.Prestamos elPrestamo)
        {
            var prestamoEnBaseDeDatos = ObtenerPrestamoPorId(elPrestamo.id);

            prestamoEnBaseDeDatos.fechaDeDevolucion = elPrestamo.fechaDeDevolucion;
            prestamoEnBaseDeDatos.dias = elPrestamo.dias;
            prestamoEnBaseDeDatos.montoACancelar = elPrestamo.montoACancelar;
            prestamoEnBaseDeDatos.montoDePrestamo = elPrestamo.montoDePrestamo;

            var db = new Context();
            db.Entry(prestamoEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void CambioDeEstado(Model.Prestamos elPrestamo)
        {
            var prestamoEnBaseDeDatos = ObtenerPrestamoPorId(elPrestamo.id);

            prestamoEnBaseDeDatos.estado = elPrestamo.estado;


            var db = new Context();
            db.Entry(prestamoEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
