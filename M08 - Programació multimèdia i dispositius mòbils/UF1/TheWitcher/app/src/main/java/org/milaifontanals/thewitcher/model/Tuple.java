package org.milaifontanals.thewitcher.model;

public class Tuple <E,F>{
    private E first;
    private F second;

    public Tuple(E first, F second) {
        this.first = first;
        this.second = second;
    }

    public E getFirst() {
        return first;
    }

    public void setFirst(E first) {
        this.first = first;
    }

    public F getSecond() {
        return second;
    }

    public void setSecond(F second) {
        this.second = second;
    }
}
