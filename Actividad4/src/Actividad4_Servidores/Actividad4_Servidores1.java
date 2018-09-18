/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Actividad4_Servidores;

/**
 *
 * @author Pedro
 */
public class Actividad4_Servidores1 {
    
    public static void main (String [] args)throws Exception{
        
        //Se crean las 2 filas por cada servidor
        Queue <Double> Server1 = new Queue <Double>();
        Queue <Double> Server2 = new Queue <Double>();
        
        //Se crean datos dummy
        double pack = Random();
        Server1.push(5.0);
        pack = Random();
        Server2.push(2.0);
       
        //Ciclo que se repite 60 veces
        for (int i = 0;i<61;i++){
           pack = Random();
           double Serv1 = Server1.TamPaquetes();
           double Serv2 = Server2.TamPaquetes();
           
           //Decide cual fila tiene mas valores y decide en base a eso
           if(Serv1 >= Serv2){
               System.out.println("El server de 2Ghz esta manejando un dato de: " + pack);  
               Server2.push(pack);
           }else if(Serv1 < Serv2){
               Server1.push(pack);
               System.out.println("El server de 1Ghz esta manejando un dato de: " + pack);
           }
            
        }

        
    }
    
    
    //Metodo estatico de tandom
    public static double Random(){
    double x = Math.random() * ((50 - 10) + 1 ) + 10;
    return x;
}
    
}
