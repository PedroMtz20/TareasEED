using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidencia3Metodos
{
    class Program
    {
        //Pedro Elias Martinez Rodriguez 2777376
        //Evidencia 3 del curso de metodos numéricos
        static void Main(string[] args)
        {
            //Primero se saca la aceleracion con los datos correspondientes por caso
            //90 = (15) *(5) + 1 / 2 * (a) * (25)
            //90 = 75 + 12.5a
            //13 = 12.5a
            //13/12.5 = a
            double vf,t;
            double a = 13 / 12.5;
            //Caso 1 (100 metros):
            t = Math.Sqrt(200 / a);
            vf = 15 + (a * t);
            System.Console.WriteLine("Para una distancia de 100 metros se tiene una velocidad final de: " + vf + " con un tiempo de " + t +" segundos");
            //Caso 2(150 metros):
            t = Math.Sqrt(300 / a);
            vf = 15 + (a * t);
            System.Console.WriteLine("Para una distancia de 150 metros se tiene una velocidad final de: " + vf + " con un tiempo de " + t + " segundos");
            //Caso 3(250 metros):
            t = Math.Sqrt(500/ a);
            vf = 15 + (a * t);
            System.Console.WriteLine("Para una distancia de 250 metros se tiene una velocidad final de: " + vf + " con un tiempo de " + t + " segundos");
            //Caso 4(300 metros)
            t = Math.Sqrt(600 / a);
            vf = 15 + (a * t);
            System.Console.WriteLine("Para una distancia de 300 metros se tiene una velocidad final de: " + vf + " con un tiempo de " + t + " segundos");
            System.Console.ReadLine();
        }
    }
}
