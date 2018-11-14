package djikstra;

import java.util.ArrayList;
import java.util.List;

public class Node implements Comparable<Node> {

    private String nombre; //Nombre de el nodo
    private List<Arista> adjecentes; //Nodos adjecentes al acutal (aka vecinos)
    private boolean visitado; //Marca si el nodo ya esta visitado, pero no si ya es  permanente
    private Node nodoAnterior; //Recuerda cual es el nodo anterior
    private int peso = Integer.MAX_VALUE;//Inicializa la distancia como el valor maximo, se tomara como infinito
    
    //Constructor del nodo con parametro de nombre
    public Node (String nombre){
        //Se le asigna el nombre al nodo
        this.nombre = nombre;
        //Se crea un ArrayList vacio que sera llenado despues con los nodos adjecentes a el
        this.adjecentes = new ArrayList<>();
    }
    
    public void addAdjecente(Arista arista){
        this.adjecentes.add(arista);
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public List<Arista> getAdjecentes() {
        return adjecentes;
    }

    public void setAdjecentes(List<Arista> adjecentes) {
        this.adjecentes = adjecentes;
    }

    public boolean isVisitado() {
        return visitado;
    }

    public void setVisitado(boolean visitado) {
        this.visitado = visitado;
    }

    public Node getNodoAnterior() {
        return nodoAnterior;
    }

    public void setNodoAnterior(Node nodoAnterior) {
        this.nodoAnterior = nodoAnterior;
    }

    public int getPeso() {
        return peso;
    }

    public void setPeso(int peso) {
        this.peso = peso;
    }
    
    @Override
    public int compareTo(Node otherNode){
        return Integer.compare(this.peso, otherNode.getPeso());
    }

    @Override
    public String toString() {
        return nombre;
    }
    
    
}
