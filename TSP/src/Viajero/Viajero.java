package Viajero;

import java.util.ArrayList;

public class Viajero {
    //Cantidad de datos

    private int ndatos;
    //Array que tiene la suma total del peso de la ruta
    private int Kminimo;
    //Array que almacena los nodos terminados
    private int[] completado;
    private int kmin = 0;
    
    //Se crea un array de chars que le va a asignar una letras a las ciudades
    private char[] nombreciudades = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O'};

    //Se crea un arrayList en donde se almacenara el orden de la ruta
    private ArrayList<Character> camino = new ArrayList();

    //Constructor de viajero que limita el numero de tamano de arrays
    public Viajero(int numeroNodos) {
        this.completado = new int[numeroNodos];
        this.ndatos = numeroNodos;
    }

    //Metodo para imprimir la ruta mas corta, es recursivo
    public void tsp(int adjacencyMatrix[][], int inicio) {
      
        //Se declara una variable que funciona como un aux de ciudad
        int nciudad;
        //Se iicializa completado a 0
        completado[inicio] = 1;
        camino.add(nombreciudades[inicio]);
        //Se calcula en el aux la ruta mas corta
        nciudad = menor(adjacencyMatrix, inicio);

        //Caso de salida
        if (nciudad == 999) {
            //aux se vuelve 0
            nciudad = 0;
            //Se agrega la ultima ciudad a la ruta(la inicial)
            camino.add(nombreciudades[nciudad]);
            //Se le agrega al peso total
            Kminimo += adjacencyMatrix[inicio][nciudad];
            //Se imprime el camino y el peso
            System.out.println(camino);
            System.out.println("\nCosto total: " + Kminimo);

            return;
        }
        //Recursividad con n ciudad (aux)
        tsp(adjacencyMatrix, nciudad);

    }

    //Metodo para calcular la ruta mas corta
    public int menor(int adjacencyMatrix[][], int c) {

        //Se declaran las variables a "infinito" o nullo
        int i, nc = 999;
        int min = 999;
      
        //Cilo que funciona con los numeros de datos
        for (i = 0; i < ndatos; i++) {
                //Si no estan metidos en completado entonces continuar
            if ((adjacencyMatrix[c][i] != 0) && (completado[i] == 0)) 
                //Comprobar que en donde se este insertando el peso sea menor al minimo
                if (adjacencyMatrix[c][i] + adjacencyMatrix[i][c] - kmin < min) {
                    //min se actualiza con los nuevos datos
                    min =  adjacencyMatrix[i][0] + adjacencyMatrix[c][i] - kmin;
                    //Kmin se actualiza con el nuevo peso
                    kmin = adjacencyMatrix[c][i];
                    nc = i;
                }
            
        }
        if (min != 999) {
            //Se agrega kmin al peso total
            Kminimo += kmin;
            
        }

        return nc;

    }

}
