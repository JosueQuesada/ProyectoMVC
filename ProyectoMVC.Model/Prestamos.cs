using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMVC.Model
{
    public class Prestamos
    {
        public int id { get; set; }
        public string cedulaDelCliente { get; set; }
        public string placaDelVehiculo { get; set; }
        public DateTime fechaDePrestamo { get; set; }
        public DateTime fechaDeDevolucion { get; set; }
        public int dias { get; set; }
        public Double montoDePrestamo { get; set; }
        public Double prima { get; set; }
        public Double montoACancelar { get; set; }
        public int estado { get; set; }
    }
}
