/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Actividad3_Infija;
import Actividad3_Metodo.*;
import java.util.Scanner;

/**
 *
 * @author Pedro
 */
public class Actividad3_Infija {
    
    

    public static void main(String[] args) throws Exception {
        Scanner in = new Scanner(System.in);
        
        System.out.println("Escribe una expresión algebraica: ");
        String operacion = Stack.limpiar(in.nextLine());
        String[] Array = operacion.split(" ");

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
                    case 1:
                        aux.push(entrada.pop());
                        break;
                    case 3:
                    case 4:
                        while (Stack.jerarquia(aux.peek()) >= Stack.jerarquia(entrada.peek())) {
                            salida.push(aux.pop());
                        }
                        aux.push(entrada.pop());
                        break;
                    case 2:
                        while (!aux.peek().equals("(")) {
                            salida.push(aux.pop());
                        }
                        aux.pop();
                        entrada.pop();
                        break;
                    default:
                        salida.push(entrada.pop());
                }
            }

            
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



