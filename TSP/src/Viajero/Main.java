package Viajero;

import java.util.Scanner;

/**
 *
 * @author Pedro
 */
public class Main {
    
    //Se crea un scanner
    public static Scanner sc = new Scanner(System.in);
    
     public static void main(String [] args)
    {
        //Se declara un Integro que funcionara para decidir el numero de nodos
        int NumeroNodos = 15;
        try{
            System.out.println("Inserte el numero de ciudades para crear una matriz simétrica con pesos random ");
            //Preguntar al usuario numero de nodos que desea
            NumeroNodos = sc.nextInt();
        }catch(Exception e){
            System.out.println("Cantidad invalida");
        }
            //Se inicializa la matriz de datos con lo que declaro el usuario
            int[][] MatrizAdjecente = new int[NumeroNodos][NumeroNodos];
    //Se empieza a crear la matriz random empezando con un for       
    for(int i = 0; i < MatrizAdjecente.length; i++) {
        for(int j = i; j < MatrizAdjecente.length; j++) {
            if(i == j) {
                //Si I == j significa que es 0 ya que el peso de 
                //un nodo a ese mismo nodo es 0
                MatrizAdjecente[i][j] = 0;
            }
            else {
                //Se insertan los datos de manera simetrica
                    int random = (int) Math.ceil(Math.random()*100);
                    MatrizAdjecente[i][j] = random;
                    MatrizAdjecente[j][i] = random;
            }
        }
    }
    //Se procede a imprimir la matriz con un ciclo for
            System.out.println("Matriz con pesos: ");
        for (int i = 0;i < MatrizAdjecente.length;i++) {
            System.out.println();
            for (int j = 0; j < MatrizAdjecente.length; j++) {
                System.out.print(MatrizAdjecente[i][j] + " , ");
            }
        }
        //Se crea un objeto de viajero y se manda a llamar el metodo para el viajero
            System.out.println("\n \nLas ciudades fueron visitadas en el siguiente orden: ");
            Viajero viajero = new Viajero(NumeroNodos);
            viajero.tsp(MatrizAdjecente, 0);
            
            //Se cierra el scanner y termina el programa    
        sc.close();
    }
    
}
