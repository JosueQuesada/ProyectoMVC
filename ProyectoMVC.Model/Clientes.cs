using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProyectoMVC.Model
{
    public class Clientes
    {
        public int id { get; set; }
        [DisplayName("Cédula")]
        public string cedula { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Apellido")]
        public string apellido { get; set; }
        [DisplayName("Teléfono")]
        public string telefono { get; set; }
        [DisplayName("Correo Electronico")]
        public string correo { get; set; }
        [DisplayName("Pais")]
        public string pais { get; set; }
        [DisplayName("Estado")]
        public int estado { get; set; }
    }
}
