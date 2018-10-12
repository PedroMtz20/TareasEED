/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Actividad3_Infija;

import Actividad3_Metodo.*;
import prueba.pkg1.*;

/**
 *
 * @author Pedro
 */
public class Nodo<E> {

    private E data;
    private Nodo next;

    public Nodo() {
    }

    public Nodo(E data, Nodo next) {
        this.data = data;
        this.next = next;
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

    @Override
    public String toString() {
        return "Nodo{" + "data=" + data + ", next=" + next + '}';
    }

}
