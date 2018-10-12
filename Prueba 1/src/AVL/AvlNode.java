
package AVL;

//data menor en el derecho y mayor en el derecho

public class AvlNode<E> {
    
    E data = null;
    AvlNode hizq = null;
    AvlNode hder = null;
    AvlNode yes;
    AvlNode no;

    public AvlNode() {
    }

    public AvlNode(AvlNode yes, AvlNode no) {
        this.yes = yes;
        this.no = no;
    }
    
    public AvlNode(E data){
        this.data = data;
    }

    
    
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

    public AvlNode getYes() {
        return yes;
    }

    public void setYes(AvlNode yes) {
        this.yes = yes;
    }

    public AvlNode getNo() {
        return no;
    }

    public void setNo(AvlNode no) {
        this.no = no;
    }

    @Override
    public String toString() {
        return "AvlNode{" + "data=" + data + ", hizq=" + hizq + ", hder=" + hder + ", yes=" + yes + ", no=" + no + '}';
    }
    
    
    

    
    
    
}
