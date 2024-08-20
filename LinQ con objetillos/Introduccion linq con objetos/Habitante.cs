using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduccion_linq
{
    public class Habitante
    {
        public int IdHabitante { get; set; }

        public string Nombre { get; set; }

        public int Edad { get; set; }

        public int IdCasa { get; set; }

        public string datosHabitantes()
        {
            return $"soy {Nombre} con edad de {Edad} años vividos en {IdCasa}";
        }

    }
}
