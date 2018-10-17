package evidencia2;
import java.io.*;

//data menor en el derecho y mayor en el derecho

public class AvlNode<E> implements Serializable {
    
    //Se declaran las partes que tiene el nodo
    
    E data = null;
    AvlNode hizq = null;
    AvlNode hder = null;
    E yes;
    E no;

    //Constructores
    public AvlNode() {
    }

    public AvlNode(E yes, E no) {
        this.yes = yes;
        this.no = no;
    }
    
    public AvlNode(E data){
        this.data = data;
    }

    
    //Getters y Setters
    public E getData() {
        return data;
    }

    public void setData(E data) {
        this.data = data;
    }

    public AvlNode getHizq() {
        return hizq;
    }

    public void setHizq(AvlNode hizq) {
        this.hizq = hizq;
    }

    public AvlNode getHder() {
        return hder;
    }

    public void setHder(AvlNode hder) {
        this.hder = hder;
    }

    public E getYes() {
        return yes;
    }

    public void setYes(E yes) {
        this.yes = yes;
    }

    public E getNo() {
        return no;
    }

    public void setNo(E no) {
        this.no = no;
    }

    //Metodo toString para comprobar que si se tenga todo
    @Override
    public String toString() {
        return "AvlNode{" + "data=" + data + ", hizq=" + hizq + ", hder=" + hder + ", yes=" + yes + ", no=" + no + '}';
    }
}
