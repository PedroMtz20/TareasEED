/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package djikstra;

import java.util.List;

/**
 *
 * @author Pedro
 */
public class main {
    
    public static void main(String[] args){
        
        Djikstra grafo = new Djikstra();
        
        Node A = new Node("A");
        Node B = new Node("B");
        Node C = new Node("C");
        
        A.addAdjecente(new Arista(A,C,10));
        A.addAdjecente(new Arista(A,B,7));
        B.addAdjecente(new Arista(B,C,2));
        
        System.out.println(grafo.caminoMasCorto(A,C));
    }
    
}
