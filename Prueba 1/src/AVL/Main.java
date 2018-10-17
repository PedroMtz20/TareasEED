package AVL;

import java.io.*;

/**
 *
 * @author Pedro
 */
public class Main implements Serializable {

    //Se declaran los objectos y variables necesarios para los metodos y programa,
    //              Son private ya que solo se utilizaran dentro de esta clase
    
    private static Tree bt = new Tree();
    private static FileOutputStream format;

    public static void main(String[] args) throws FileNotFoundException, IOException, ClassNotFoundException {

        File file = new File(System.getProperty("user.dir"),"Vaca.txt");

        AvlNode root = new AvlNode("Tiene cuernos?");

        System.out.println("Buenas tardes, vamos a jugar un juego, responde yes o no respectivamente, para volver a jugar utiliza true cuando te lo pregunte, sin mas empezemos: ");

        if (file.exists()) {
            bt = (Tree) Load();
        } else {

            if (bt.getRoot() == null) {
                bt.setRoot(root, "Vaca", "Perro");
                FileNew();
            }
        }
        try {
            bt.print();
        } catch (Exception exception) {
            System.out.println(exception);
        }

        //Aqui ya ha termindo el programa, lo cual significa que se tiene que guardar el arbol
        System.out.println("Hemos terminado, regresa cuando quieras otro reto");
        Save(bt);
    }
    
//    
//      METODOS:   
//

    //Metodo para cargar el archivo que funciona como la base de datos
    private static Object Load() {
        Object objeto = null;
        try {
            FileInputStream In = new FileInputStream("Vaca.txt");
            try (ObjectInputStream Out = new ObjectInputStream(In)) {
                objeto = Out.readObject();
                Out.close();
            }
        } catch (Exception exception) {
            System.err.println(exception);
        }
        return objeto;
    }

    //Metodo para crear el archvio
    private static void FileNew() {
        FileOutputStream tmp = null;
        try {
            tmp = new FileOutputStream("Vaca.txt", false);
        } catch (Exception exception) {
            System.out.println(exception);
        }
        format = tmp;
    }

    //Metodo para salvar el arbol dentro del archvio
    private static void Save(Object Datos) throws FileNotFoundException {
        if (format == null) {
            format = new FileOutputStream("Vaca.txt", false);
        }
        try {
            ObjectOutputStream out = new ObjectOutputStream(format);
            out.writeObject(Datos);
            out.flush();
        } catch (IOException exception) {
            System.err.println(exception);
        }
    }

}
