package org.rockyrk.mtgcards.utils;

import android.util.Log;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.URL;

public class NetworkUtils {

    public static String downloadResource(String urlString) throws IOException {
        StringBuilder content = new StringBuilder();
        try (BufferedReader reader = new BufferedReader(new InputStreamReader(
                new URL(urlString).openConnection().getInputStream()))) {
            String line;
            while ((line = reader.readLine()) != null) {
                content.append(line).append('\n');
            }
        }
        Log.d("XXX", content.toString());
        return content.toString();
    }
}