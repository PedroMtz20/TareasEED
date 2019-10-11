using System;

namespace Tarea12_Metodos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pedro Elias Martinez Rodriguez 2777376
            //Gerardo Manuel Hinojosa Garza 2735799
            //Tarea 12 del curso de Metodos Numericos
            //Busca fam iliarizar con las integrales numericas

            //Metodo de Euler
            //Se declaran las variables acorde al problema
            double y, yy;
            double x = 0, paso = 1;

            y = 2;
            //ciclo que continuara hasta que paso sea igual a 0
            while (paso != 0)
            {
                //se reinician las variables
                x = 0;
                y = 2;
                //ciclo que continuara hasta que x sea igual a 7
                while (x < 7)
                {
                    yy = (-5 * y * Math.Sin(x)) + (5 * y * Math.Cos(x)) - Math.Cos(x);

                    y = y + yy * paso;

                    x = x + paso;
                }

                //Se imprime el resultado con el numero de pasos
                Console.WriteLine("El valor de y cuando x es " + x + " es " + y + " con pasos de " + paso);
                //Se cambia dinamicamente el numero de pasos
                if (paso == 1)
                    paso = .4;
                else if (paso == .4)
                    paso = .2;
                else if (paso == .2)
                    paso = .02;
                else if (paso == .02)
                    paso = .002;
                else if (paso == .002)
                    paso = 0;

            }

            //Se cambia al segundo metodo
            Console.WriteLine("Metodo de Runge-Kutta ");

            double k1, k2, k3, k4;

            //se vuelven a declarar las variables
            x = 0;
            y = 2;
            paso = 1;

            //ciclo que continuara hasta que paso sea igual a 0
            while (paso != 0)
            {
                //Se reinicianl las variables
                y = 2;
                x = 0;
                //ciclo que continuara hasta que x sea igual a 7
                while (x < 7)
                {
                    k1 = -1 * Math.Sin(x) + ((5 * y) * (Math.Cos(x)));

                    k2 = -1 * Math.Sin(x + paso) + (5 * (y + k1 * paso)) * (Math.Cos(x + paso));
                    k3 = -1 * Math.Sin(x + paso) + (5 * (y + k2 * paso)) * (Math.Cos(x + paso));

                    k4 = -1 * Math.Sin(x + paso) + (5 * (y + k3 * paso)) * (Math.Cos(x + paso));

                    y = y + (k1 + 2 * k2 + 2 * k3 + k4) * paso / 6;

                    x = x + paso;
                }
                //Se imprime el resultado con el numero de pasos
                Console.WriteLine("El valor de y cuando x es " + x + " es " + y + " con pasos de " + paso);
                //Se cambia dinamicamente el numero de pasos
                if (paso == 1)
                    paso = .4;
                else if (paso == .4)
                    paso = .2;
                else if (paso == .2)
                    paso = .02;
                else if (paso == .02)
                    paso = .002;
                else if (paso == .002)
                    paso = 0;
            }

            Console.ReadLine();
        }
    }
}