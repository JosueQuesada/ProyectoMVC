using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMVC.Model
{
    public class Vehiculo
    {
        public int id { get; set; }
        [DisplayName("Número de placa")]
        public string numeroDePlaca { get; set; }
        [DisplayName("Modelo")]
        public string modelo { get; set; }
        [DisplayName("Año")]
        public string año { get; set; }
        [DisplayName("Estado")]
        public int estado { get; set; }
    }
}
