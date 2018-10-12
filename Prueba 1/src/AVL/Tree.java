/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AVL;

import java.util.Scanner;

/**
 *
 * @author Pedro
 */
public class Tree<E> {

    AvlNode root;

    Scanner sc = new Scanner(System.in);

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
        System.out.println(actual.data);
        respuesta = sc.next();
        if (respuesta.equalsIgnoreCase("Yes")) {
            actual.hizq = addPregunta2(actual.hizq, data, respuesta);
        } else if (respuesta.equalsIgnoreCase("No")) {
            System.out.println(actual.data);
            respuesta = sc.next();
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
            data = (E) ("Es: " + data);
            actual.hder = new AvlNode(data);
            actual.hizq = new AvlNode("Ganaste");
            return actual;
    }

    public void addAnimal(E data, String respuesta) {
        root = addAnimal(root, data, respuesta);

    }

    public void traversePreOrder(AvlNode node) {
        if (node != null) {
            System.out.print(" " + node.data);
            traversePreOrder(node.hizq);
            traversePreOrder(node.hder);
        }
    }

    public void print() {
        boolean juego = true;
        if (actual == null) {
            actual = root;
            AvlNode Vaca = new AvlNode("Es: Vaca");
            AvlNode Perro = new AvlNode("Es: Perro");
            actual.setHder(Perro);
            actual.setHizq(Vaca);
            
        }
        do {
            while (actual != null) {

                if (actual.hizq.data == null && actual.hder.data == null) {
                    System.out.println("Ganaste!\n Deseas segir jugando?");
                    juego = sc.nextBoolean();
                    if (juego == true){
                        actual = root;
                    }
                }
                System.out.println(actual.data);
                String respuesta = sc.next();
                if (respuesta.equalsIgnoreCase("Yes")) {
                    actual = actual.hizq;

                } else if (respuesta.equalsIgnoreCase("No")) {
                    if (actual.hder == null) {
                        System.out.println("No se en que estas pensando!. Dime el animal en el que estas pensando");
                        String animal = sc.next();
                        System.out.println("Ahora dime la pregunta con la que lo puedo identificar");
                        String pregunta = sc.next();
                        addAnimal(actual,(E) animal, pregunta);
                        System.out.println("He perdido! Desea seguir jugando?");
                        juego = sc.nextBoolean();
                        if (juego == true){
                            actual = root;
                        }
                    } else if (actual.hder != null) {
                        System.out.println(actual.hder.data);
                        respuesta = sc.next();
                        actual = actual.hder;
                    }

                }
            }
        } while (juego == true);
    }

//    public void addQuestion(String respuesta, String pregunta, AvlNode a) {
//        if(a.getHizq() == null){
//            AvlNode preguntaNodo = new AvlNode(pregunta);
//            AvlNode respuestaNodo = new AvlNode (respuesta);
//            preguntaNodo.setYes(respuestaNodo);
//            a.setNo(preguntaNodo);
//        }else{
//            AvlNode preguntaNodo = new AvlNode(pregunta);
//            AvlNode respuestaNodo = new AvlNode (respuesta);
//            preguntaNodo.setYes(respuestaNodo);
//            a.setYes(preguntaNodo);
//        }
//
//    }
/*
    public void add(AvlNode nodo) {
        this.ad(nodo, this.root);
    }

    private void addAnimal(AvlNode nodo, AvlNode root) {
        if (root == null) {
            this.setRoot(nodo);
        } else {
            if (nodo.getNo() == null) {
                if (root.getHizq() == null) {
                    root.setHizq(nodo);
                } else {
                    addAnimal(nodo, root.getHizq());
                }
            } else {
                if (root.getHder() == null) {
                    root.setHder(nodo);
                } else {
                    addAnimal(nodo, root.getHder());
                }
            }
        }

    }
     */
}
