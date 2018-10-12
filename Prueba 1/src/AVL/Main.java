package AVL;

import java.util.Scanner;

/**
 *
 * @author Pedro
 */
public class Main extends Tree {
    
    public static Scanner sc = new Scanner(System.in);
    
    public static void main (String []args){
        
        
        Tree bt = new Tree();
        
        bt.addPregunta("Tiene Cuernos?");
        
        try{
        bt.print();
        }catch (Exception e){
            System.out.println(e);
        }
        
    }
}
    