using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad13_Metodos
{
    class Program
    {
        //Pedro Elias Martinez Rodriguez 2777376
        //Actividad 12 del curso de metodos numericos
        //Actividad que busca familiarizar con las integrales numericas
        static void Main(string[] args)
        {
            //El primer programa debe encontrar el valor de la integral:    
            //De x = -23 hasta x = 23 por una integral de Simpson de 1020 elementos.
            double base_rectangulo, altura_1, altura_2, altura_3, altura_total, x, area_real = 0;
            double partes = 1020, area = 0, area2, partes_2 = 0;
            double lim_inferior = -23, lim_superior = 23;

            base_rectangulo = (lim_superior - lim_inferior) / partes;

            x = lim_inferior;
                
            while (x < lim_superior)
            {
                altura_1 = (Math.Atan(x) * 180 / Math.PI) / x - 2; 
                x = x + base_rectangulo / 2;
                altura_2 = (Math.Atan(x) * 180 / Math.PI) / x - 2;
                x = x + base_rectangulo / 2;
                altura_3 = (Math.Atan(x) * 180 / Math.PI) / x - 2;

                altura_total = (altura_1 + 4 * altura_2 + altura_3) / 6;
                area = area + (base_rectangulo) * altura_total;
            }

            Console.WriteLine("El valor del area con 1020 partes es " + area);
            area2 = area;

            //Segundo programa
            //Busca un 99.99% de certeza con varias integrales en las que varian sus parte
            double diferencia = 100000;
            //ciclo del progrma
            while (partes != 10000)
            {
                //se inicializa la variable area
                area = 0;
                //condicionales para cambiar el numero de partes
                if (partes == 1020)
                    partes = 2;
                else if (partes == 2)
                    partes = 5;
                else if (partes == 5)
                    partes = 10;
                else if (partes == 10)
                    partes = 20;
                else if (partes == 20)
                    partes = 100;
                else if (partes == 100)
                    partes = 5000;
                else if (partes == 5000)
                    partes = 10000;


                base_rectangulo = (lim_superior - lim_inferior) / partes;

                x = lim_inferior;

                while (x < lim_superior)
                {
                    altura_1 = (Math.Atan(x) * 180 / Math.PI) / x - 2;
                    x = x + base_rectangulo / 2;
                    altura_2 = (Math.Atan(x) * 180 / Math.PI) / x - 2;
                    x = x + base_rectangulo / 2;
                    altura_3 = (Math.Atan(x) * 180 / Math.PI) / x - 2;

                    altura_total = (altura_1 + 4 * altura_2 + altura_3) / 6;
                    area = area + (base_rectangulo) * altura_total;
                }
                //si la diferencia anterior es mayor que la diferencia actual entonces el area actual se acerca mas al 99.99% de certeza
                if (diferencia > Math.Abs(area2 - area)) {
                    diferencia = Math.Abs(area2 - area);
                    //Se almacena el numero de partes y el area con el mayor grado de certeza
                    partes_2 = partes;
                    area_real = area;
                 }

                Console.WriteLine("El valor del area con " + partes + " partes es " + area);
                
            }
            
            Console.WriteLine("El numero de partes con mayor certeza es " + partes_2 + " con una area de " + area_real);

            Console.ReadLine();
        }
    }
}
