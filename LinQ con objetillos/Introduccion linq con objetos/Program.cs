using Introduccion_linq;
using System.Collections.Generic;

string[] palabras;
palabras = new string[] { "gato", "perro", "lagarto", "tortuga", "cocdrilo", "serpiente", "123456789" };
Console.WriteLine("Mas de 5 letras");

List<string> resultado = new List<string>();

foreach (string str in palabras)
{
    if (str.Length > 5)
    {
        resultado.Add(str);
    }
}
foreach (var r in resultado)
    Console.WriteLine(r);

#region utilizando Linq

Console.WriteLine("-----------------------------------------------------");
IEnumerable<string> list = from r in palabras where r.Length > 8 select r;
foreach (var listado in list)
    Console.WriteLine(listado);
Console.WriteLine("-----------------------------------------------------");
#endregion

List<Casa> ListaCasas = new List<Casa>();
List<Habitante> ListaHabitantes = new List<Habitante>();

//casita

#region listaCasa
ListaCasas.Add(new Casa
{
    Id = 1,
    Direccion = "3 av Norte ArcanCity",
    Ciudad = "Gothan City",
    numeroHabitantes = 20,
});

ListaCasas.Add(new Casa
{
    Id = 2,
    Direccion = "6 av Sur SmollVille",
    Ciudad = "Metropolis",
    numeroHabitantes = 5,
});

ListaCasas.Add(new Casa
{
    Id = 3,
    Direccion = "Forest Hills, Queens, NY 11375",
    Ciudad = "New York"
});
#endregion

//habitante

#region ListaHabitante
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Bruno Diaz",
    Edad = 36,
    IdCasa = 1
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 2,
    Nombre = "Clark Kent.",
    Edad = 40,
    IdCasa = 2
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 3,
    Nombre = "Peter Parker",
    Edad = 25,
    IdCasa = 3
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 3,
    Nombre = "Tia Mey",
    Edad = 85,
    IdCasa = 3
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 2,
    Nombre = "Luise Lain",
    Edad = 40,
    IdCasa = 2
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Selina Kyle",
    Edad = 30,
    IdCasa = 1
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Alfred",
    Edad = 36,
    IdCasa = 1
});
ListaHabitantes.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Nathan Drake",
    Edad = 36,
    IdCasa = 1
});
#endregion

//consultas where

#region SentenciasLinQ
IEnumerable<Habitante> ListaEdad = from ObjetoProvicional
                                   in ListaHabitantes
                                   where ObjetoProvicional.Edad > 40
                                   select ObjetoProvicional;

foreach (Habitante objetoProcicional2 in ListaEdad)
{
    Console.WriteLine(objetoProcicional2.datosHabitantes());
}
#endregion

//jugando con las tablas bajeras

#region IEnumerable
IEnumerable<Habitante> listaCasaGothan = from objetoTemporalHabitante in ListaHabitantes
                                         join objetoTemporalCasa in ListaCasas
                                         on objetoTemporalHabitante.IdHabitante equals objetoTemporalCasa.Id
                                         where objetoTemporalCasa.Ciudad == "Gothan City"
                                         select objetoTemporalHabitante;
Console.WriteLine("----------------------------------------------------------------------------------------------");
foreach (Habitante h in listaCasaGothan)
{
    Console.WriteLine(h.datosHabitantes());
}

#endregion

//santa cláusula elementAt

#region ElementAt
var terceraCasa = ListaCasas.ElementAt(2);
Console.WriteLine($"La tercera casa es {terceraCasa.dameDatosCasa()}");

var casaError = ListaCasas.ElementAtOrDefault(3);
if (casaError != null) { Console.WriteLine($"La tercera casa es {casaError.dameDatosCasa()}"); }

var segundoHabitante = (from objetoTem in ListaHabitantes select objetoTem).ElementAtOrDefault(2);
Console.WriteLine($" segundo habitante es : {segundoHabitante.datosHabitantes()}");
#endregion

//santa cláusula single

#region single
try
{
    var habitantes = ListaHabitantes.Single(variableTem => variableTem.Edad < 20);
    var habitante2 = (from obtem in ListaHabitantes where obtem.Edad > 70 select obtem).Single();

    Console.WriteLine($"habitante con menos de 20 años {habitantes.datosHabitantes()}");
    Console.WriteLine($"habitante con mas de 70 años {habitante2.datosHabitantes()}");

}
catch (Exception)
{
    Console.WriteLine($"Ocurrio el error");
}

#endregion

//santa cláusula OfType

#region typeOf
var listaEmpleados = new List<Empleado>() {
    new Medico(){ nombre= "Falcony Casa" },
    new Enfermero(){ nombre = "Josefino Blanco"}
};

var medico = listaEmpleados.OfType<Medico>();
Console.WriteLine(medico.Single().nombre);

#endregion