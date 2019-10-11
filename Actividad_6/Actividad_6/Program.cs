using System;


namespace Actividad_6
{
    class Program
    {
        //Pedro Elias Martinez Rodriguez
        //Actividad 6 Metodos numericos
        //Programa que utiliza el metodo de gauss
        static void Main(string[] args)
        {

            double[,] matriz = new double[4, 5];
            double pivote, factor;
            //Se insertan los valores en la matriz
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    System.Console.WriteLine("Inserta el valor en la posicion [" + (i + 1) + "],[" + (j + 1) + "]");
                    matriz[i, j] = double.Parse(System.Console.ReadLine());
                }
            }

            for (int reng = 0; reng < 4; reng = reng + 1)
            {
                //Selecciona el elemento diagonal como pivote
                pivote = matriz[reng, reng];

                //Divide todo el renglón entre el pivote
                for (int colu = 0; colu < 5; colu = colu + 1)
                {
                    matriz[reng, colu] = matriz[reng, colu] / pivote;
                }
                //Elimina los elementos que están en la misma columna
                //que el pivote seleccionado.
                //Aquí seleccióna el renglón
                for (int reng_elimi = 0; reng_elimi < 4; reng_elimi = reng_elimi + 1)
                {
                    if (reng_elimi != reng)
                    {
                        //Selecciona el factor por el que se va a multplicar
                        //el renglón principal para eliminar el elemento
                        factor = matriz[reng_elimi, reng];

                        //Resta todo el renglón principal a el renglón a eliminar
                        for (int colu_elimi = 0; colu_elimi < 5;
                            colu_elimi = colu_elimi + 1)
                        {
                            matriz[reng_elimi, colu_elimi]
                                = matriz[reng_elimi, colu_elimi] - factor
                                * matriz[reng, colu_elimi];
                        }
                    }
                }
            }


            //Se recorre la matriz
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j == 4)
                    {
                        //Comprobar si el valor es NaN
                        if (double.IsNaN(matriz[i, j]))
                        {
                            System.Console.WriteLine("La ecuacion no tiene solucion");
                            break;
                        }
                        //Imprimir el coeficiente
                            System.Console.WriteLine("x" + (i + 1) + "= " + matriz[i, j]);
                    }
                }
                System.Console.WriteLine();
            }

            System.Console.WriteLine("--------------------------SEGUNDO PROGRAMA--------------------------");

            double[,] MatrizA = new double[7, 7];
            //Se empieza a crear la matriz random empezando con un for       
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Random rnd = new Random((int)DateTime.Now.Ticks);
                    MatrizA[i, j] = rnd.Next(1,(j+200));
                }
                //Se duerme el programa para que se generen numeros random
                System.Threading.Thread.Sleep(100);
            }

            System.Console.WriteLine("Matriz original: ");

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    System.Console.Write(MatrizA[i, j]+ " , ");
                   
                }
                System.Console.WriteLine();
            }

            for (int reng = 0; reng < 7; reng = reng + 1)
            {
                //Selecciona el elemento diagonal como pivote
                pivote = MatrizA[reng, reng];

                //Divide todo el renglón entre el pivote
                for (int colu = 0; colu < 7; colu = colu + 1)
                {
                    MatrizA[reng, colu] = MatrizA[reng, colu] / pivote;
                }
                //Elimina los elementos que están en la misma columna
                //que el pivote seleccionado.
                //Aquí seleccióna el renglón
                for (int reng_elimi = 0; reng_elimi < 7; reng_elimi = reng_elimi + 1)
                {
                    if (reng_elimi != reng)
                    {
                        //Selecciona el factor por el que se va a multplicar
                        //el renglón principal para eliminar el elemento
                        factor = MatrizA[reng_elimi, reng];

                        //Resta todo el renglón principal a el renglón a eliminar
                        for (int colu_elimi = 0; colu_elimi < 7;
                            colu_elimi = colu_elimi + 1)
                        {
                            MatrizA[reng_elimi, colu_elimi]
                                = MatrizA[reng_elimi, colu_elimi] - factor
                                * MatrizA[reng, colu_elimi];
                        }
                    }
                }
            }

            //Se imprime la matriz final
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (j == 7)
                    {
                        //Si algun coeficiente es NaN entonces no tiene solucion    
                        if (double.IsNaN(MatrizA[i, j]))
                        {
                            System.Console.WriteLine("La ecuacion no tiene solucion");
                            break;
                        }
                    }
                        System.Console.Write(MatrizA[i, j] + " , ");    
                    
                }
                System.Console.WriteLine();
            }
            System.Console.ReadLine();
        }


    }
}
