package org.rockyrk.superhero.api;

import org.rockyrk.superhero.model.SuperheroSet;

import io.reactivex.rxjava3.core.Single;
import retrofit2.http.GET;
import retrofit2.http.Path;

public interface SuperHeroAPI {
    @GET("{id}")
    Single<SuperheroSet> getSuperhero(@Path("id") String id);
}
