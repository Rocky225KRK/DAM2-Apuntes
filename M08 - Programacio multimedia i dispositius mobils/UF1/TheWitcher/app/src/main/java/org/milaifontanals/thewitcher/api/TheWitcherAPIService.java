package org.milaifontanals.thewitcher.api;

import org.jetbrains.annotations.NotNull;

import retrofit2.Retrofit;
import retrofit2.adapter.rxjava3.RxJava3CallAdapterFactory;
import retrofit2.converter.gson.GsonConverterFactory;

public class TheWitcherAPIService {
    @NotNull
    public static TheWitcherAPI getTheWitcherAPI(){
        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl("https://raw.githubusercontent.com/JuanAn6/the_witcher_json/refs/heads/main/")
                .addCallAdapterFactory(RxJava3CallAdapterFactory.create())
                .addConverterFactory(GsonConverterFactory.create())
                .build();

        return retrofit.create(TheWitcherAPI.class);
    }
}