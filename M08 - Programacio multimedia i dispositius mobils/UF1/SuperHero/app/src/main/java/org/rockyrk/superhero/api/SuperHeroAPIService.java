package org.rockyrk.superhero.api;

import org.jetbrains.annotations.NotNull;

import retrofit2.Retrofit;
import retrofit2.adapter.rxjava3.RxJava3CallAdapterFactory;
import retrofit2.converter.gson.GsonConverterFactory;

public class SuperHeroAPIService {
    @NotNull
    public static SuperHeroAPI getSuperHeroAPI(){
        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl("https://www.superheroapi.com/api.php/e8a0f887814dbb15ecb1965eed1926b9/")
                .addCallAdapterFactory(RxJava3CallAdapterFactory.create())
                .addConverterFactory(GsonConverterFactory.create())
                .build();

        return retrofit.create(SuperHeroAPI.class);
    }
}
