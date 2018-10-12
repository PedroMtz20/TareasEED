package Divide_y_Venceras;

/**
 *
 * @author Pedro
 */
public class Main {
    
    public static void main(String [] args){
        
        Hanoi myHanoi = new Hanoi(10);
        System.out.println(myHanoi);
        try{
        myHanoi.H(10);
        }catch(Exception exception){
            
        }
    }
    
    
    
}
