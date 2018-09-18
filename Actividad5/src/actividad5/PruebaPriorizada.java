/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

//Posicion Hijo Izquierdo = Posicion Padre *2
//Posicion Hijo Derecho = Posicion Padre * 2 + 1
//Posicion padre = Posicion Hijo / 2 (Siempre se redondea abajo)
package actividad5;

/**
 *
 * @author Pedro
 */
public class PruebaPriorizada {
    
    public static void main(String [] args){
        
        Priorizada<String> myPriorizada = new Priorizada<>();
        myPriorizada.push(4, "H");
        myPriorizada.push(3, "O");
        myPriorizada.push(1, "L");
        myPriorizada.push(2, "A");
        myPriorizada.push(5, "M");

        System.out.println(myPriorizada);
        
        System.out.println(myPriorizada.peek());
        
        try{
        myPriorizada.pop();
        }catch(Exception E){
            System.out.println("Pulos");
        }
        
        System.out.println(myPriorizada);
        
        myPriorizada.push(1,"L");
        
        System.out.println(myPriorizada);
        
    }
    
}
