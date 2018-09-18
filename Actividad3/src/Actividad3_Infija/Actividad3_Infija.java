/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Actividad3_Infija;

import java.util.Scanner;

/**
 *
 * @author Pedro
 */
public class Actividad3_Infija {
    
    

    public static void main(String[] args) throws Exception {
        Scanner in = new Scanner(System.in);
        
        //Se inserta la expresion algebraica
        System.out.println("Escribe una expresión algebraica: ");
        //La expresion se limpia por medio del metodo Limpiar
        String operacion = Stack.limpiar(in.nextLine());
        //Una vez limpia se inserta un un array con un espacio entre caracteres
        String[] Array = operacion.split(" ");

        //Se crean las pilas que se utilizaran dentro del programa
        Stack< String> entrada = new Stack<String>();
        Stack< String> aux = new Stack<String>();
        Stack< String> salida = new Stack<String>();

        //Añadir el array a la entrada
        for (int i = Array.length - 1; i >= 0; i--) {
            entrada.push(Array[i]);
        }

        try {
            //Algoritmo Infijo a Postfijo
            while (!entrada.isEmpty()) {
                switch (Stack.jerarquia(entrada.peek())) {
                    //Se insertan lso datos en aux
                    case 1:
                        aux.push(entrada.pop());
                        break;
                    //Se trabaja el operador segundo en jerarquía;
                    case 2:
                        while (!aux.peek().equals("(")) {
                            salida.push(aux.pop());
                        }
                        aux.pop();
                        entrada.pop();
                        break;
                   //Es para los espacios
                    case 3:
                    //Se Ejecuta la jerarquía dentro de la jerarquía
                    case 4:
                        while (Stack.jerarquia(aux.peek()) >= Stack.jerarquia(entrada.peek())) {
                            salida.push(aux.pop());
                        }
                        aux.push(entrada.pop());
                        break;
                        
                    //Una vez que se acaba la jerarquía se pone todo en salida
                    default:
                        salida.push(entrada.pop());
                }
            }

            //Se remplacan los espacios para quitar los espacios
            String infix = operacion.replace(" ", "");
            String postfix = salida.toString().replaceAll("[\\]\\[,]", "");

            //Mostrar resultados:
            System.out.println("La expresión infíja es: " + infix);
            System.out.println("La expresión postfíja es: " + postfix);

        } catch (Exception ex) {
            System.out.println("Error en la expresión algebraica");
            System.err.println(ex);
        }
    }


}



