package org.rockyrk.superhero;

import android.os.Bundle;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import org.rockyrk.superhero.adapters.SuperHeroAdapter;
import org.rockyrk.superhero.databinding.ActivityMainBinding;
import org.rockyrk.superhero.viewmodel.SuperHeroViewModel;

public class MainActivity extends AppCompatActivity {
    // Token API → e8a0f887814dbb15ecb1965eed1926b9

    private SuperHeroViewModel superHeroViewModel;

    private SuperHeroAdapter adapter;

    private ActivityMainBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //EdgeToEdge.enable(this);
        //setContentView(R.layout.activity_main);
        //ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
        //    Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
        //    v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
        //    return insets;
        //});
        superHeroViewModel.getSuperhero().observe(() -> {
            adapter=new SuperHeroAdapter();
            binding.grdSuperHero.setAdapter(adapter);
        });
    }
}