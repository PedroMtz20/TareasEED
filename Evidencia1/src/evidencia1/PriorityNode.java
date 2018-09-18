/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package evidencia1;
/**
 *
 * @author Pedro
 */
public class PriorityNode<E> {
    
    private int priority;
    private E data;
    
    public PriorityNode() {
    }

    public PriorityNode(int priority, E data) {
        this.priority = priority;
        this.data = data;
    }

    public int getPriority() {
        return priority;
    }

    public void setPriority(int priority) {
        this.priority = priority;
    }

    public E getData() {
        return data;
    }

    public void setData(E data) {
        this.data = data;
    }

    @Override
    public String toString() {
        return "PriorityNode{" + "priority=" + priority + ", data=" + data + '}';
    }
    

    
}
