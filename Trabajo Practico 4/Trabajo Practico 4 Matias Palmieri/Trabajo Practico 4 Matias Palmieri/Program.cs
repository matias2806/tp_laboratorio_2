using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Trabajo_Practico_4_Matias_Palmieri
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "matias prueba de guardado con metodo de extension";
            a.Guardar("matiprueba.txt");
            Console.ReadKey();
        }
    }
}
