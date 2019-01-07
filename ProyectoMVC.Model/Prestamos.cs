using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMVC.Model
{
    public class Prestamos
    {
        public int id { get; set; }
        [DisplayName("Cédula del cliente")]
        public string cedulaDelCliente { get; set; }
        [DisplayName("Placa del vehículo")]
        public string placaDelVehiculo { get; set; }
        [DisplayName("Fecha de prestamo")]
        [DataType(DataType.Date)]
        public DateTime fechaDePrestamo { get; set; }
        [DisplayName("Fecha de devolución")]
        [DataType(DataType.Date)]
        public DateTime fechaDeDevolucion { get; set; }
        [DisplayName("Cantidad de días")]
        public int dias { get; set; }
        [DisplayName("Monto")]
        public Double montoDePrestamo { get; set; }
        [DisplayName("Prima")]
        public Double prima { get; set; }
        [DisplayName("A cancelar")]
        public Double montoACancelar { get; set; }
        [DisplayName("Monto")]
        public int estado { get; set; }
    }
}
