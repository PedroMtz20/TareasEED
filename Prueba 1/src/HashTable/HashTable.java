/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package HashTable;

/**
 *
 * @author Pedro
 */
public class HashTable<E> {
    
    public static final int M = 23;
    Lista<E>[] data = new Lista[M];
    
    public HashTable(){
    }
    
    public int hashfunction(E value){
        
        int result = 0;
        
        result = ((Integer)value) % M;
        
        return result;
    
    
    }
    
    public void add(E param)
    {
        (this.data[this.hashfunction(param)]).add(param);
    }    
    
    public E get(int key){
        return (E) (data[key]);
    }
    
    public boolean exists(E param){
      return this.get(this.hashfunction(param)).exists(param);
    }
}
