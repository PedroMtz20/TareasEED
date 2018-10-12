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
        
        double pack = Random();
        double tam1 = 0;
        double tam2 = 0;
        Server1.push(5.0);
        pack = Random();
        Server2.push(2.0);
       
        
        for (int i = 0;i<61;i++){
           pack = Random();
           double prueba1 = Server1.TamPaquetes();
           double prueba2 = Server2.TamPaquetes();
           
           
           if(prueba1 >= prueba2){
               System.out.println("El server de 2Ghz esta manejando un dato de: " + pack);  
               Server2.push(pack);
           }else if(prueba1 < prueba2){
               Server1.push(pack);
               System.out.println("El server de 1Ghz esta manejando un dato de: " + pack);
           }
           
//           if(tam1 >= tam2 == true){
//               Server2.push(pack);
//               System.out.println("El server de 2Ghz esta manejando un dato de: " + pack);
//               Server2.pop();
//               if(Server1.Size() >= 2){
//
//               }
//           }else if(tam1 < tam2 == true){
//               Server1.push(pack);
//               System.out.println("El server de 1Ghz esta manejando un dato de: " + pack);
//               Server1.pop();
//               Server1.TamPaquetes();
//               if(Server2.Size() >= 2){
//               }
//           }
           
            
        }

        
    }
    
    public static double Random(){
    double x = Math.random() * ((50 - 10) + 1 ) + 10;
    return x;
}
    
}
