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

        while (!prioridadTemporal.isEmpty()) {
            //Almacenamos en actual el nodo de menor valor, y despues se quita de la cola
            Node actual = prioridadTemporal.poll();
            //Un for en el cual se itere mientras halla adjecentes en el nodo actual
            for (Arista arista : actual.getAdjecentes()) {
                //Almacenamos en el nodo auxiliar el destino de la arista que contiene el nodo auxiliar
                Node aux = arista.getTarget();
                //Mientras que no halla sido visitado continuar
                if (!aux.isVisitado()) {
                    //Se actualiza el label del nodo si nunca ha sido visitado, ya que el label en este
                    //caso seria igual a infinito
                    int LabelPeso = actual.getPeso() + arista.getPeso();
                    //Si el label nuevo es menor que el label anterior entonces hay que actualizar
                    if (LabelPeso < aux.getPeso()) {
                        //Se elimina el nodo auxiliar de cola priorizada
                        prioridadTemporal.remove(aux);
                        //Al nodo auxiliar se le asigna el nuevo label de peso
                        aux.setPeso(LabelPeso);
                        //Se asigna que el nodo de el que viene es el anterior
                        aux.setNodoAnterior(actual);
                        // Se agrega el nodo auxiliar actualizado a la cola priorizada, para ser manipulado en otro ciclo
                        // como el nodo actual
                        prioridadTemporal.add(aux);
                    }
                }

            }
            //Actual ya fue visitado y se marca de esta manera
            actual.setVisitado(true);
        }

        //Se crea una nueva lista en la cual se almacenara el camino final
        List<Node> camino = new ArrayList<>();

        //For que ciclo
        for (Node nodo = (Node) caminoMasCorto(Inicio, fin); nodo != null; nodo = nodo.getNodoAnterior()) {
            camino.add(nodo);
            if (nodo == fin) {
                System.out.print("El peso de la ruta es: " + nodo.getPeso() + " con la siguiente ruta: ");
            }
        }

        Collections.reverse(camino);
        return camino;
    }

    private List<Node> PruebaRecursiva(Node Inicio, Node fin, PriorityQueue<Node> Lista) {
        List<Node> camino = new ArrayList<>();
        if (Inicio == fin) {
            for (Node nodo = Inicio; nodo != null; nodo = nodo.getNodoAnterior()) {
                camino.add(nodo);
                if (nodo == fin) {
                    System.out.print("El peso de la ruta es: " + nodo.getPeso() + " con la siguiente ruta: ");
                }
            }

            Collections.reverse(camino);
            return camino;
        } else {
            Inicio.setPeso(0);
            PriorityQueue<Node> prioridadTemporal = new PriorityQueue<>();
            //Se almacena el inicio en la cola, ya que apenas vamos a empezar a analizarlo
            prioridadTemporal.add(Inicio);
            //Ya lo visitamos asi que lo marcamos como visitado PERO NO COMO PERMANENTE!!
            Inicio.setVisitado(true);
                //Almacenamos en actual el nodo de menor valor, y despues se quita de la cola
                Node actual = prioridadTemporal.poll();
                //Un for en el cual se itere mientras halla adjecentes en el nodo actual
                for (Arista arista : actual.getAdjecentes()) {
                    
                    //Almacenamos en el nodo auxiliar el destino de la arista que contiene el nodo auxiliar
                    Node aux = arista.getTarget();
                    //Mientras que no halla sido visitado continuar
                    if (!aux.isVisitado()) {
                        //Se actualiza el label del nodo si nunca ha sido visitado, ya que el label en este
                        //caso seria igual a infinito
                        int LabelPeso = actual.getPeso() + arista.getPeso();
                        //Si el label nuevo es menor que el label anterior entonces hay que actualizar
                        if (LabelPeso < aux.getPeso()) {
                            //Se elimina el nodo auxiliar de cola priorizada
                            prioridadTemporal.remove(aux);
                            //Al nodo auxiliar se le asigna el nuevo label de peso
                            aux.setPeso(LabelPeso);
                            //Se asigna que el nodo de el que viene es el anterior
                            aux.setNodoAnterior(actual);
                            // Se agrega el nodo auxiliar actualizado a la cola priorizada, para ser manipulado en otro ciclo
                            // como el nodo actual
                            prioridadTemporal.add(aux);
                            actual.setVisitado(true);
                            camino = PruebaRecursiva(aux, fin, prioridadTemporal);
                            return camino;
                        }
                    }

                }
                //Actual ya fue visitado y se marca de esta manera
        }
        return camino;
    }

    public List<Node> PruebaRecursiva(Node Inicio, Node fin) {
        PriorityQueue<Node> camino = new PriorityQueue<>();
        return this.PruebaRecursiva(Inicio, fin, camino);
    }

}
