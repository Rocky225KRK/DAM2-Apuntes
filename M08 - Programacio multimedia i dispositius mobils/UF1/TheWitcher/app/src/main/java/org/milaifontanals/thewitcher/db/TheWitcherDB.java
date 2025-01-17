package org.milaifontanals.thewitcher.db;

import androidx.room.Database;
import androidx.room.RoomDatabase;

import org.milaifontanals.thewitcher.model.Artifact;
import org.milaifontanals.thewitcher.model.Ingredient;

@Database(entities = {Artifact.class, Ingredient.class},version = 1)
public abstract class TheWitcherDB extends RoomDatabase {
    public abstract TheWitcherDAO theWitcherDAO();
}
