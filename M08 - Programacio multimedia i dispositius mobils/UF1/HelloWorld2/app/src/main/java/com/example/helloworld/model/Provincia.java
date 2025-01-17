package com.example.helloworld.model;

import com.example.helloworld.R;

import java.util.ArrayList;
import java.util.List;

public class Provincia {
    private int id;
    private String provincia;
    
    private static List<Provincia> provincies;
    public static List<Provincia> getProvincies(){
        if(provincies==null){
            provincies=new ArrayList<>();

            //Els noms estan així per fotre a la Elena
            provincies.add(new Provincia(1,"Barcelona"));
            provincies.add(new Provincia(2,"Gerona"));
            provincies.add(new Provincia(3,"Tarragona"));
            provincies.add(new Provincia(4,"Lérida"));
        }
        return provincies;
    }

    public Provincia(int id, String provincia) {
        this.id = id;
        this.provincia = provincia;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getProvincia() {
        return provincia;
    }

    public void setProvincia(String provincia) {
        this.provincia = provincia;
    }

    @Override
    public String toString() {
        return provincia;
    }
}
