package prueba.pkg1;


/**
 *
 * @author Pedro
 */
public class Proyecto2 {
   
    public static void main (String[] args){
        
        Lista <String> myLista = new Lista<String>();
        
        myLista.insertAtFirstPosition("patito, patito");
        myLista.insertAtFirstPosition("Color de cafe");
        myLista.insertAtFirstPosition("prueba");
        
        try {
            myLista.insert(2,"Hola");
            //myLista.borrar(2);
        } catch (Exception ex) {
            System.out.println("Tamaño muy grande!");
        }
        
        
        System.out.println(myLista);
        try{
        myLista.borrar(3);
        }catch (Exception h){
            
        }
        System.out.println(myLista);
        
        try{
        myLista.buscar(2);
        }catch (Exception h){
            System.out.println("Tamaño muy grande!");
        }
        
        try{
        myLista.buscarData("patito, patito");
        }catch (Exception h){
            System.out.println("AHHHHHH");
        }
        
    }
    
    
        /*
        //Crear pila
        Stack <String> miPila 
                = new Stack <String> ();
        //Meter datos
        miPila.push("K");
        miPila.push("A");
        miPila.push("I");
        
        System.out.println(miPila);
        try{
            miPila.pop();
        }catch(Exception ex){
            System.out.println("Error");
        }
        System.out.println(miPila);
        */
    }

