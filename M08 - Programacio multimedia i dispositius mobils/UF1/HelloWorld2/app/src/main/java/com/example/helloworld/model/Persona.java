package com.example.helloworld.model;

import androidx.annotation.DrawableRes;

import com.example.helloworld.R;

import java.util.ArrayList;
import java.util.List;

public class Persona {
    private static List<Persona> persones;
    public static List<Persona> getPersones(){
        if(persones==null){
            persones=new ArrayList<>();
            persones.add(new Persona(R.drawable.pol,"Pol","Carol","00000000X",Sexe.HOME,Provincia.getProvincies().get(0)));
            persones.add(new Persona(R.drawable.placeholder,"Paco","Jones","11111111X",Sexe.ALTRES,Provincia.getProvincies().get(1)));
            persones.add(new Persona(R.drawable.placeholder,"Maria","Nana","22222222X",Sexe.DONA,Provincia.getProvincies().get(1)));
            persones.add(new Persona(R.drawable.placeholder,"Joan","Gómez","33333333X",Sexe.HOME,Provincia.getProvincies().get(2)));
            persones.add(new Persona(R.drawable.placeholder,"Pep","Pérez","44444444X",Sexe.HOME,Provincia.getProvincies().get(0)));
            persones.add(new Persona(R.drawable.placeholder,"Sara","Sánchez","55555555X",Sexe.ALTRES,Provincia.getProvincies().get(2)));
            persones.add(new Persona(R.drawable.elena,"Elena","Romeu","66666666S",Sexe.DONA,Provincia.getProvincies().get(3)));
        }
        return persones;
    }
    private int imatge;
    private String nom;
    private String cognoms;
    private String NIF;
    private Sexe sexe;
    private Provincia provincia;

    public Persona(@DrawableRes int imatge, String nom, String cognoms, String NIF, Sexe sexe, Provincia provincia) {
        this.imatge=imatge;
        this.nom = nom;
        this.cognoms = cognoms;
        this.NIF = NIF;
        this.sexe = sexe;
        this.provincia = provincia;
    }

    public int getImatge() {
        return imatge;
    }

    public void setImatge(@DrawableRes int imatge) {
        this.imatge = imatge;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }

    public String getCognoms() {
        return cognoms;
    }

    public void setCognoms(String cognoms) {
        this.cognoms = cognoms;
    }

    public String getNIF() {
        return NIF;
    }

    public void setNIF(String NIF) {
        this.NIF = NIF;
    }

    public Sexe getSexe() {
        return sexe;
    }

    public void setSexe(Sexe sexe) {
        this.sexe = sexe;
    }

    public Provincia getProvincia() {
        return provincia;
    }

    public void setProvincia(Provincia provincia) {
        this.provincia = provincia;
    }
}
