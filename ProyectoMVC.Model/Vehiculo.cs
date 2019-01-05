using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMVC.Model
{
    public class Vehiculo
    {
        public int id { get; set; }
        public int numeroDePlaca { get; set; }
        public string modelo { get; set; }
        public string año { get; set; }
        public int estado { get; set; }
    }
}
