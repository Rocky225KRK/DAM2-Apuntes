package org.rockyrk.examenuf1.api;

import org.rockyrk.examenuf1.model.Categories;
import org.rockyrk.examenuf1.model.CategoryEntry;

import io.reactivex.rxjava3.core.Single;
import retrofit2.http.GET;
import retrofit2.http.Path;

public interface ExamAPI {
    @GET("categories.json")
    Single<Categories> getCategories();

    @GET("cat{id_cat}.json")
    Single<CategoryEntry> getCategory(@Path("id_cat") int id_cat);
}
