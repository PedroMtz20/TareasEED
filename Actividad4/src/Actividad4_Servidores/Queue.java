/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Actividad4_Servidores;

/**
 *
 * @author Pedro
 */
public class Queue<E> {
  //Data para los elementos
    private E[] data;
    //Capacidad infinita
    public static final int MAX_CAPACITY = 100000;
    //Tamaño
    private int size=0;

    public Queue() {
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
            throw new Exception("La fila está vacía");
        }else
        result=this.data[0];
        for(int i = 1; i<this.size;i++){
          this.data[i-1]=this.data[i];  
        }
        this.size--;
        return result;
    }
    
        public E peek() throws Exception{
        E result;
        if (this.isEmpty()){
            throw new Exception("La fila está vacía");
        }
        result = this.data[this.size-1];
        return result;
    }
        
        public E peekfirst() throws Exception{
        E result;
        if (this.isEmpty()){
            throw new Exception("La fila está vacía");
        }
        result = this.data[0];
        return result;
        }
        
        public void inverse() throws Exception {
        if (this.size > 0) {
            E x = this.pop();
            this.inverse();
            this.push(x);
        }
    }

    @Override
    public String toString() {
        String result = "";
        
        for(int i = 0;i<size;i++){
            result += this.data[i]+" ";
        }
        
        return result;
    }   
    
    //Metodo para calcular cuanto esta encolado
        public double TamPaquetes()throws Exception{
            
            double prueba = 0;
            
            //Lo suma por prueba
            for(int i = 0; i < this.size;i++){
                E x = this.peek();
                prueba += (Double) this.pop();
                this.push(x);
            }
            
      return prueba;  
        }
}
    