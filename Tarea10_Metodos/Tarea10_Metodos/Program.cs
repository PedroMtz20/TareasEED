using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea10_Metodos
{
    class Program
    {
        //Pedro Elias Martinez Rodriguez 2777376
        //Gerardo Manuel Hinojosa Garza 2735799
        //Tarea 10 del curso de Metodos Numericos
        //Busca familiariza con las integrales numericas
        static void Main(string[] args)
        {
            double base_rectangulo, altura_1, altura_2, altura_total, x;
            double partes = 9500, area = 0;
            double lim_inferior, lim_superior;

            Console.WriteLine("Dime el primer limite");
            lim_inferior = double.Parse(Console.ReadLine());


            Console.WriteLine("Dime el segundo limite");
            lim_superior = double.Parse(Console.ReadLine());

            if (lim_inferior > lim_superior)
            {
                double temp = lim_superior;
                lim_superior = lim_inferior;
                lim_inferior = temp;
            }

                base_rectangulo = (lim_superior - lim_inferior) / partes;

            x = lim_inferior;

            while (x < lim_superior)
            {
                altura_1 = Math.Exp(Math.Pow(x,-2));
                x = x + base_rectangulo;
                altura_2 = Math.Exp(Math.Pow(x, -2));
                altura_total = (altura_1 + altura_2) / 2;

                area = area + base_rectangulo * altura_total;

            }
            Console.WriteLine("El valor del area es " + area);
            Console.ReadLine();
        }
    }
}
