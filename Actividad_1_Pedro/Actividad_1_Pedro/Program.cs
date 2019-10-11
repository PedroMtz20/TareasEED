using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actividad_1_Pedro
{
    class Program
    {
        static void Main(string[] args)
        {

            int valor_1, valor_2, valor_3, valor_4;
            int operacion_1, operacion_2, operacion_3, operacion_4;
            bool compara_1, compara_2, compara_3, compara_4, compara_5, compara_6; 

            System.Console.WriteLine("Inserta valor del numero 1");
            valor_1 = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Inserta valor del numero 2");
            valor_2 = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Inserta valor del numero 3");
            valor_3 = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Inserta valor del numero 4");
            valor_4 = int.Parse(System.Console.ReadLine());

            operacion_1 = (valor_1 + valor_2 + valor_3 + valor_4);
            operacion_2 = (valor_1 * valor_2 * valor_3 * valor_4);
            operacion_3 = ((valor_1 / valor_2) + (valor_3 / valor_4));
            operacion_4 = (operacion_1 / operacion_2);

            compara_1 = valor_1 != valor_3;
            compara_2 = valor_2 == valor_4;
            compara_3 = (valor_1 > valor_3) || (valor_1 > valor_4);
            compara_4 = valor_2 < operacion_3;
            compara_5 = compara_1 && compara_2;
            compara_6 = compara_3 || compara_4;

            Console.WriteLine("Suma de todos los valores: " + operacion_1);
            Console.WriteLine("Multiplicacion de todos los valores: " + operacion_2);
            Console.WriteLine("Suma de division entre valor 1 y 2 y entre 3 y 4: " + operacion_3);
            Console.WriteLine("Division entre operacion 1 y 2: " + operacion_4);

            Console.WriteLine("Valor 1 distinto del 3: " + compara_1);
            Console.WriteLine("Valor 2 igual al 4: " + compara_2);
            Console.WriteLine("Valor 1 mayor que 3 o que 4: " + compara_3);
            Console.WriteLine("Valor 2 menor que operacion 3: " + compara_4);
            Console.WriteLine("Comparacion 1 y 2 son correctas: " + compara_5);
            Console.WriteLine("Comparacion 3 y 4 son correctas: " + compara_6);
            System.Console.ReadKey(true);
            System.Console.ReadLine();
        }
    }
}
