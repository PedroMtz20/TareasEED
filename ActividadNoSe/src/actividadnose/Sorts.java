package actividadnose;

import java.util.ArrayList;

public class Sorts {

    public ArrayList<Integer> sortBubble(ArrayList<Integer> data) {

        ArrayList<Integer> result = data; //Resultado
        boolean swaped = false; //Variable en caso de que no haya intercambio
        for (int i = 0; i < result.size() - 1; i++) { //desde 0 a n-1 iteraciones
            swaped = false;
            for (int j = 0; j < result.size() - i - 1; j++) { //desde 0 a n-iteraciones - 1                          
                //obtenemos los valores
                Integer pos = result.get(j);
                Integer next = result.get(j + 1);
                //si la pos es mayor que el siguiente intercambia
                if (pos > next) {
                    result.set(j, next);
                    result.set(j + 1, pos);
                    swaped = true;
                }
            }
            if (!swaped) {//si no hubo intercambio se acaba el método
                break;
            }
        }
        return data;
    }

    public ArrayList<Integer> sortSeleccion(ArrayList<Integer> data) {

        ArrayList<Integer> result = data; //Resultdo
        for (int i = 0; i < result.size() - 1; i++) { //se hacen n-1 iteraciones
            Integer pos = result.get(i);//se obtiene el mínimo supuesto
            for (int j = i + 1; j < result.size(); j++) {//compara desde la posición i 
                //hasta el fin del arreglo
                Integer next = result.get(j);
                if (pos > next) {//en caso de ser mayor se intercambia
                    result.set(i, next);
                    result.set(j, pos);
                    pos = next;
                }
            }
        }
        return result;
    }

    public ArrayList<Integer> sortInsertion(ArrayList<Integer> data) {

        ArrayList<Integer> result = new ArrayList<Integer>(); //Resultado
        result.add(0, data.get(0));//se crea la lista ordenada
        for (int i = 1; i < data.size(); i++) {//haremos n-1 pasos
            int index = 0;//el lugar tentativo donde acomodaremos el nuevo
            //elemento
            //mientras que no hayan acabado los elementos
            //y no el siguiente elemento no sea mayor que el i-esimo
            //sigue avanzando
            while (index < result.size() && result.get(index) < data.get(i)) {
                index++;
            }
            //al final agrega en el lugar que le corresponde
            result.add(index, data.get(i));
        }
        return result;
    }

    //Se utiliza n/2 - 1
    public ArrayList<Integer> sortShell(ArrayList<Integer> data, int n) {

        ArrayList<Integer> result = data; //Resultado
        if (n == 1) {// Caso de salida
            Sorts b = new Sorts();
            result = b.sortBubble(data);
        } else {
            for (int i = 0; i < n; i++) {//dividimos en n segmentos 
                ArrayList<Integer> aux = new ArrayList<>();
                for (int j = i; j < data.size(); j = j + n) {// tomamos los elementos
                    aux.add(result.get(j));// lo guardamos en un arreglo auxiliar
                }
                Sorts s = new Sorts();
                aux = s.sortBubble(aux);//bubble de este arreglo
                //lo regresamos a sus lugares
                for (int j = i, index = 0; j < data.size(); j = j + n, index++) {
                    result.set(j, aux.get(index));
                }
            }
            result = this.sortShell(result, n / 2); //llamada recursiva
        }
       
        return result;
    }

    public ArrayList<Integer> sortMerge(ArrayList<Integer> data) {

        ArrayList<Integer> result = data; //Resultado
        //caso de salida
        if (result.size() == 1) {
            result = data;
        } else {//caso recursivo
            ArrayList<Integer> parcial1 = new ArrayList<Integer>(),
                    parcial2 = new ArrayList<Integer>();
            int j = 0;
            //Separar el arreglo en 2 iguales
            for (int i = 0; i < (int) (result.size() / 2); i++) {
                parcial1.add(result.get(i));
                j++;
            }
            for (int i = j; i < (result.size()); i++) {
                parcial2.add(result.get(i));
            }
            //Unir el ordenamiento de los 2 parciales
            result = this.union(this.sortMerge(parcial1), this.sortMerge(parcial2));
        }
        return result;
    }

    //Como l1 se utiliza 0 y l2 se utiliza n-1
    public ArrayList<Integer> sortQuick(ArrayList<Integer> data, int l1, int l2) {

        ArrayList<Integer> result = data; //Resultado
        int l1aux = l1, l2aux = l2;
        if (l1 >= l2) {
            result = data;
        } else {

            int delta = -1;

            do {//repite el ciclo
                //En caso de que se tenga que cambiar.
                //Se multiplica por delta para saber el sentido de la
                //comparación
                if (data.get(l1aux) * delta < delta * data.get(l2aux)) {

                    Integer aux = data.get(l1aux); //intercambia
                    data.set(l1aux, data.get(l2aux));
                    data.set(l2aux, aux);
                    aux = l1aux;//intercambia
                    l1aux = l2aux;
                    l2aux = aux;
                    delta *= -1;//cambia el sentido
                }
                l2aux += delta;
            } while (l1aux != l2aux);
            result = sortQuick(data, l1, l1aux - 1);//Ordena la parte menor.
            result = sortQuick(data, l1aux + 1, l2);//Ordena la parte mayor.
        }
        return result;
    }

    public ArrayList<Integer> union(ArrayList<Integer> p1, ArrayList<Integer> p2) {

        ArrayList<Integer> result = new ArrayList<>();
        int index1 = 0, index2 = 0;
        int maxIndex1 = p1 != null ? p1.size() : 0, maxIndex2 = p2 != null ? p2.size() : 0;
        while (index1 < maxIndex1 || index2 < maxIndex2) {
            //si ya no hay en el arreglo 1
            if (index1 == maxIndex1) {
                //agrego en el resultado del arreglo2
                result.add(p2.get(index2++));
            } else if (index2 == maxIndex2) {
                //ya no hay en el arreglo 2 pero si en el 1
                result.add(p1.get(index1++));
            } else {
                //hay en los 2 agrego el más pequeño
                result.add((p1.get(index1) < p2.get(index2))
                        ? p1.get(index1++) : p2.get(index2++));
            }
        }
        return result;
    }

}
