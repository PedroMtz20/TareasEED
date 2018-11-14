
package djikstra;

import java.util.ArrayList;

/**
 *
 * @author Pedro
 */
public class Arista {
    
    private int peso; //Peso de la arista
    private Node raiz; //Nodo raiz de la arista
    private Node target; //Nodo en el que unira la arista con la raiz
    
    public Arista(Node raiz, Node target, int peso){
        this.raiz = raiz;
        this.target = target;
        this.peso = peso;
    }

    public int getPeso() {
        return peso;
    }

    public void setPeso(int peso) {
        this.peso = peso;
    }

    public Node getRaiz() {
        return raiz;
    }

    public void setRaiz(Node raiz) {
        this.raiz = raiz;
    }

    public Node getTarget() {
        return target;
    }

    public void setTarget(Node target) {
        this.target = target;
    }
    
    
    
    }
