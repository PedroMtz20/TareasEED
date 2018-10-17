package evidencia2;

import java.util.Scanner;
import java.io.*;

/**
 *
 * @author Pedro
 */
public class Tree<E> implements Serializable {

    AvlNode root;

    String animal2;

    //Transient significa que no son serializables a diferencias de las variables y objetos
    transient Scanner sc = new Scanner(System.in);

    transient BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

    AvlNode actual = root;

    //Getters y Setters
    public String getAnimal2() {
        return animal2;
    }

    public void setAnimal2(String animal2) {
        this.animal2 = animal2;
    }

    String respuesta;

    public AvlNode getRoot() {
        return root;
    }

    public void setRoot(AvlNode root, E yes, E no) {
        this.root = root;
        root.setYes(yes);
        root.setNo(no);
    }

    public String getRespuesta() {
        return respuesta;
    }

    public void setRespuesta(String respuesta) {
        this.respuesta = respuesta;
    }

    public AvlNode getActual() {
        return actual;
    }

    public void setActual(AvlNode actual) {
        this.actual = actual;
    }

    //Metodo recursivo para agrerar un nodo con una pregunta dentro de el arbol, como parametros utilizamos el apuntador actual, la pregunta E data y el String respuesta
    public AvlNode addPregunta(AvlNode actual, E data, String respuesta) {
        //Caso de salida que cuando actual sea igual a null crear un nodo e insertarlo deontro del arbol
        if (actual == null) {
            actual = new AvlNode(data);
            return actual;
        }

        //Si respuesta es igual al animal en respuesta si entonces ir a la izquierda
        if (respuesta.equalsIgnoreCase((String) actual.yes)) {
            actual.hizq = addPregunta(actual.hizq, data, respuesta);
            //Si respuesta es igual al animal en respuesta no enconces ir a la derecha
        } else if (respuesta.equalsIgnoreCase((String) actual.no)) {
            actual.hder = addPregunta(actual.hder, data, respuesta);
        } else {
            //Devolver actual si ninguno  se cumple
            return actual;
        }
        return actual;
    }

    //Metodo NO recursivo para añadir animal, no es recursivo ya que el apuntador ya esta hasta el final, nuestros parametros son el apuntador, y el dato que 
    //es el animal en el que el usuario pensaba
    private AvlNode addAnimal(AvlNode actual, E data, E pregunta) {
        //Si la pregunta es igual al data en el hijo izquierdo
        if (actual.hizq != null) {
            if (actual.hizq.data.equals(pregunta)) {
                //El no del hijo izquiero es igual al si del padra
                actual.hizq.no = actual.yes;
                //El si del hijo izquierdo se vuelve nuestro dato
                actual.hizq.yes = data;
                actual.yes = null;
                return actual;
            } else {
                //El no del hijo derecho es igual al no del padre
                actual.hder.no = actual.no;
                //El si del hijo derecho se vuelve nuestro dato
                actual.hder.yes = data;
                //El no del apuntador se hace nulo, ya que lo movimos
                actual.no = null;
                return actual;
            }
            //Si la pregunta NO es igual al data en el hijo izquierdo}
        } else {
            //El no del hijo derecho es igual al no del padre
            actual.hder.no = actual.no;
            //El si del hijo derecho se vuelve nuestro dato
            actual.hder.yes = data;
            //El no del apuntador se hace nulo, ya que lo movimos
            actual.no = null;
            return actual;
        }
    }

    //Metodo que funciona como el backbone del programa, funciona como los resultados de el programa
    public void print() throws IOException {    

        //Todo se inicializa para evitar problemas al leer los resultados anteriores
        boolean juego = true;
        respuesta = null;
        animal2 = null;
        br = new BufferedReader(new InputStreamReader(System.in));
        Scanner sc = new Scanner(System.in);
        String AnimalSwitch = null;
        do {
            //El apuntador actual siempre se hace root ya que el programa tiene que empezar en el root
            actual = root;
            System.out.println(actual.data);
            //Se pide al usuario sy respuesta a la primera pregunta
            respuesta = br.readLine();
            //Empieza el metodo para moverse dentro del nodo, utiliza como parametros el apuntador y la respuesta
            try {
                recorrer(actual, respuesta);
            } catch (Exception ex) {

            }
            //Caso en que al final del recorrido la respuesta del usuario es si el usuario pierde y el programa gana

            if (respuesta.equalsIgnoreCase("Yes")) {
                System.out.println("He ganado!\nDesea jugar otra vez?");
                //Boolean que se encarga en seguir o detener el programa
                juego = sc.nextBoolean();
                //Caso contrario al anterior en el cual el usuario gana y el programa pierde
            } else if (respuesta.equalsIgnoreCase("No")) {
                //Se almacenan las variables de la pregunta y el animal que da el usuario
                System.out.println("No se en que estas pensando!. Dime el animal en el que estas pensando");
                String animal = br.readLine();
                System.out.println("Ahora dime la pregunta con la que lo puedo identificar");
                String pregunta = br.readLine();

                AnimalSwitch = getAnimal2();
                //Se llaman los metodos para añadir la pregunta por lo tanto creando el nodo y despues añadir los animales correspondientes
                addPregunta(actual, (E) pregunta, AnimalSwitch);
                addAnimal(actual, (E) animal, (E) pregunta);
                System.out.println("He perdido! Desea seguir jugando?");
                juego = sc.nextBoolean();
                if (juego == true) {
                    actual = root;
                }
            }
        } while (juego == true);
    }

    //Metodo RECURSIVO para avanzar dentro de el arbol binario
    public AvlNode recorrer(AvlNode actual, String respuesta) throws Exception {
        //Caso de salida (Si algo grande)
        if ((respuesta.equalsIgnoreCase("Yes") && actual.hizq == null) || (respuesta.equalsIgnoreCase("No") && actual.hder == null)) {
            if (respuesta.equalsIgnoreCase("Yes")) {
                System.out.println("El animal es: " + actual.yes + "?");
                respuesta = br.readLine();
                setAnimal2((String) actual.yes);
                setRespuesta(respuesta);
                setActual(actual);
                return actual;
            } else {
                System.out.println("El animal es: " + actual.no + "?");
                respuesta = br.readLine();
                setAnimal2((String) actual.no);
                setRespuesta(respuesta);
                setActual(actual);
                return actual;
            }

        }
        //En caso de que la respuesta a la pregunta anterior (data) sea si
        if (respuesta.equalsIgnoreCase("Yes")) {
            if (actual.hizq == null) {
                return actual;
            }
            actual = actual.hizq;
            System.out.println(actual.data);
            respuesta = br.readLine();
            recorrer(actual, respuesta);
            //En caso de que la respuesta a la pregunta anterior (data) sea no
        } else {
            if (actual.hder == null) {
                return actual;
            }
            actual = actual.hder;
            System.out.println(actual.data);
            respuesta = br.readLine();
            recorrer(actual, respuesta);
        }

        return actual;
    }

}
