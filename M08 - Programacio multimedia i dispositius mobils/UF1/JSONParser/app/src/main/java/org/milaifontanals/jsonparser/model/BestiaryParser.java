package org.milaifontanals.jsonparser.model;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.milaifontanals.jsonparser.R;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;
import android.content.Context;
import android.util.Log;

public class BestiaryParser {
    public static List<Section> getBestiary(Context c){
        List<Section> bestiary=new ArrayList<>();
        // 0.-  Llegir arxiu JSON i posar-lo en una cadena
        String json=readJson(c);

        // 1.-  Passejar JSON i recórrer les Sections
        try {
            JSONObject arrel=new JSONObject(json);
            JSONArray sections=arrel.getJSONArray("sections");
            for (int s = 0; s < sections.length(); s++) {
                JSONObject section=sections.getJSONObject(s);
                String title=section.getString("title");
                String subtitle=section.getString("subtitle");
                String image=section.getString("image");

                Section sec=new Section(title,subtitle,image);

                // 2.- Per cada Section, buscar les Entries
                JSONArray entries=section.getJSONArray("entries");
                for (int e = 0; e < entries.length(); e++) {
                    JSONObject entry=entries.getJSONObject(e);
                    title=entry.getString("title");
                    image=entry.getString("image");

                    Entry ent=new Entry(title,image);
                    sec.getEntries().add(ent);
                }
                bestiary.add(sec);
            }
        } catch (JSONException e) {
            Log.e("WITCHER","Error parejant JSON",e);
            return null;
        }

        return bestiary;
    }

    private static String readJson(Context c) {
        String json="";
        try {
            InputStream is= c.getResources().openRawResource(R.raw.bestiary);
            BufferedReader br=new BufferedReader(new InputStreamReader(is));
            String line;
            while((line=br.readLine())!=null){
                json +=line+"\n";
            }
            //Log.d("WITCHER", json);

            return json;
        }catch (IOException e) {
            Log.e("WITCHER","Error llegint JSON",e);
            return null;
        }
    }
}
