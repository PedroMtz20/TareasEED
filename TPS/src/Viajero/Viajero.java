/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Viajero;

public class Viajero
{
   
    private int ndatos = 4;
    private int Kminimo = 0;
    private int [] completado = new int [4] ;
    private int kmin = 0;
    
 
    public Viajero(){
        
    }
 
    public void tsp(int adjacencyMatrix[][],int inicio)
    {
        char [] nombreciudades = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P'};
        int i, nciudad;
        completado[inicio] = 1;
        
        System.out.print(nombreciudades[inicio] + ", ");
        nciudad = menor(adjacencyMatrix,inicio);
        
        if(nciudad == 999){
            nciudad = 0;
            System.out.println(nombreciudades[nciudad]);
            Kminimo += adjacencyMatrix[inicio][nciudad];
            System.out.println("\nCosto total: " + Kminimo);
            
            return;
        }
        tsp(adjacencyMatrix,nciudad);
        
    }
    
    public int menor(int adjacencyMatrix[][], int c){
        
        int i,nc = 999;
        int min = 999;
        
        for(i = 0;i < ndatos;i++){
            if((adjacencyMatrix[c][i]!=0)&&(completado[i] == 0))
                if(adjacencyMatrix[c][i]+adjacencyMatrix[i][c] <= min){
                    min = adjacencyMatrix[i][0]+adjacencyMatrix[c][i];
                    kmin = adjacencyMatrix[c][i];
                    nc = i;
                }
        }
        if(min != 999)
            Kminimo += kmin;
        
        return nc;
        
    }
 
}