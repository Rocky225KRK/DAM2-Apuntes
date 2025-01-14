package org.rockyrk.examenuf1.api;

import androidx.annotation.NonNull;

import retrofit2.Retrofit;
import retrofit2.adapter.rxjava3.RxJava3CallAdapterFactory;
import retrofit2.converter.gson.GsonConverterFactory;

public class ExamAPIService {
    public static @NonNull ExamAPI getAPI() {
        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl("https://raw.githubusercontent.com/bernatorellana/products/refs/heads/main/")
                .addCallAdapterFactory(RxJava3CallAdapterFactory.create())
                .addConverterFactory(GsonConverterFactory.create())
                .build();


        ExamAPI service = retrofit.create(ExamAPI.class);
        return service;
    }
}
