/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package PruebaColaPriorizada;

/**
 *
 * @author Pedro
 */
public class Priorizada<E> {

    private int size = 0;
    private PriorityNode<E> [] data;
    private static int INFINITO = 10000;

    public Priorizada() {
        data = new PriorityNode[INFINITO];
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

    public void push(int priority, E param) {
        //Creamos el nodo a insertar
        PriorityNode<E> nodeToInsert
                = new PriorityNode<E>(priority, param);
        //aumentamos el tamaño de la cola priorizada
        this.size++;
        //si es el  primero lo ponemos en la posición 1 y listo
        if (size == 1) {
            data[size] = nodeToInsert;
        } else {
            //Si no  está vacía la cola priorizada           
            //la  posición temporal es la última
            int myPosition = size;
            //ponemos  el nodo ahí
            data[myPosition] = nodeToInsert;
            //encontramos  la posición del padre
            int myParentPosition = (int) (myPosition / 2);
            //Y  guardamos el valor del padre
            PriorityNode myParent = data[myParentPosition];
            //repetimos  intercambiar el padre con el hijo hasta que el padre
            //tenga  mayor prioridad que el hijo
            while (myPosition != 1 && myParent.getPriority() > nodeToInsert.getPriority()) {
                data[myPosition] = myParent;
                data[myParentPosition] = nodeToInsert;
                myPosition = myParentPosition;
                myParentPosition = (int) (myParentPosition / 2);
                myParent = data[myParentPosition];

            }

        }

//        if(this.isEmpty()){//Si esta vacio insertar en el primer  lugar
//            this.size++;
//            this.data[1] = nodeToInsert;
//        }else{
//            this.size++;
//            this.data[size] = nodeToInsert;
//            int myposition = size;
//            int myparentPosition = (int)(size/2);
//        
//        while(myposition != 1 && nodeToInsert.getPriority() < data[myparentPosition].getPriority()){
//            data[myposition] = data[myparentPosition];
//            data[myparentPosition] = nodeToInsert;
//            myparentPosition = (int)(myparentPosition/2);
//            z
//        }
//        }
    }

    public E pop() {
        E result = null;
        if (this.isEmpty()) {
            System.out.println("Estas bien puños");
        } else {
            result = (E) data[1];
            data[1] = null;
            int myposition = size;
            int myparentPosition = (int) (size / 2);
            int ChildPositionIzq = (int) (myparentPosition * 2);
            int ChildPositionDer = (int) (myparentPosition * 2 + 1);

        }
        return result;
    }

}
