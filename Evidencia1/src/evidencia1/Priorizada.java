/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package evidencia1;

/**
 *
 * @author Pedro
 */
public class Priorizada<E> {

    private int size = 0;
    private PriorityNode<E>[] data;
    private static int INFINITO = 10000;

    public Priorizada() {
        data = new PriorityNode[INFINITO];
    }
    
    public void tope(int param){
        INFINITO = param;
    }
    
    public int getTope(){
        return INFINITO;
    }

//    public E Peek(){
//        
//     return(data[1]);
//    }
//    public void pop() throws Exception{
//        if(M.isEmpty()){
//            throws Exception;
//        }else if(!M.isEmpty()){
//            result = data[1];
//        }
//    }
    //Devuelve el tamaño de la cola priorizada
    public int getSize() {
        return this.size;
    }

    //return true si la cola priorizada esta vacia
    public boolean isEmpty() {
        //return (data[1]==null);
        return (this.size == 0);
    }

//    public void push(int priority, E param) {
//        //Creamos el nodo a insertar
//        PriorityNode<E> nodeToInsert
//                = new PriorityNode<E>(priority, param);
//        //aumentamos el tamaño de la cola priorizada
//        this.size++;
//        //si es el  primero lo ponemos en la posición 1 y listo
//        if (size == 1) {
//            data[1] = nodeToInsert;
//        } else {
//            //Si no  está vacía la cola priorizada           
//            //la  posición temporal es la última
//            int myPosition = size;
//            //ponemos  el nodo ahí
//            this.data[size] = nodeToInsert;
//            //encontramos  la posición del padre
//            int myParentPosition = (int) (myPosition / 2);
//            //Y  guardamos el valor del padre
//            PriorityNode myParent = data[myParentPosition];
//            //repetimos  intercambiar el padre con el hijo hasta que el padre
//            //tenga  mayor prioridad que el hijo
//            while (myPosition != 1 && data[myParentPosition].getPriority() > nodeToInsert.getPriority()) {
//                data[myPosition] = data[myParentPosition];
//                data[myParentPosition] = nodeToInsert;
//                myPosition = myParentPosition;
//                myParentPosition = (int) (myParentPosition / 2);
//                myParent = data[myParentPosition];
//
//            }
//
//        }
    
    public void push(int priority, E param){
    PriorityNode nodeToInsert = new PriorityNode(priority, param);
    this.size++;
    if (size==1){
            data[size] = nodeToInsert;
    }
        else {
            int myPosition = size;
        data[myPosition] = nodeToInsert;
        int myParentPosition = (myPosition / 2);
        int myBrotherPosition = (myPosition - 1);
        PriorityNode myParent = data[myParentPosition];
        PriorityNode myBrother = data[myBrotherPosition];
        //repetimos  intercambiar el padre con el hijo hasta que el padre
        //tenga  mayor prioridad que el hijo
        while (myPosition != 1 && myParent.getPriority() > nodeToInsert.getPriority()) {
            data[myPosition] = myParent;
            data[myParentPosition] = nodeToInsert;
            myPosition = myParentPosition;
            myParentPosition = (myParentPosition / 2);
            myParent = data[myParentPosition];
            }
        while (myPosition != 1 && myBrother.getPriority() > nodeToInsert.getPriority()) {
            data[myPosition] = myBrother;
            data[myBrotherPosition] = nodeToInsert;
            myPosition = myBrotherPosition;
            myBrotherPosition = (myBrotherPosition - 1);
            myBrother = data[myBrotherPosition];
        }
    }
}

    public void pop() {
        E result;
        result = (E) data[1];
        for(int i = 1;i < this.size;i++){
            data[i] = data[i+1];
        }
        size--;
    }

    public PriorityNode<E> peek(){
        
    return (data[1]);
    }
    
    @Override
        public String toString() {
        String result = "";


        for (int i = 1; i < size+1; i++) {
              PriorityNode<E> aux = data[i];
               result += "Dato: " + aux.getData() + " Prioridad: " +  aux.getPriority() + "\n";
        }

            return result;


      }


}