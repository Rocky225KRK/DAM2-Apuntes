package org.milaifontanals.thewitcher;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.databinding.DataBindingUtil;
import androidx.lifecycle.ViewModelProvider;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import org.milaifontanals.thewitcher.adapters.EntryAdapter;
import org.milaifontanals.thewitcher.adapters.SectionAdapter;
import org.milaifontanals.thewitcher.databinding.ActivityBestiaryBinding;
import org.milaifontanals.thewitcher.model.Section;
import org.milaifontanals.thewitcher.viewmodel.BestiaryViewModel;

public class BestiaryActivity extends AppCompatActivity implements SectionAdapter.SectionAdapterListener {

    private BestiaryViewModel bestiaryViewModel;

    private SectionAdapter sectionAdapter;
    private EntryAdapter entryAdapter;

    private ActivityBestiaryBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding = DataBindingUtil.setContentView(this, R.layout.activity_bestiary);

        bestiaryViewModel = new ViewModelProvider(this).get(BestiaryViewModel.class);

        binding.setViewmodel(bestiaryViewModel);
        binding.setLifecycleOwner(this);

        bestiaryViewModel.getBestiary().observe(this,sections -> {
            Toast.makeText(this, "Sections downloaded: "+sections.getSections().size(), Toast.LENGTH_SHORT).show();
            sectionAdapter =new SectionAdapter(sections,this,this);
            binding.rcySection.setAdapter(sectionAdapter);
        });

        binding.rcySection.setHasFixedSize(true);
        binding.rcySection.setLayoutManager(new LinearLayoutManager(this,RecyclerView.HORIZONTAL,false));

        bestiaryViewModel.getSection().observe(this,sectionEntrySet -> {
            entryAdapter=new EntryAdapter(this,sectionEntrySet.getEntries());
            binding.rcyEntry.setAdapter(entryAdapter);
        });

        binding.rcyEntry.setHasFixedSize(true);
        binding.rcyEntry.setLayoutManager(new LinearLayoutManager(this,RecyclerView.VERTICAL,false));

        binding.txtReturn.setOnClickListener(view -> {
            Intent intent = new Intent(BestiaryActivity.this, MainActivity.class);
            startActivity(intent);
        });
    }

    @Override
    public void onSectionSelected(Section sect) {
        Log.d("selectionTest","Selected: "+ sect.getTitle());
        String path=sect.getTitle().toLowerCase().replace(" ","_");

        bestiaryViewModel.downloadData(path);
    }
}