using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMVC.LogicaDeNegocios
{
   public class CordinadorDePrestamos
    {
        public Model.Prestamos ObternerPrestamoPorId(int id)
        {
            ProyectoMVC.AccesoADatos.GestorDePrestamos elGestor = new AccesoADatos.GestorDePrestamos();

            return elGestor.ObtenerPrestamoPorId(id);
        }


        public List<Model.Prestamos> ListarPrestamos()
        {
            ProyectoMVC.AccesoADatos.GestorDePrestamos elGestor = new AccesoADatos.GestorDePrestamos();
            return elGestor.ObtenerTodosLosPrestamos();
        }
        public void Agregar(ProyectoMVC.Model.Prestamos elNuevoPrestamo)
        {
            ProyectoMVC.AccesoADatos.GestorDePrestamos elGestor = new AccesoADatos.GestorDePrestamos();
            elNuevoPrestamo.estado = (byte)EstadoDePrestamo.enProceso;
            elGestor.Agregar(elNuevoPrestamo);
        }

        public void ColocarEnFinalizado(int id)
        {
            ProyectoMVC.AccesoADatos.GestorDePrestamos elGestor = new AccesoADatos.GestorDePrestamos();
            ProyectoMVC.Model.Prestamos elPrestamo = new Model.Prestamos();

            elPrestamo = elGestor.ObtenerPrestamoPorId(id);
            elPrestamo.estado = (byte)EstadoDePrestamo.Finalizado;
            elGestor.CambioDeEstado(elPrestamo);
        }
    }
}
