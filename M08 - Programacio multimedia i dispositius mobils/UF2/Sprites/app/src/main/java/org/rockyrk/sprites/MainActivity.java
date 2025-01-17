package org.rockyrk.sprites;

import android.animation.Animator;
import android.animation.AnimatorListenerAdapter;
import android.animation.AnimatorSet;
import android.animation.ObjectAnimator;
import android.graphics.drawable.AnimationDrawable;
import android.os.Bundle;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import org.rockyrk.sprites.databinding.ActivityMainBinding;

public class MainActivity extends AppCompatActivity {

    ActivityMainBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        //setContentView(R.layout.activity_main);

        binding=ActivityMainBinding.inflate(this.getLayoutInflater());
        setContentView(binding.getRoot());

        binding.getRoot().getViewTreeObserver().addOnGlobalLayoutListener(() -> {
            //binding.imvWorm.setImageResource(R.drawable.worm_animation);
            //binding.imvWorm.getAnimation().start();
            AnimationDrawable ad=(AnimationDrawable)binding.imvWorm.getDrawable();
            ad.start();

            /*ObjectAnimator animator=ObjectAnimator.ofFloat(
                    binding.imvWorm,"translationX",
                    -(this.getWindowManager().getDefaultDisplay().getWidth()-binding.imvWorm.getWidth())
            );*/
            ObjectAnimator rotator=ObjectAnimator.ofFloat(
                    binding.imvWorm,"rotation",3200000).setDuration(100000);

            ObjectAnimator animator1=ObjectAnimator.ofFloat(
                    binding.imvWorm,"X",0).setDuration(2000);

            ObjectAnimator animator2=ObjectAnimator.ofFloat(
                    binding.imvWorm,"rotation",90).setDuration(1000);

            ObjectAnimator animator3=ObjectAnimator.ofFloat(
                    binding.imvWorm,"Y",0).setDuration(2000);

            ObjectAnimator animator4=ObjectAnimator.ofFloat(
                    binding.imvWorm,"rotation",180).setDuration(1000);

            ObjectAnimator animator5=ObjectAnimator.ofFloat(
                    binding.imvWorm,"X",this.getWindowManager().getDefaultDisplay().getWidth()-binding.imvWorm.getWidth()).setDuration(2000);

            ObjectAnimator animator6=ObjectAnimator.ofFloat(
                    binding.imvWorm,"rotation",270).setDuration(1000);

            ObjectAnimator animator7=ObjectAnimator.ofFloat(
                    binding.imvWorm,"Y",this.getWindowManager().getDefaultDisplay().getHeight()-binding.imvWorm.getHeight()).setDuration(2000);

            ObjectAnimator animator8=ObjectAnimator.ofFloat(
                    binding.imvWorm,"rotation",360).setDuration(1000);


            /*ObjectAnimator x=ObjectAnimator.ofFloat(
                    binding.imvWorm,"X",0).setDuration(2000);

            ObjectAnimator y=ObjectAnimator.ofFloat(
                    binding.imvWorm,"Y",0).setDuration(2000);

            AnimatorSet xy=new AnimatorSet();
            xy.play(x).with(y);
            xy.start();*/

            AnimatorSet set=new AnimatorSet();
            //set.play(animator1).with(rotator);
            set.playSequentially(animator1,animator2,animator3,animator4,animator5,animator6,animator7,animator8);
            set.start();
            set.addListener(new AnimatorListenerAdapter() {
                @Override
                public void onAnimationEnd(Animator animation) {
                    super.onAnimationEnd(animation);
                    set.start();
                }
            });
        });
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
    }
}