package org.milaifontanals.recyclerview.view;

import android.os.Bundle;
import android.widget.EditText;

import androidx.appcompat.app.AppCompatActivity;

import com.bumptech.glide.Glide;

import org.milaifontanals.recyclerview.R;
import org.milaifontanals.recyclerview.databinding.ActivityCardBinding;
import org.milaifontanals.recyclerview.model.Card;

public class CardActivity extends AppCompatActivity {
    private Card card;
    public static final String PARAM_CARD="CARD";

    private ActivityCardBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding=ActivityCardBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());


        card=(Card)this.getIntent().getSerializableExtra(PARAM_CARD);
        binding.edtName.setText(card.getName());
        binding.edtName.setText(card.getDesc());
        Glide.with(this).load(card.getImageURL()).into(binding.imvPhoto);
    }
}