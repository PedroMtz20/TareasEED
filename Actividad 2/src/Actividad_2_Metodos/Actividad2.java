package Actividad_2_Metodos;

/**
 *
 * @author Pedro
 */
public class Actividad2 {
    
    public static void main (String[] args) throws Exception{
        
        Lista<String> myLista = new Lista<String>();
        
        //Se insertan todos los dotos
        myLista.insertAtFirstPosition("1");
        myLista.insert(1, "2");
        myLista.insert(2, "3");
        myLista.insert(3, "4");
        
        System.out.println(myLista);
        
        //metodo para borrar el valor en un indice
        myLista.borrar(2);
        
        //Método Exists() que busca si el dato dado existe, y devuelve en donde esta de ser así
        myLista.buscarData("3");
        
        myLista.Update(2, "Ha");
        
        myLista.buscar(2);
        
        
        System.out.println(myLista);
        
        
    }
}

