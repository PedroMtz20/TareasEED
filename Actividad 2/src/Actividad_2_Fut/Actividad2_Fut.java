/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Actividad_2_Fut;

import java.io.BufferedReader;
import java.io.InputStreamReader;

/**
 *
 * @author Pedro
 */

public class Actividad2_Fut {
    
    
    public static BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
   
    public static void main (String[] args) throws Exception{
        
        
        //Se declaran todas las variables que se utilizaran en el programa
        int tam = 0;
        boolean ciclo = true;
        boolean equipo1;
        boolean equipo2;
        int contador = 1;
        int cont1 = 0;
        int cont2 = 0;
        String Cap1;
        String Cap2;
        String seleccion;
        
        
        //Se crean las listas que se van a utilizar
        Lista <String> lista1 = new Lista<String>();
        Lista <String> lista2 = new Lista<String>(); 
        
        //Se declaran los nombres de los capitánes, pero no se insertan en la lista
            System.out.println("Nombre del Capitan del equipo 1");
            Cap1 = in.readLine();
            System.out.println("Nombre del Capitan del equipo 2");
            Cap2 = in.readLine();
            
        //Se declara el tamaño de los equipo    
            System.out.println("Tamaño de los equipos?");
            try{
            tam = Integer.parseInt(in.readLine());
            }catch (Exception ex){
                System.out.println("Tamaño incorrecto!");
                ciclo = false;
            }
            
            
            //Se declaran los jugadores del equipo 1
            do{
                if(lista1.Size() < tam){
                equipo1 = true;
                System.out.println("Jugador " + (cont1+1) + " del equipo 1");
                seleccion = in.readLine();
                
                //Solo busca por jugadores repetidos despues de el primero, ya que si no siempre daria error
                if(cont1 > 0){
                if(lista2.buscarDataString(seleccion) == true || lista1.buscarDataString(seleccion) == true){
                    System.out.println("Jugador ya fue seleccionado");
                    equipo1 = false;
                }
                }
                
                //Se inserta el jugador solo si no se detecta que es repetido
                if(equipo1 == true){
                    if(lista1.isEmpty()){
                        lista1.insertAtFirstPosition(seleccion);
                        cont1++;
                    }else{
                        lista1.insert((contador),seleccion);
                        cont1++;
                }
                }
                }
                
                //Se declaran los jugadores del equipo 2
                if(lista2.Size() <  tam){
                equipo2 = true;
                System.out.println("Jugador " + (cont2+1) + " del equipo 2");
                seleccion = in.readLine();
                
                //En todo momento busca por jugadores repetidos
                if(lista1.buscarDataString(seleccion) == true || lista2.buscarDataString(seleccion) == true){
                    System.out.println("Jugador ya fue seleccionado");
                    equipo2 = false;
                }
                
                
                //Inserta en la lista si no se encuentran jugadores repetidos
                if(equipo2 == true){
                if(lista2.isEmpty()){
                    lista2.insertAtFirstPosition(seleccion);
                    cont2++;
                }else{
                    lista2.insert((cont2), seleccion);
                    cont2++;
                }                
                }
                }
            
            //Se imprime todos los datos
            if(lista1.Size() == tam && lista2.Size() == tam){
            System.out.println("Lista de equipo 1:  \n" + "Capitan: " + Cap1 + "\n" + lista1 + "\nLista de equipo 2: \n" + "Capitan: " + Cap2 + "\n" + lista2);
            ciclo = false;
            }
            
        }while(ciclo == true);
    }
    
}
