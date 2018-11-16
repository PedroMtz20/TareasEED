/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package djikstra;

import java.util.List;
import java.util.Stack;

/**
 *
 * @author Pedro
 */
public class main {
    
    public static void main (String[] args){
        
        Djikstra grafo = new Djikstra();
        
        Stack todos = new Stack();
        
        
        Node A = new Node("A");
        Node B = new Node("B");
        Node C = new Node("C");
        Node D = new Node("D");
        Node E = new Node("E");
        Node F = new Node("F");
        Node G = new Node("G");
        Node H = new Node("H");
        Node I = new Node("I");
        Node J = new Node("J");
        Node K = new Node("K");
        Node L = new Node("L");
        Node M = new Node("M");
        Node N = new Node("N");
        Node O = new Node("O");
        
        A.addAdjecente(new Arista(A,B,9));
        A.addAdjecente(new Arista(A,F,11));
        B.addAdjecente(new Arista(B,C,10));
        B.addAdjecente(new Arista(B,D,9));
        B.addAdjecente(new Arista(B,E,1));
        C.addAdjecente(new Arista(C,D,6));
        E.addAdjecente(new Arista(E,D,9));
        D.addAdjecente(new Arista(D,H,2));
        D.addAdjecente(new Arista(D,I,18));
        F.addAdjecente(new Arista(F,E,4));
        F.addAdjecente(new Arista(F,G,19));
        G.addAdjecente(new Arista(G,M,2));
        G.addAdjecente(new Arista(G,H,11));
        H.addAdjecente(new Arista(H,I,20));
        H.addAdjecente(new Arista(H,L,10));
        I.addAdjecente(new Arista(I,K,1));
        I.addAdjecente(new Arista(I,J,15));
        L.addAdjecente(new Arista(L,N,2));
        J.addAdjecente(new Arista(J,O,9));
        K.addAdjecente(new Arista(K,J,12));
        M.addAdjecente(new Arista(M,N,6));
        N.addAdjecente(new Arista(N,O,10));
        
        todos.push(A);
        todos.push(B);
        todos.push(C);
        todos.push(D);
        todos.push(E);
        todos.push(F);
        todos.push(G);
        todos.push(H);
        todos.push(I);
        todos.push(J);
        todos.push(K);
        todos.push(L);
        todos.push(M);
        todos.push(N);
        todos.push(O);
        
        System.out.println(grafo.caminoMasCorto(A,O));
        
    }
    
}
