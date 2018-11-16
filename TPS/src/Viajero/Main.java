/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Viajero;

import java.util.Scanner;

/**
 *
 * @author Pedro
 */
public class Main {
    
    public static Scanner sc = new Scanner(System.in);
    
     public static void main(String [] args)
    {
        int NumeroNodos;
        int aux = 50;
            System.out.println("Inserte el numero de ciudades para crear una matriz simétrica con pesos random ");
            sc = new Scanner(System.in);
            NumeroNodos = sc.nextInt();
            int[][] MatrizAdjecente = new int[NumeroNodos][NumeroNodos];
           
    for(int i = 0; i < MatrizAdjecente.length; i++) {
        for(int j = i; j < MatrizAdjecente.length; j++) {
            if(i == j) {
                MatrizAdjecente[i][j] = 0;
            }
            else {
                if(Math.random() < 0.5 && aux >= 0) {
                    int temp = (int)Math.ceil(Math.random()*aux);
                    MatrizAdjecente[i][j] = temp;
                    MatrizAdjecente[j][i] = temp;
                    aux--;        
                }
                else {
                    int random = (int) Math.ceil(Math.random()*50);
                    MatrizAdjecente[i][j] = random;
                    MatrizAdjecente[j][i] = random;
                }
            }
        }
    }
            System.out.println("Matriz con pesos: ");
        for (int[] MatrizAdjecente1 : MatrizAdjecente) {
            System.out.println();
            for (int j = 0; j < MatrizAdjecente.length; j++) {
                System.out.print(MatrizAdjecente1[j] + " , ");
            }
        }
            System.out.println("\n \nLas ciudades fueron visitadas en el siguiente orden: ");
            Viajero tspNearestNeighbour = new Viajero();
            tspNearestNeighbour.tsp(MatrizAdjecente, 0);
            
        sc.close();
    }
    
}
