/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Actividad3_Einstein;
import java.util.Timer; //Es el que organiza
import java.util.TimerTask;  //Es el que ejecuta

/**
 *
 * @author Pedro
 */
public class Actividad3_Einstein {
    
    public static void main(String [] args )throws Exception{  
              
        //Se crean los timers que utilizara el programa
          Timer timer = new Timer();
          TimerTask repeatedTask = new TimerTask() {
          
           
           //Se crean los contadores
           int cont2 = 1;   
           int cont = 1;   
           
           //El Timer se declara con el que se correra el programa
           Timer timerA = new Timer();
           //Con esto empieza a correr el Timer
        public void run() {
               try {
                   //Hay un contador que sube cada 1,5 segundos o 1500 milisegundos
                   System.out.println("Albert Einsten ha hecho " + cont + " artículos" );
                   Thread.sleep(1500);
                   cont++;
               } catch (InterruptedException ex) {
               }
               
               //Cadavez que se cumple el if se le agrega al contador de el Archivador
               if(cont % 2 == 0){
                   System.out.println("El Archivador ha archivado " + cont2 + " artículos");
                   cont2++;
               }
               
             }
        
    };
    
          
    //Delay y periodo general del timer
    long delay  = 1000L;
    long period = 1000L;
    timer.scheduleAtFixedRate(repeatedTask, delay, period);
   
    
    
    }

}
