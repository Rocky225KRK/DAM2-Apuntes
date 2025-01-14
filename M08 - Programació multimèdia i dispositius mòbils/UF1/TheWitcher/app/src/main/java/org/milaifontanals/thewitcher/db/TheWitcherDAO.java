package org.milaifontanals.thewitcher.db;

import androidx.room.Dao;
import androidx.room.Query;
import androidx.room.Update;

import org.milaifontanals.thewitcher.model.Artifact;
import org.milaifontanals.thewitcher.model.Ingredient;

import java.util.List;

import io.reactivex.rxjava3.core.Single;

@Dao
public interface TheWitcherDAO {
    @Query("select count(id) from artifact")
    int getArtifactsCount();

    @Query("select count(id) from ingredient")
    int getIngredientsCount();

    @Query("select * from artifact")
    List<Artifact> getAllArtifactsSync();

    @Query("select * from artifact")
    Single<List<Artifact>> getAllArtifacts();

    @Query("select * from artifact where id=:id")
    Artifact getArtifactById(int id);

    @Query("select * from artifact where id_type=:id")
    List<Artifact> getArtifactByType(int id);

    @Query("select * from ingredient")
    List<Ingredient> getAllIngredientsSync();

    @Query("select * from ingredient")
    Single<List<Ingredient>> getAllIngredients();

    @Update
    void updateArtifact(Artifact artifact);
}
