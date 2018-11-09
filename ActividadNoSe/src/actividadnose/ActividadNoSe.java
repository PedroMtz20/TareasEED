package actividadnose;

import java.util.ArrayList;
import java.util.concurrent.TimeUnit;

public class ActividadNoSe {

    public static void main(String[] args) {

        Sorts sort = new Sorts();

        ArrayList<Integer> data = new ArrayList();
        ArrayList<Integer> aux = new ArrayList();

        for (int i = 100000; i > 0; i--) {
            //aux.add((int) Math.ceil(Math.random() * 100000));
            aux.add(i);
        }

        data.addAll(aux);

        long StartTime = System.nanoTime();
        System.out.println("Metodo Bubble: " + "\n" + sort.sortBubble(data));
        long endTime = System.nanoTime();
        System.out.println("Tiempo en milisegundos: " + (endTime - StartTime)/1000000);
        data.clear();

        data.addAll(aux);

        long StartTime2 = System.nanoTime();
        System.out.println("Metodo Seleccion: " + "\n" + sort.sortSeleccion(data));
        long endTime2 = System.nanoTime();
        System.out.println("Tiempo en milisegundos: " + (endTime2 - StartTime2)/1000000);
        data.clear();

        data.addAll(aux);

        long StartTime3 = System.nanoTime();
        System.out.println("Metodo Insertion: " + "\n" + sort.sortInsertion(data));
        long endTime3 = System.nanoTime();
        System.out.println("Tiempo en milisegundos: " + (endTime3 - StartTime3)/1000000);
        data.clear();

        data.addAll(aux);

        long StartTime4 = System.nanoTime();
        System.out.println("Metodo Shell: " + "\n" + sort.sortShell(data, 50000));
        long endTime4 = System.nanoTime();
        System.out.println("Tiempo en milisegundos: " + (endTime4 - StartTime4)/1000000);
        data.clear();

        data.addAll(aux);

        long StartTime6 = System.nanoTime();
        System.out.println("Metodo Merge: " + "\n" + sort.sortMerge(data));
        long endTime6 = System.nanoTime();
        System.out.println("Tiempo en milisegundos: " + (endTime6 - StartTime6)/1000000);
        data.clear();
        
        data.addAll(aux);

        long StartTime5 = System.nanoTime();
        System.out.println("Metodo Quick: " + "\n" + sort.sortQuick(data, 0, 99999));
        long endTime5 = System.nanoTime();
        System.out.println("Tiempo en milisegundos: " + (endTime5 - StartTime5)/1000000);

    }

}
