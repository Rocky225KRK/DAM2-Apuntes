package org.rockyrk.flipanimation;

import android.os.Bundle;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.cardview.widget.CardView;

import org.rockyrk.flipanimation.databinding.ActivityMainBinding;

public class MainActivity extends AppCompatActivity {

    ActivityMainBinding binding;

    CardView current,other;
    int signe=-1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);

        binding=ActivityMainBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        int distance=1900;
        float scale=getResources().getDisplayMetrics().density;

        current=binding.cardFront;
        other=binding.cardBack;

        current.setCameraDistance(distance*scale);
        other.setCameraDistance(distance*scale);

        binding.cardFront.setOnClickListener(view -> {

            current.animate().rotationY(signe *180).alpha(0).setDuration(500).start();
            other.animate().rotationY(0).alpha(1).setDuration(500).start();

            signe *=-1;
            CardView tmp=other;
            other=current;
            current=tmp;
        });
    }
}