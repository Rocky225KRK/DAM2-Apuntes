package org.rockyrk.fragments.ui.main;

import androidx.lifecycle.ViewModel;

public class MainViewModel extends ViewModel {
    public String[] getNames(){
        return names;
    }

    String[] names=new String[]{
            "Paco","Maria","Joan","Marta","Pep","Cristina"
    };
}