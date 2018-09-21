/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package evidencia1;
import java.util.Scanner;
import java.util.TimerTask;
import java.util.Timer;
import java.util.Random;

/**
 *
 * @author Pedro
 */
public class Evidencia1 {

    /**
     * @param args the command line arguments
     */
    
    public static Scanner sc = new Scanner(System.in);
    
    public static int cont = 1;
    
    public static void main(String[] args) {
        
       boolean ciclo = true;
       int tiempomax1 = 0;
       int tiempomax2 = 0;
       int tiempomin1 = 0;
       int tiempomin2 = 0;
       int tope = 0;
       
       Priorizada myLista = new Priorizada();
       
       do{ 
       System.out.println("Buenos días, Escoge una de las opciones: \n 1.- Establecer rango de tiempo de llegada de los elementos \n"
               + " 2.- Establecer el rango de tiempo de servicio del servidor \n 3.- Empezar Simulación \n 4.- Terminar programa \n 5.- Establecer tope");
       int sel;
       sel = sc.nextInt();
       
       switch(sel){
           case 1:
               System.out.println("Inserta el tiempo maximo");
               tiempomax1 = sc.nextInt() * 1000;
               System.out.println("Inserta el tiempo mínimo");
               tiempomin1 = sc.nextInt() * 1000;
               
               while (tiempomax1 < tiempomin1){
                   System.out.println("¡Tiempo maximo muy pequeño! Insertelo nuevamente");
                   tiempomax1 = sc.nextInt() * 1000;
               }
               
               
               break;
               
           case 2:
               System.out.println("Inserta el tiempo maximo");
               tiempomax2 = sc.nextInt() * 1000;
               System.out.println("Inserta el tiempo mínimo");
               tiempomin2 = sc.nextInt() * 1000;
               
               while (tiempomax2 < tiempomin2){
                   System.out.println("Tiempo maximo muy pequeño! Insertelo nuevamente");
                   tiempomax2 = sc.nextInt() * 1000;    
               }
               
               break;
               
           case 3:
               
               Timer timer ;
               timer  = new Timer();
               
               TimerTask push = new TimerTask(){
               @Override
               public void run(){
               int randomData = (int) Math.floor(Math.random() * 101);
               int randomPrio = (int) Math.ceil(Math.random() * 5);
               if(!(myLista.getSize() == myLista.getTope())){
               myLista.push(randomPrio, randomData);
               System.out.println("Se ha metido un dato");
               }else{
                   System.out.println("Limite alcanzado!");
               }
               }
               };
               
               TimerTask pop = new TimerTask(){
               @Override
               public void run(){
               if(!(myLista.isEmpty())){
               myLista.pop();
               System.out.println("Se ha eliminado un dato");
               }else{
                 System.out.println("No hay nada que borrar");
               }
               }
               };
               
                TimerTask print = new TimerTask() {
                @Override
                public void run() {
                    System.out.println("Segundos " + cont);
                    System.out.println("Lista: " + myLista);
                    cont++;
                    
                    if(cont == 181){
                        System.out.println("El programa ha terminado!");
                        System.exit(0);
                    }
            }
            };
               
               
               timer.schedule(push, random(tiempomax1,tiempomin1), random(tiempomax1,tiempomin1));
               timer.schedule(pop, random(tiempomax2,tiempomin2), random(tiempomax2,tiempomin2));
               timer.schedule(print, 1000,1000);
               
               break;
               
           case 4:
           ciclo = false;
               break;
               
           case 5:
            System.out.println("Establece el tope en enteros: ");
            tope = sc.nextInt();
            myLista.tope(tope);
            break;
       }
       
       }while(ciclo == true);
       
    }
    
    
public static int random(int tiempomax1, int tiempomin1){
     Random random = new Random();
     int randomllegada = random.nextInt(tiempomax1 +  1 - tiempomin1) + tiempomin1;
     return randomllegada;
}    
    
}
