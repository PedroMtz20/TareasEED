/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Viajerito;

import java.util.ArrayList;
import java.util.Stack;

/**
 *
 * @author Pedro
 */
public class GraphNode {

    private String name = new String();//Identificador del grafo

    private ArrayList<Edge> edges = new ArrayList<Edge>();//Listado de vértices

    public GraphNode(String name) {
        this.name = name;
    }
    
    public GraphNode(){
        
    }

    public String getName() {

        return name;

    }

    public void setName(String name) {

        this.name = name;

    }

    public ArrayList<Edge> getEdges() {

        return edges;

    }

    public void setEdges(Edge edges) {

        this.edges.add(edges);

    }
    
    public void TSP(GraphNode inicio){
        
    }

}
