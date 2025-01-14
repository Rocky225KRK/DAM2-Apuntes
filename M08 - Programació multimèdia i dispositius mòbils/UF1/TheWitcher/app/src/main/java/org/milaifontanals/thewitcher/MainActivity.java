package org.milaifontanals.thewitcher;

import android.content.Intent;
import android.os.Bundle;

import androidx.appcompat.app.AppCompatActivity;
import androidx.databinding.DataBindingUtil;

import org.milaifontanals.thewitcher.databinding.ActivityMainBinding;

public class MainActivity extends AppCompatActivity {
    private ActivityMainBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.fragment_editor);

        binding=DataBindingUtil.setContentView(this,R.layout.activity_main);

        binding.btnBestiary.setOnClickListener(view -> {
            Intent intent = new Intent(MainActivity.this, BestiaryActivity.class);
            startActivity(intent);
        });

        binding.btnAlchemy.setOnClickListener(view -> {
            Intent intent = new Intent(MainActivity.this, AlchemyActivity.class);
            startActivity(intent);
        });
    }
}