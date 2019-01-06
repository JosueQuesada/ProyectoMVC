using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMVC.AccesoADatos
{
  public class GestorDeVehiculos
    {

        public Model.Vehiculo ObtenerVehiculoPorId(int id)
        {
            var db = new Context();
            var resultado = db.Vehiculo.Find(id);

            return resultado;
        }

        public List<Model.Vehiculo> ObtenerTodosLosVehiculos()
        {
            var db = new Context();
            var resultado = db.Vehiculo.ToList();
            return resultado;
        }

        public void Agregar(Model.Vehiculo elNuevoVehiculo)
        {
            var db = new Context();
            db.Vehiculo.Add(elNuevoVehiculo);
            db.Entry(elNuevoVehiculo).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();

        }

        public void CambioDeEstado(Model.Vehiculo elVehiculo)
        {
            var vehiculoEnBaseDeDatos = ObtenerVehiculoPorId(elVehiculo.id);

            vehiculoEnBaseDeDatos.estado = elVehiculo.estado;


            var db = new Context();
            db.Entry(vehiculoEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
