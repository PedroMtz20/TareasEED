/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Divide_y_Venceras;

/**
 *
 * @author Pedro
 */
public class Stack<E> {

    //Data para los elementos
    private E[] data;
    //Capacidad infinita
    public static final int MAX_CAPACITY = 10000;
    //Tamaño
    private int size = 0;

    public Stack() {
        this.data = (E[]) new Object[this.MAX_CAPACITY];
    }

    public boolean isEmpty() {

        return (this.size == 0);
    }

    public int Size() {

        return (this.size);
    }

    public void push(E param) {
        this.data[this.size] = param;
        this.size++;
    }

    public E pop() throws Exception {
        E result;
        if (this.isEmpty()) {
            throw new Exception("La pila está vacía");
        }
        result = this.data[this.size - 1];
        this.size--;
        return result;
    }

    public E peek() throws Exception {
        E result;
        if (this.isEmpty()) {
            throw new Exception("La pila esta vacia");
        }
        result = this.data[this.size - 1];
        return result;
    }

    //Inserta el elemento al final de la pila
    public void insertarAbajo(E data) throws Exception {

        //Si es el primer dato se inserta aqui
        if (this.isEmpty()) {
            this.push(data);
        } //Utiliza el stack hasta que se vacíen los elementos, y los pone en "a" mienntras los elimina del stack original
        else {
            E a = this.peek();
            this.pop();
            this.insertarAbajo(data);
            //Empuja toda la pila invertida
            this.push(a);
        }

    }

    //Invierte la pila utilizando el método de insertar hasta abajo
    public void inverse() throws Exception {
        if (this.size > 0) {

            E x = this.pop();
            this.inverse();

            this.insertarAbajo(x);

        }
    }

    public void alternar(Stack data) throws Exception {
        int cont = 1;
        for (int i = 0; i < this.size; i++) {
            if ((cont % 2) == 1) {
                if (i == 0) {
                    this.insertarAbajo(this.pop());
                }
                this.insertarAbajo(this.pop());
                cont++;
            } else {
                this.insertarAbajo((E) data.pop());
                cont++;
            }
        }
        if (data.isEmpty() == false ) {
            for (int j = 0; data.isEmpty() == false; j++) {
                this.push(this.pop());
            }
            
        }
    }

    @Override
    public String toString() {
        String result = "";

        for (int i = 0; i < size; i++) {
            result += data[i] + " ";
        }

        return result;
    }
    
    //Limpia la operacion para poder ser utilizada en la conversión
    //Tiene que ser estatico ya que se utiliza con un String
    public static String limpiar(String data) {
        data = data.replaceAll("\\s+", "");
        data = "(" + data + ")";
        String simbols = "+-*/()";
        String str = "";

        //Deja espacios entre operadores
        for (int i = 0; i < data.length(); i++) {
            if (simbols.contains("" + data.charAt(i))) {
                str += " " + data.charAt(i) + " ";
            } else {
                str += data.charAt(i);
            }
        }
        return str.replaceAll("\\s+", " ").trim();
    }

    //Dicta la jerarquía de los operadores para la conversion
    //Tiene que ser estatico ya que se utiliza en conjunto con otra pila
    public static int jerarquia(String op) {
        int pref = 99;
        if (op.equals("^")) {
            pref = 5;
        }
        if (op.equals("*") || op.equals("/")) {
            pref = 4;
        }
        if (op.equals("+") || op.equals("-")) {
            pref = 3;
        }
        if (op.equals(")")) {
            pref = 2;
        }
        if (op.equals("(")) {
            pref = 1;
        }
        return pref;

    }

}
