/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

//Posicion Hijo Izquierdo = Posicion Padre *2
//Posicion Hijo Derecho = Posicion Padre * 2 + 1
//Posicion padre = Posicion Hijo / 2 (Siempre se redondea abajo)
package PruebaColaPriorizada;

/**
 *
 * @author Pedro
 */
public class PruebaPriorizada {
    
    public static void main(String [] args){
        
        Priorizada<String> myPriorizada = new Priorizada<>();
        myPriorizada.push(1, "H");
        myPriorizada.push(3, "O");
        myPriorizada.push(2, "L");
        myPriorizada.push(4, "A");
        
        System.out.println(myPriorizada);
        
        myPriorizada.pop();
        
        System.out.println(myPriorizada);
        
    }
    
}
