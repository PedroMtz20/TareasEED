using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Act14_Metodos
{
    class Program
    {
        //Pedro Elias Martinez Rodrigez 2777376
        //Actividad 14 del curso de metodos numericos

        //Primer Programa
        static void Main(string[] args) 
        {
            //Se declaran las variables acorde al problema
            double y, yy;
            double x = 2, paso = 0.001;

            y = 7.6;

            //ciclo que continuara hasta que x sea igual a 9
            while (x < 9)
            {
                yy = x * x + 3 * x + 5;

                y = y + yy * paso;

                x = x + paso;

            }

            //Se imprime el resultado
            Console.WriteLine("El valor de y cuando x es " + x + " es " + y + " con el primer metodo");

            //Segundo programa
            double k1, k2, k3, k4;

            //se vuelven a declarar las variables
            x = 2;
            y = -5.6;
            paso = .001;    

            //ciclo que continuara hasta que x sea igual a 12
            while (x < 12)
            {
                k1 = -1 * Math.Sin(x) + ( (5 * y)*(Math.Cos(x)));

                k2 = -1 * Math.Sin(x + paso) + (5 * (y + k1 * paso)) * (Math.Cos(x + paso));
                k3 = -1 * Math.Sin(x + paso) + (5 * (y + k2 * paso)) * (Math.Cos(x + paso));

                k4 = -1 * Math.Sin(x + paso) + (5 * (y + k3 * paso)) * (Math.Cos(x + paso));

                y = y + (k1 + 2 * k2 + 2 * k3 + k4) * paso / 6;

                x = x + paso;
            }

            //Se imprime el segundo resultado
            Console.WriteLine("El valor de y cuando x es " + x + " es " + y + " con el segundo metodo");

            Console.ReadLine();

        }
    }
}
