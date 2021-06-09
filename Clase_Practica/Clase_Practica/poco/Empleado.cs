using Clase_Practica.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Practica.poco
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public long Telefono { get; set; }
        public string Correo { get; set; }
        public Profesion Profesion { get; set; }
        public Cargo Cargo { get; set; }
        public decimal Salario { get; set; }
    }
}
