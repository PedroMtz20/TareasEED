/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Actividad3_Einstein;
import Actividad3_Metodo.*;
import java.util.Date;
import java.util.Timer; //Es el que organiza
import java.util.TimerTask;  //Es el que ejecuta
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Pedro
 */
public class Actividad3_Einstein {
    
    public static void main(String [] args )throws Exception{  
              
          Timer timer = new Timer();
          TimerTask repeatedTask = new TimerTask() {
          
           
           int cont2 = 1;   
           int cont = 1;   
           
           Timer timerA = new Timer();
        public void run() {
               try {
                   System.out.println("Albert Einsten ha hecho " + cont + " artículos" );
                   Thread.sleep(1500);
                   cont++;
               } catch (InterruptedException ex) {
               }
             
               if(cont % 2 == 0){
                   System.out.println("El Archivador ha archivado " + cont2 + " artículos");
                   cont2++;
               }
               
             }
    };
     
    long delay  = 1000L;
    long period = 1000L;
    timer.scheduleAtFixedRate(repeatedTask, delay, period);
   
    
    
    }

}
