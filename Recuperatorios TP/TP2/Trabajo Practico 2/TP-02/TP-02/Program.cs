using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_2018;


namespace TP_02_2018
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuración de la pantalla
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight - 2);

            // Nombre del alumno
            Console.WriteLine("Matias Palmieri");

            Changuito changoDeCompras = new Changuito(6);

            Dulce c1 = new Dulce(Producto.EMarca.Sancor, "ASD012", ConsoleColor.Black);
            Dulce c2 = new Dulce(Producto.EMarca.Ilolay, "ASD913", ConsoleColor.Red);
            Leche m1 = new Leche(Producto.EMarca.Pepsico, "HJK789", ConsoleColor.White);
            Leche m2 = new Leche(Producto.EMarca.Serenisima, "IOP852", ConsoleColor.Blue, Leche.ETipo.Descremada);
            Snacks a1 = new Snacks(Producto.EMarca.Campagnola, "QWE968", ConsoleColor.Gray);
            Snacks a2 = new Snacks(Producto.EMarca.Arcor, "TYU426", ConsoleColor.DarkBlue);
            Snacks a3 = new Snacks(Producto.EMarca.Sancor, "IOP852", ConsoleColor.Green);
            Snacks a4 = new Snacks(Producto.EMarca.Sancor, "TRE321", ConsoleColor.Green);

            // Agrego 8 ítems (los últimos 2 no deberían poder agregarse ni el m1 repetido) y muestro
            changoDeCompras = changoDeCompras + c1;
            changoDeCompras = changoDeCompras + c2;
            changoDeCompras = changoDeCompras + m1;
            changoDeCompras = changoDeCompras + m1;
            changoDeCompras = changoDeCompras + m2;
            changoDeCompras = changoDeCompras + a1;
            changoDeCompras = changoDeCompras + a2;
            changoDeCompras = changoDeCompras + a3;
            changoDeCompras = changoDeCompras + a4;
            
            Console.WriteLine(changoDeCompras.ToString()); ///Preguntar si asi como lo hice esta bien onda si busca eso o que busca
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Quito un item y muestro
            changoDeCompras -= c1;

            Console.WriteLine(changoDeCompras.ToString());
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Muestro solo Dulces
            Console.WriteLine(changoDeCompras.Mostrar(changoDeCompras, Changuito.ETipo.Dulce));
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Muestro solo Leches
            Console.WriteLine(changoDeCompras.Mostrar(changoDeCompras, Changuito.ETipo.Leche));
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Muestro solo Snacks
            Console.WriteLine(changoDeCompras.Mostrar(changoDeCompras, Changuito.ETipo.Snacks));
            Console.WriteLine("<-------------PRESIONE UNA TECLA PARA SALIR------------->");
            Console.ReadKey();
            Console.Clear();

            //aca abajo pruebo el casteo explicito  de producto a string

            Console.WriteLine((string)c1);
            Console.WriteLine((string)m1);
            Console.WriteLine((string)a2);
            Console.ReadKey();
        }
    }
}
