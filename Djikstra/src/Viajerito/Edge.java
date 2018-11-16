/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Viajerito;

/**
 *
 * @author Pedro
 */
public class Edge {

    GraphNode target = new GraphNode();

    Integer cost = null;

    public Edge(GraphNode node) {

        this.target = node;
    }

    public GraphNode getTarget() {

        return target;

    }

    public void setTarget(GraphNode target) {

        this.target = target;

    }

    public Integer getCost() {

        return cost;

    }

    public void setCost(Integer cost) {

        this.cost = cost;

    }

}
