/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Actividad_2_Metodos;

/**
 *
 * @author Pedro
 */
public class Nodo<E> {
    private E data;
    private Nodo next;
    private Nodo prev;
    

    public Nodo() {
    } 
    
    public Nodo(E data, Nodo next, Nodo prev) {
        this.data = data;
        this.next = next;
        this.prev = prev;
    }

    public E getData() {
        return data;
    }

    public void setData(E data) {
        this.data = data;
    }

    public Nodo getNext() {
        return next;
    }

    public void setNext(Nodo next) {
        this.next = next;
    }

    public Nodo getPrev() {
        return prev;
    }

    public void setPrev(Nodo prev) {
        this.prev = prev;
    }

    
    

    @Override
    public String toString() {
        return "Nodo{" + "data=" + data + ", next=" + next + '}';
    }
    



   
    
}
