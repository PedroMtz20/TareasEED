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

        //Se prueba el metodo de Crear y de Insertar
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

        System.out.println(pila);

        
        //Se prueban los metodos de inveritr y alternar dentro de un try-catch
        try {
            pila.inverse();
            pila.alternar(pila2);
            
        } catch (Exception e) {

        }
        System.out.println(pila);
    }
}
