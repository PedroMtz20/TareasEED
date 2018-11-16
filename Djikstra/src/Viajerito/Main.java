/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Viajerito;

import java.util.Scanner;

/**
 *
 * @author Pedro
 */
public class Main {

    static Scanner scanner = null;
    static int number_of_nodes;

    public static void main(String[] args) {

        GraphNode A = new GraphNode("A");
        GraphNode B = new GraphNode("B");
        GraphNode C = new GraphNode("C");
        GraphNode D = new GraphNode("D");
        GraphNode E = new GraphNode("E");
        
        Edge AB = new Edge(B);
        Edge AC = new Edge(C);
        Edge AD = new Edge(D);
        Edge BC = new Edge(C);
        Edge BD = new Edge(D);
        Edge CD = new Edge(D);
        
        
        AB.setCost(2);
        AC.setCost(5);
        AD.setCost(6);
        BC.setCost(8);
        BD.setCost(10);
        CD.setCost(12);
        
        A.setEdges(AB);
        A.setEdges(AC);
        A.setEdges(AD);
        B.setEdges(BC);
        B.setEdges(BD);
        C.setEdges(CD);
        

        A.TSP(A);
    }
}
