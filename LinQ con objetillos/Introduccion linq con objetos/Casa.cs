using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduccion_linq
{
  public class Casa
    { 
    public int Id { get; set; }
    public string Direccion { get; set; }

    public string Ciudad {  get; set; }

    public int numeroHabitantes { get; set; }

    public string dameDatosCasa ()
        {
            return $"Dirección es {Direccion} en la ciudad de {Ciudad} con un número de habitantes de {numeroHabitantes}";
        }
    }
}
