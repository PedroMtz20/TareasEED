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
    
    //public static Scanner sc = new Scanner(System.in);
    
    public static BufferedReader in = new BufferedReader(new InputStreamReader(System.in));
   
    public static void main (String[] args) throws Exception{
        
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
        Lista <String> lista1 = new Lista<String>();
        Lista <String> lista2 = new Lista<String>(); 
        
            System.out.println("Nombre del Capitan del equipo 1");
            Cap1 = in.readLine();
            System.out.println("Nombre del Capitan del equipo 2");
            Cap2 = in.readLine();
            
            System.out.println("Tamaño de los equipos?");
            try{
            tam = Integer.parseInt(in.readLine());
            }catch (Exception ex){
                System.out.println("Tamaño incorrecto!");
                ciclo = false;
            }
            
            do{
                if(lista1.Size() < tam){
                equipo1 = true;
                System.out.println("Jugador " + (cont1+1) + " del equipo 1");
                seleccion = in.readLine();
                
                if(cont1 > 0){
                if(lista2.buscarDataString(seleccion) == true || lista1.buscarDataString(seleccion) == true){
                    System.out.println("Jugador ya fue seleccionado");
                    equipo1 = false;
                }
                }
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
                
                if(lista2.Size() <  tam){
                equipo2 = true;
                System.out.println("Jugador " + (cont2+1) + " del equipo 2");
                seleccion = in.readLine();
                
                if(lista1.buscarDataString(seleccion) == true || lista2.buscarDataString(seleccion) == true){
                    System.out.println("Jugador ya fue seleccionado");
                    equipo2 = false;
                }
                
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
            
            if(lista1.Size() == tam && lista2.Size() == tam){
            System.out.println("Lista de equipo 1:  \n" + "Capitan: " + Cap1 + "\n" + lista1 + "\nLista de equipo 2: \n" + "Capitan: " + Cap2 + "\n" + lista2);
            ciclo = false;
            }
            
        }while(ciclo == true);
    }
    
}
