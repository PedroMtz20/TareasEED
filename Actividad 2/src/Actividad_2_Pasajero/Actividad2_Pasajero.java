package Actividad_2_Pasajero;


import java.util.Scanner;

/**
 *
 * @author Pedro
 */
public class Actividad2_Pasajero {
    
    public static Scanner sc = new Scanner(System.in);
   
    public static void main (String[] args) throws Exception{
        
        //Se declaran variables que seran utilizads dentro del programa
        int contador = 1;
        int opc = 0;
        int pasajero = 0;
        Lista <String> myLista = new Lista<String>();
        boolean ciclo = true;
        
        //Ciclo en el que se ejecuta el prgrama
        do{
            String nombre = null;
            System.out.println("Buenos días, ¿Qué desea hacer? \n 1.- Agregar Pasajeros \n 2.- Eliminar un pasajero \n 3.- Visualizar un pasajero \n 4.- Visualizar la lista \n 5.- Terminar el programa");
            try{
            opc = sc.nextInt();
            }catch(Exception e){
                System.out.println("Opcion inválida");
                break;
            }
        switch (opc){
            //En caso de introducir opciones que no existen
            default:
                System.out.println("Opción inválida");
                break;
            
            //Opcion 1 que inserta pasajeros por medio de metodos de Insertar
            case 1:
                System.out.println("Nombre del pasajero que desea insertar?");
                nombre = sc.next();
                if(myLista.isEmpty()){
                    myLista.insertAtFirstPosition(nombre);
                }else{
                        myLista.insert(contador, nombre);
                        contador++;
                }
                break;
                
            //Opcion 2 que borra pasajeros por medio de index 
            case 2:
                System.out.println("Numero del pasajero que desea borrar");
                pasajero = sc.nextInt();
                if (pasajero > myLista.Size()){
                    throw (new Exception ("El pasajero no existe!"));
                }else{
                    myLista.borrar(pasajero);
                }
                break;
             
            //Opcion 3 que visualiza cada pasajero individualmente gracias a iteración por next    
            case 3:
                System.out.println(myLista + "\n Numero del pasajero que desea visualizar");
                pasajero = sc.nextInt();
                if (pasajero > myLista.Size()){
                    throw (new Exception ("El pasajero no existe!"));
                }else{
                    myLista.buscar(pasajero);
                }
                break;
           
            //Opcion 4 que visauliza toda la liista
            case 4:
                System.out.println(myLista);
                break;
            
            //Cambia la variable del ciclo, haciendo que termine el programa
            case 5:
                ciclo = false;
                break;
        }
        
        }while (ciclo == true);
    }
}

