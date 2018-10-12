/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package HashTable;

import Actividad_2_Fut.Nodo;

/**
 *
 * @author Pedro
 */
public class Lista<E> {
    private Nodo<E> firstNodo;
    private Nodo<E> tail;

    public Lista() {
       // this.firstNodo = new Nodo(null,null);
       this.firstNodo = null;
    }

    public Lista(Nodo<E> firstNodo) {
        this.firstNodo = firstNodo;
    }
    
    public boolean isEmpty(){        
        
        return (this.firstNodo == null);
    }
    
    //Meoto que inserta data en la primera posicion
        
    public void insertAtFirstPosition(E data){
        if (this.isEmpty()){
            this.firstNodo = new Nodo(data,firstNodo,tail);
        }else{
            //Crear nodo auxiliar con el valor de data
            Nodo<E> aux = new Nodo<E>(data,firstNodo,tail);
            //apuntar el next de aux al nodo incicial
            aux.setNext(this.firstNodo);
            //apuntar el nodo inicial al aux para que quede parejito
            this.firstNodo = aux;
        }
    }

    @Override
    public String toString() {
        String result = "";
        
        Nodo<E> aux = this.firstNodo;
        while(aux != null){
            result += aux.getData()+"\n";
            //avanzamos el apuntador
            aux = aux.getNext();
        }
        
        return result;
    }

    public int Size() {
        int result = 0;
        Nodo<E> aux = this.firstNodo;
        while(aux != null){
            result++;
            //avanzamos el apuntador
            aux = aux.getNext();
        }
        
        return result;
    }    
    
    public void insert( int position, E data) throws Exception{
        //Se crea un nuevo Nodo el cual vamos a insertar mas tarde
        Nodo <E> nodoInsertar = new Nodo <E>(data,firstNodo,tail);
        if(position < 0){
           throw (new Exception ("La posicion es muy pequeña"));
        }
        if(position>this.Size()){
            throw (new Exception("La posición es muy grande"));
        }else{
            //if (position==1){
                //insertAtFirstPosition(data);
            //}else{
                //Creamos un nodo auxiliar el cual vamos a utilizar para no borrar la lista, aux apunta a la memoria de firstNodo 
               Nodo<E> aux = firstNodo;
                for (int i = 0;i<(position-1) ;i++){ 
                    //Pasamos a la conexión del nodo anterior al que queremos insertar
                    aux = aux.getNext();
                }
                //Otra Manera de hacerlo
                //Nodo <E> nodoInsertar = new Nodo<E>(data,aux.getNext());
                //aux.setNext(nodoInsertar)
                //Nodo actual se vuelve el Nodo que queremos insertar
                Nodo nodoActual  = aux.getNext();
                //Se "Unen" los nodos por los dos lados para que no se rompan
                nodoInsertar.setNext(nodoActual);
                //Se inserta el Nodo con el siguiente Nodo
                aux.setNext(nodoInsertar);
            }
        }
    
    
    public void borrar(int position) throws Exception{
        Nodo <E> aux = firstNodo;
        if(position>this.Size()){
            throw (new Exception("La posición es muy grande"));
        }else{
        if (position == 1){
            //Se borra la union del nodo 1 a 2, eliminandolo de la lista
            firstNodo = aux.getNext();
            }else{
            for (int i = 0; i < (position-2);i++){
                aux = aux.getNext();
            }
            //Se borra el nodo de las 2 conexiones pero antes uniendo los otros
            Nodo <E> Siguiente  = aux.getNext().getNext();
            aux.setNext(Siguiente);
        }
        }
    }
    
    public void buscar(int position) throws Exception{
        Nodo <E> aux = firstNodo;
        if (position > this.Size()){
            throw (new Exception("La posición es muy grande"));
        }else{
        if (position == 1){
            //Almaceno en una variable tipo E el data del primer nodo para imprimirlo
            E nodoBuscar = firstNodo.getData();
            System.out.println("El nodo que buscaste es: " + nodoBuscar + "\n");
        }else{
            //Iteramos hasta el next del nodo que queremos
        for (int i = 0; i < position-1;i++){
           aux = aux.getNext(); 
        }
        //Almacenamos el data del nodo al que iteramos en una variable tipo Objecto ya que aux es un Nodo
        Object nodoBuscar = aux.getData();
        System.out.println("El nodo que buscaste es: " + nodoBuscar + "\n");
        }
        }
    }
    
    public Nodo buscarData(String data) throws Exception{
        Nodo resultado = null;
        Nodo nodoActual = this.firstNodo;
        boolean encontrado = false;
        for (int i = 1; (nodoActual != null && !encontrado); i++){
            if(nodoActual.getData() == data){
                encontrado = true;
                resultado = nodoActual;
                System.out.println("El dato " + data + " esta en la posicion: " + i);
            }
            nodoActual = nodoActual.getNext();
        }
        return resultado;
    }
    
    public boolean buscarDataString(String data) throws Exception{
        Nodo resultado = null;
        Nodo nodoActual = this.firstNodo;
        boolean encontrado = false;
        for (int i = 1; (nodoActual != null && !encontrado); i++){
            if(nodoActual.getData() == data){
                encontrado = true;
                resultado = nodoActual;
                System.out.println("El dato " + data + " esta en la posicion: " + i);
            }
            if (nodoActual.getData().toString().equals(data)){
               encontrado = true; 
               break;
            }
            nodoActual = nodoActual.getNext();
        }
        return encontrado;
    }
    
    public void Update (int position, E data){
        Nodo <E> nodoActual = new Nodo <E> ();
        nodoActual = this.firstNodo;
        for (int i = 0; i < position-1; i++){
            nodoActual = nodoActual.getNext();
            }
            nodoActual.setData(data);
            nodoActual.getNext();
        }
    }
    

