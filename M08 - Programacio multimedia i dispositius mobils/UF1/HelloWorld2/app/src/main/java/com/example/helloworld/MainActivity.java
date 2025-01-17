package com.example.helloworld;

import android.os.Bundle;
import android.text.Editable;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Spinner;

import androidx.appcompat.app.AppCompatActivity;

import com.example.helloworld.databinding.ActivityMainBinding;
import com.example.helloworld.model.Persona;
import com.example.helloworld.model.Provincia;
import com.example.helloworld.model.Sexe;
import com.example.helloworld.utils.MyTextWatcher;
import com.example.helloworld.utils.Utils;

import java.util.HashMap;

public class MainActivity extends AppCompatActivity {
    private int indexPersonatgeActual=0;

    private ActivityMainBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        binding=ActivityMainBinding.inflate(this.getLayoutInflater());
        setContentView(binding.getRoot());

        showCurrentUser();
        listeners();
        fillSpinner();
    }

    private void fillSpinner() {
        ArrayAdapter<Provincia> adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, Provincia.getProvincies());
        binding.form.spnProvincies.setAdapter(adapter);
    }

    private void listeners() {
        binding.form.btnNext.setOnClickListener(view -> {
            //codi del click
            this.indexPersonatgeActual++;
            showCurrentUser();
        });

        binding.form.btnPrev.setOnClickListener(view -> {
            this.indexPersonatgeActual--;
            showCurrentUser();
        });

        binding.form.edtNom.addTextChangedListener(new MyTextWatcher() {
            @Override
            public void afterTextChanged(Editable editable) {
                Nom_TextChangedListener(editable);
            }
        });

        binding.form.edtCognoms.addTextChangedListener(new MyTextWatcher() {
            @Override
            public void afterTextChanged(Editable editable) {
                Cognoms_TextChangedListener(editable);
            }
        });

        binding.form.edtNif.setOnFocusChangeListener((view, focus) -> {
            binding.form.edtNif.setText(binding.form.edtNif.getText().toString().toUpperCase());
        });

        binding.form.edtNif.addTextChangedListener(new MyTextWatcher() {
            @Override
            public void afterTextChanged(Editable editable) {
                Nif_TextChangedListener(editable);
            }
        });

        binding.form.rdgSexe.setOnCheckedChangeListener((radioGroup, checkedId) -> {
            Persona actual= getPersonaActual();

            HashMap<Integer,Sexe> mapaSexe=new HashMap<>();
            mapaSexe.put(R.id.rdoH,Sexe.HOME);
            mapaSexe.put(R.id.rdoD,Sexe.DONA);
            mapaSexe.put(R.id.rdoA,Sexe.ALTRES);

            actual.setSexe(mapaSexe.get(checkedId));
        });

        binding.form.spnProvincies.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int pos, long id) {
                Persona actual= getPersonaActual();
                actual.setProvincia(Provincia.getProvincies().get(pos));

            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {
                Persona actual=getPersonaActual();
                actual.setProvincia(null);
            }
        });
    }

    private Persona getPersonaActual() {
        return Persona.getPersones().get(indexPersonatgeActual);
    }

    private void Nom_TextChangedListener(Editable editable) {
        String nom=editable.toString();
        if (nom.trim().length()<2)
            binding.form.tilNom.setError("Nom obligatori");
        else {
            binding.form.tilNom.setError("");
            Persona actual = getPersonaActual();
            actual.setNom(editable.toString());
        }
    }

    private void Cognoms_TextChangedListener(Editable editable) {
        String nom=editable.toString();
        if (nom.trim().length()<2)
            binding.form.tilCog.setError("Cognom obligatori");
        else {
            binding.form.tilCog.setError("");
            Persona actual = getPersonaActual();
            actual.setCognoms(editable.toString());
        }
    }

    private void Nif_TextChangedListener(Editable editable) {
        String NIF=editable.toString().toUpperCase();
        boolean NIFCorrecte= Utils.validarDNI(NIF);
        if(!NIFCorrecte) {
            binding.form.tilNif.setError("Nif incorrecte");
        }
        else {
            String nom = editable.toString();
            if (nom.trim().length() < 2)
                binding.form.tilNif.setError("Nif obligatori");
            else {
                binding.form.tilNif.setError("");
                Persona actual = getPersonaActual();
                actual.setNIF(editable.toString());
            }
        }
    }

    private void showCurrentUser() {
        if(this.indexPersonatgeActual>=Persona.getPersones().size()-1)
            binding.form.btnNext.setEnabled(false);
        else
            binding.form.btnNext.setEnabled(true);

        if(this.indexPersonatgeActual<=0)
            binding.form.btnPrev.setEnabled(false);
        else
            binding.form.btnPrev.setEnabled(true);

        Persona actual= getPersonaActual();
        binding.form.edtNom.setText(actual.getNom());
        binding.form.edtCognoms.setText(actual.getCognoms());
        binding.form.edtNif.setText(actual.getNIF());
//        switch (actual.getSexe()){
//            case DONA:rdoD.setChecked(true);break;
//            case HOME:rdoH.setChecked(true);break;
//            case ALTRES:rdoA.setChecked(true);break;
//        }
        binding.imgPhoto.setImageResource(actual.getImatge());
        RadioButton rb=(RadioButton)binding.form.rdgSexe.getChildAt(actual.getSexe().ordinal());
        rb.setChecked(true);

        binding.form.spnProvincies.setSelection(Provincia.getProvincies().indexOf(actual.getProvincia()));

    }
}