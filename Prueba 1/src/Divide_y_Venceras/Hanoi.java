package Divide_y_Venceras;

/**
 *
 * @author Pedro
 */
public class Hanoi {
    
    private Stack<Integer> A,B,C;
 
    public Hanoi(int n){
        //Creamos torres
        A = new Stack<Integer>();
        B = new Stack<Integer>();
        C = new Stack<Integer>();
        //Metemos discos
        for (int i = n;i>0;i--){
            
            A.push(new Integer(i));
            
        }
        
    }
    
    public void H(int n)throws Exception{
        this.H(n, A, B, C);
    }
    
    public void H(int n, Stack A, Stack B, Stack C)throws Exception{
        Stack<Integer> result;
        if (n == 1){
           B.push(A.pop());
           System.out.println(this);
        }else{
            H(n-1,A,C,B);
            H(1,A,B,C);
            H(n-1,C,B,A);
        }
        
        
    }

    @Override
    public String toString() {
        return "\nA=" + A + "\nB=" + B + "\nC=" + C;
    }
    
}
