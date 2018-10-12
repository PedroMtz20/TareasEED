/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AVL;

import java.util.Scanner;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

/**
 *
 * @author Pedro
 */
public class Tree<E> {

    AvlNode root;

    Scanner sc = new Scanner(System.in);

    BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

    AvlNode actual = root;

    public AvlNode getRoot() {
        return root;
    }

    public void setRoot(AvlNode root) {
        this.root = root;
    }

    private AvlNode addPregunta(AvlNode actual, E data) {
        actual = root;
        if (actual == null) {
            return new AvlNode(data);
        }

        if (actual.getHizq() == null) {
            actual.hizq = addPregunta(actual.hizq, data);
        } else {
            actual.hder = addPregunta(actual.hder, data);
        }

        return actual;
    }

    public void addPregunta(E data) {
        root = addPregunta(root, data);
    }

    private AvlNode addPregunta2(AvlNode actual, E data, String respuesta) {
        if (actual == null) {
            actual = new AvlNode(data);
            return actual;
        }

        if (respuesta.equalsIgnoreCase((String) actual.yes)) {
            actual.hizq = addPregunta2(actual.hizq, data, respuesta);
        } else if (respuesta.equalsIgnoreCase((String)actual.no)) {
            actual.hder = addPregunta2(actual.hder, data, respuesta);
        } else {

            return actual;
        }
        return actual;
    }

    public void addPregunta2(E data, String respuesta) {

        root = addPregunta2(root, data, respuesta);
    }

    private AvlNode addAnimal(AvlNode actual, E data, String respuesta) {
        if (actual.hder == null) {
            actual.hizq.no = actual.yes;
            actual.hizq.yes = data;
            return actual;
        }else{
            actual.hder.no = actual.no;
            actual.hder.yes = data;
            return actual;
        }

    }

    public void addAnimal(E data, String respuesta) {
        root = addAnimal(root, data, respuesta);

    }

    public void print() throws IOException {
        boolean juego = true;
        String respuesta = null;
        String animal2 = null;

        if (actual == null) {
            actual = root;
            actual.yes = "Vaca";
            actual.no = "Perro";
            System.out.println(actual);
        }
        do {
            while (actual != null) {
                boolean noencontrado = false;
                actual = root;
                System.out.println(actual.data);
                respuesta = br.readLine();
                while (!(actual.hder == null && actual.hizq == null)) {
                    if (respuesta.equalsIgnoreCase("Yes")) {
                        if(root.hizq == null){
                            break;
                        }
                        actual = actual.hizq;
                        System.out.println(actual.data);
                        respuesta = br.readLine();
                    } else {
                        if(root.hder == null){
                            break;
                        }
                        actual = actual.hder;
                        System.out.println(actual.data);
                        respuesta = br.readLine();
                    }
                }

                    if (respuesta.equalsIgnoreCase("Yes")) {
                        System.out.println("El animal es: " + actual.yes + "?");
                        respuesta = br.readLine();
                        animal2 = (String) actual.yes;
                        if (respuesta.equalsIgnoreCase("Yes")) {
                            System.out.println("He ganado!\nDesea jugar otra vez?");
                            juego = sc.nextBoolean();
                            break;
                        } else if (respuesta.equalsIgnoreCase("No")) {
                            System.out.println("No se en que estas pensando!. Dime el animal en el que estas pensando");
                            String animal = br.readLine();
                            System.out.println("Ahora dime la pregunta con la que lo puedo identificar");
                            String pregunta = br.readLine();
                            addPregunta2(actual, (E) pregunta, animal2);
                            //actual = actual.hizq;
                            addAnimal(actual, (E) animal, animal2);
                            System.out.println("He perdido! Desea seguir jugando?");
                            juego = sc.nextBoolean();
                            if (juego == true) {
                                actual = root;
                            }
                        }
                    } else {
                        System.out.println("El animal es: " + actual.no + "?");
                        respuesta = br.readLine();
                        animal2 = (String) actual.no;
                        if (respuesta.equalsIgnoreCase("Yes")) {
                            System.out.println("He ganado!\nDesea jugar otra vez?");
                            juego = sc.nextBoolean();
                        } else if (respuesta.equalsIgnoreCase("No")) {
                            System.out.println("No se en que estas pensando!. Dime el animal en el que estas pensando");
                            String animal = br.readLine();
                            System.out.println("Ahora dime la pregunta con la que lo puedo identificar");
                            String pregunta = br.readLine();
                            addPregunta2(actual, (E) pregunta, animal2);
                            //actual = actual.hder;
                            addAnimal(actual, (E) animal, animal2);
                            System.out.println("He perdido! Desea seguir jugando?");
                            juego = sc.nextBoolean();
                            if (juego == true) {
                                actual = root;
                            }
                        }

                    }

                

                if (noencontrado == true) {
                    System.out.println("No se en que estas pensando!. Dime el animal en el que estas pensando");
                    String animal = br.readLine();
                    System.out.println("Ahora dime la pregunta con la que lo puedo identificar");
                    String pregunta = br.readLine();
                    addPregunta2(actual, (E) pregunta, respuesta);
                    addAnimal(actual, (E) animal, pregunta);
                    System.out.println("He perdido! Desea seguir jugando?");
                    juego = sc.nextBoolean();
                    if (juego == true) {
                        actual = root;
                    }
                }
            }
        } while (juego == true);
    }
}
