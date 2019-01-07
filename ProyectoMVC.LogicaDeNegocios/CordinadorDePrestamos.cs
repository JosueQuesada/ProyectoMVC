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

        public List<Model.Prestamos> ListarPrestamosEnProceso()
        {
            ProyectoMVC.AccesoADatos.GestorDePrestamos elGestor = new AccesoADatos.GestorDePrestamos();
            return elGestor.ObtenerPrestamoEnProceso();
        }

        public List<Model.Prestamos> ListarPrestamosFinalizados(string numeroDeCedula)
        {
            ProyectoMVC.AccesoADatos.GestorDePrestamos elGestor = new AccesoADatos.GestorDePrestamos();
            return elGestor.ObtenerPrestamoFinalizado(numeroDeCedula);
        }

        public void Agregar(ProyectoMVC.Model.Prestamos elNuevoPrestamo)
        {
            ProyectoMVC.AccesoADatos.GestorDePrestamos elGestor = new AccesoADatos.GestorDePrestamos();
            elNuevoPrestamo.estado = (byte)EstadoDePrestamo.enProceso;
            elGestor.Agregar(elNuevoPrestamo);
        }

        public void Editar(Model.Prestamos elPrestamo)
        {
            ProyectoMVC.AccesoADatos.GestorDePrestamos elGestor = new AccesoADatos.GestorDePrestamos();
            elGestor.Actualizar(elPrestamo);

        }

        public void ColocarEnFinalizado(int id)
        {
            ProyectoMVC.AccesoADatos.GestorDePrestamos elGestor = new AccesoADatos.GestorDePrestamos();
            ProyectoMVC.Model.Prestamos elPrestamo = new Model.Prestamos();

            elPrestamo = elGestor.ObtenerPrestamoPorId(id);
            elPrestamo.estado = (byte)EstadoDePrestamo.Finalizado;
            elGestor.CambioDeEstado(elPrestamo);
        }

        public int CalcularDias(DateTime fechaDePrestamo, DateTime fechaDeDevolucion) {
            int cantidadDeDias = 0;
            DateTime fechaMasAntigua = fechaDeDevolucion;
            DateTime fechaMasReciente = fechaDePrestamo;
            TimeSpan tSpan = fechaMasReciente - fechaMasAntigua;
            cantidadDeDias = tSpan.Days;
            return cantidadDeDias;
        }

        public double CalcularMontoPrestamo(int cantidadDeDias) {
            double montoDePrestamo = 0;
            int montoOficial = 10000;

            montoDePrestamo = montoOficial * cantidadDeDias;

            return montoDePrestamo;
        }

        public double CalcularMontoACancelar(double montoDePrestamo, double primaDePrestamo) {
            double montoACancelar = 0;
            montoACancelar = montoDePrestamo + primaDePrestamo;

            return montoACancelar;
        }
    }

}
