/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Actividad3_Metodo;

/**
 *
 * @author Pedro
 */
public class Actividad3 {

    public static void main(String[] args) {

        Stack<String> pila = new Stack<String>();
        Stack<String> pila2 = new Stack<String>();
        pila.push("1");
        pila.push("2");
        pila.push("3");
        pila.push("4");
        pila.push("5");

        pila2.push("a");
        pila2.push("b");
        pila2.push("c");

        // try{
        //pila.inverse();
        //}catch(Exception e){
        //}
        System.out.println(pila);

        
        
        try {
            pila.alternar(pila2);
            //pila.inverse();
        } catch (Exception e) {

        }
        System.out.println(pila);
    }
}
