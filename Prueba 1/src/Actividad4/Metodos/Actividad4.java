/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Actividad4.Metodos;

/**
 *
 * @author Pedro
 */
public class Actividad4 {
    
    public static void main (String [] args)throws Exception{
        
        
        Queue <String> fila = new Queue <String>();
        
        
        fila.push("1");
        fila.push("2");
        fila.push("3");
        
        System.out.println(fila);
        
        fila.inverse();
        
        System.out.println(fila);
        

        
    }
    
}
