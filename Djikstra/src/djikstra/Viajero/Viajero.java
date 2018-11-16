/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package djikstra.Viajero;

import java.util.Stack;

/**
 *
 * @author Pedro
 */
public class Viajero {
    
    private int numerodenodos;
    private int[][] distancias;
    private int distanciaoptima = 999;
    private String caminoOptimo = "";
   
    
    public Viajero(int [][] temp){
        distancias = temp;
    }
    
    public int TSP(int inicio, int vertices[],String camino, int costo){
        
        camino += Integer.toString(inicio) + "-";
        int length = vertices.length;
        int nuevoCosto;
        
        if(length == 0){
        
            nuevoCosto = costo + distancias[inicio][0];
            
        if(nuevoCosto < distanciaoptima){
            distanciaoptima = nuevoCosto;
            caminoOptimo = camino + "0";
            }
        return (distancias[inicio][0]);
        }
        else if(costo > distanciaoptima){
            return 0;
        }else{
            int [][] nuevosVertices = new int[length][(length-1)];
            int costoNodoActual;
            int costoHijo;
            int MejorCosto = 999;
            
            for(int i = 0 ; i < length; i++){
                for(int j = 0,k = 0; j < length;j++,k++){
                    if (i == j){
                        k--;
                        continue;
                    }
                    nuevosVertices[i][k] = vertices[j];
                }
                
                costoNodoActual = distancias[inicio][vertices[i]];
                nuevoCosto = costoNodoActual + costo;
                costoHijo = TSP(vertices[i],nuevosVertices[i],camino,nuevoCosto);
                int costoTotal = costoHijo + costoNodoActual;
                
                if(costoTotal < MejorCosto){
                        MejorCosto = costoTotal;
                }
            }
                System.out.println(caminoOptimo);
            return MejorCosto;
        }
    }
    
}
