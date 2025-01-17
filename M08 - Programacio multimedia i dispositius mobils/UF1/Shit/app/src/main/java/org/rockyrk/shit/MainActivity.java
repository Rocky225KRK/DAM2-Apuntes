package org.rockyrk.shit;

import android.os.Bundle;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.lifecycle.ViewModelProvider;

import org.rockyrk.shit.databinding.ActivityMainBinding;
import org.rockyrk.shit.viewmodels.MainActivityViewModel;

import java.text.DecimalFormat;
import java.text.NumberFormat;

public class MainActivity extends AppCompatActivity {

    ActivityMainBinding binding;
    MainActivityViewModel viewModel;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        viewModel = new ViewModelProvider(this).get(MainActivityViewModel.class);

        binding = ActivityMainBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        binding.txvLocal.setText(""+viewModel.getScoreLocal());
        binding.txvVisitant.setText(""+viewModel.getScoreVisitant());
        showTime();

        viewModel.getTime().observe(this,date -> {
            showTime(); // actualitza la data
        });


        binding.btnVisitant.setOnClickListener(view -> incVisitant(+1) );

        binding.btnVisitant.setOnLongClickListener(view -> {
            incVisitant(-1);return true;
        } );

        binding.btnLocal.setOnClickListener(view -> incLocal(+1)
        );
        binding.btnLocal.setOnLongClickListener(view -> {
            incLocal(-1);return true;
        } );


        EdgeToEdge.enable(this);
        //setContentView(R.layout.activity_main);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });


        viewModel.resumeTimer();

    }


    private void showTime() {
        DecimalFormat df = new DecimalFormat("00");
        binding.txvCrono.setText(
                df.format(viewModel.getTime().getValue().getMinutes())
                +":"+
                df.format(viewModel.getTime().getValue().getSeconds())
        );
    }

    private void incVisitant(int inc) {
        //scoreVisitant+=inc;
        viewModel.incScoreVisitant(inc);
        binding.txvVisitant.setText(""+viewModel.getScoreVisitant());
    }

    private void incLocal(int inc) {
        //scoreLocal+=inc;
        viewModel.incScoreLocal(inc);
        binding.txvLocal.setText(""+viewModel.getScoreLocal());
    }
}