package org.milaifontanals.jsonparser;

import android.os.Bundle;
import android.util.Log;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import org.milaifontanals.jsonparser.adapters.EntryAdapter;
import org.milaifontanals.jsonparser.adapters.SectionAdapter;
import org.milaifontanals.jsonparser.model.BestiaryParser;
import org.milaifontanals.jsonparser.model.Section;

import java.util.List;

public class MainActivity extends AppCompatActivity implements SectionAdapter.SectionAdapterListener {
    RecyclerView rcySection,rcyEntry;
    SectionAdapter sectionAdapter;
    EntryAdapter entryAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        List<Section> bestiary= BestiaryParser.getBestiary(this);
        
        Log.d("WITCHER",bestiary.toString());
        sectionAdapter =new SectionAdapter(this,this);

        rcySection=findViewById(R.id.rcySection);
        rcySection.setLayoutManager(new LinearLayoutManager(this,RecyclerView.HORIZONTAL,false));
        rcySection.setHasFixedSize(true);
        rcySection.setAdapter(sectionAdapter);
    }

    @Override
    public void onSectionSelected(Section section) {
        Log.d("selectionTest","Selected: "+section.toString());
        rcyEntry=findViewById(R.id.rcyEntry);
        rcyEntry.setLayoutManager(new LinearLayoutManager(this,RecyclerView.VERTICAL,false));
        rcyEntry.setHasFixedSize(true);
        entryAdapter=new EntryAdapter(this,section.getEntries());
        rcyEntry.setAdapter(entryAdapter);
    }
}