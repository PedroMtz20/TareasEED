package djikstra;

import java.util.*;

/**
 *
 * @author Pedro
 */
public class Djikstra {

    public List<Node> caminoMasCorto(Node Inicio, Node fin) {

        Inicio.setPeso(0);//Se inicializa el peso a 0, ya que a la hora de calcular
        //se empieza en cero independientemente del peso inicial
        //Se crea una cola priorizada que almacenara lo que ya visitamos
        //Pero que aun no hemos terminado de analizar, organiza los datos
        //por el valor de menor a mayor
        PriorityQueue<Node> prioridadTemporal = new PriorityQueue<>();
        //Se almacena el inicio en la cola, ya que apenas vamos a empezar a analizarlo
        prioridadTemporal.add(Inicio);
        //Ya lo visitamos asi que lo marcamos como visitado PERO NO COMO PERMANENTE!!
        Inicio.setVisitado(true);
        
        while(!prioridadTemporal.isEmpty()){
            //Almacenamos en actual el nodo de menor valor, y despues se quita de la cola
            Node actual = prioridadTemporal.poll();
            //Un for en el cual se itere mientras halla adjecentes en el nodo actual
            for(Arista arista : actual.getAdjecentes()){
                //Almacenamos en el nodo auxiliar el destino de la arista que contiene el nodo auxiliar
                Node aux = arista.getTarget();
                //Mientras que no halla sido visitado continuar
                if(!aux.isVisitado()){
                    //Se actualiza el label del nodo si nunca ha sido visitado, ya que el label en este
                    //caso seria igual a infinito
                    int LabelPeso = actual.getPeso() + arista.getPeso();
                    //Si el label nuevo es menor que el label anterior entonces hay que actualizar
                    if( LabelPeso < aux.getPeso()){
                        prioridadTemporal.remove(aux);
                        aux.setPeso(LabelPeso);
                        aux.setNodoAnterior(actual);
                        prioridadTemporal.add(aux);
                    }
                }
                
            }
            actual.setVisitado(true);
        }
        
        List<Node> camino = new ArrayList<>();
        
        for(Node nodo = fin; nodo != null;nodo = nodo.getNodoAnterior()){
            camino.add(nodo);
        }
        
        Collections.reverse(camino);
        return camino;
    }

}
