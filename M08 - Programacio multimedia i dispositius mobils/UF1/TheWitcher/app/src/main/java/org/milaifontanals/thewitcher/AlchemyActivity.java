package org.milaifontanals.thewitcher;

import android.os.Bundle;

import androidx.appcompat.app.AppCompatActivity;

import org.milaifontanals.thewitcher.ui.alchemy.ArtifactFragment;

public class AlchemyActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_alchemy);
        if (savedInstanceState == null) {
            getSupportFragmentManager().beginTransaction()
                    .replace(R.id.container, ArtifactFragment.newInstance())
                    .commitNow();
        }
    }
}