using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2P
{
    class Program
    {
        static void Main(string[] args)
        {

            float numero;
            int a = 0;

            System.Console.WriteLine("Inserta un valor");
            numero = float.Parse(System.Console.ReadLine());
            if (numero % 1 == 0)
            {
                System.Console.WriteLine("Es un numero entero");
            }
            else
                System.Console.WriteLine("Es una fraccion");
            for (int i = 0; i < numero; i++)
            {
                if (numero % 1 == 0)
                {
                    a++;
                }
            }
            if (a != 2)
            {
                System.Console.WriteLine(numero + " no es primo");
            }
            else
            {
                System.Console.WriteLine(numero + " es primo");
            }

            System.Console.ReadKey(true);
            System.Console.ReadLine();
        }
    }
}
