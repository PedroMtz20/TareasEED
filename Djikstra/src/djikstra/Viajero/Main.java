/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package djikstra.Viajero;

/**
 *
 * @author Pedro
 */
public class Main {
    
    public static void main (String[] args){
        
        int costo[][] = {{0,2,4,6},
                         {2,0,8,10},
                         {4,8,0,12},
                         {6,10,12,0}};
        
        int [] vertices = new int [4];
        for (int i = 0;i < 4;i++){
            vertices[i] = i;
        }
        
        String camino = "";
        
        Viajero viajero = new Viajero(costo);
            System.out.println(viajero.TSP(0, vertices, camino, 0));
        }
    }
    
