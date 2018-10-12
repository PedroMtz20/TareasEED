/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package prueba.pkg1;

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
    private int size=0;

    public Stack() {
        this.data = (E[])new Object[this.MAX_CAPACITY];
    }
    
    public boolean isEmpty(){
        
        return (this.size == 0);
    }
    
    public int Size(){
        
        return (this.size);
    }
    
    public void push (E param){
        this.data[this.size] = param;
        this.size++;
    }
    
    public E pop() throws Exception{
        E result;
        if (this.isEmpty()){
            throw new Exception("La pila está vacía");
        }
        result = this.data[this.size-1];
        this.size--;
        return result;
    }
    
    public E peek() throws Exception{
        E result;
        if (this.isEmpty()){
            throw new Exception ("La pila esta vacia");
        }
        result = this.data[this.size-1];
        return result;
    }

    @Override
    public String toString() {
        String result = "";
        
        for(int i = 0;i<size;i++){
            result += data[i]+" ";
        }
        
        return result;
    }
    
    
}
