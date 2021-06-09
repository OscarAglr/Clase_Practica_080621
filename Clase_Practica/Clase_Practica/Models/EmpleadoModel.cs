using Clase_Practica.poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Practica.Models
{
    public class EmpleadoModel
    {
        private static Empleado[] empleados;

        public EmpleadoModel()
        {

        }

        public void AddEmpleado(Empleado e)
        {
            if (empleados == null)
            {
                empleados = new Empleado[1];
                empleados[0] = e;
                return;
            }
            Empleado[] tmp = new Empleado[empleados.Length + 1];
            Array.Copy(empleados, tmp, empleados.Length);

            tmp[tmp.Length - 1] = e;
            empleados = tmp;
        }

        public void Remove(int index)
        {
            if (empleados == null)
            {
                return;
            }

            if (index < 0 || index >= empleados.Length)
            {
                throw new IndexOutOfRangeException($"El indice {index} esta fuera de rango.");
            }

            if (empleados.Length == 1 && index == 0)
            {
                empleados = null;
                return;
            }

            Empleado[] tmp = new Empleado[empleados.Length - 1];
            if (index == empleados.Length - 1)
            {
                Array.Copy(empleados, 0, tmp, 0, tmp.Length);
                empleados = tmp;
                return;
            }

            if (index == 0)
            {
                Array.Copy(empleados, index + 1, tmp, 0, tmp.Length);
                empleados = tmp;
                return;
            }

            Array.Copy(empleados, 0, tmp, 0, index);
            Array.Copy(empleados, index + 1, tmp, index, tmp.Length - index);
            empleados = tmp;
        }

        public void Update()
        {
            // TO DO
        }

        public Empleado[] GetAll()
        {
            return empleados;
        }
    }
}
