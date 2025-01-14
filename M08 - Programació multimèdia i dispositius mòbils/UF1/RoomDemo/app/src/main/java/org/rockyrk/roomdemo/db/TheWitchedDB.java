package org.rockyrk.roomdemo.db;

import androidx.room.Database;
import androidx.room.RoomDatabase;

import org.rockyrk.roomdemo.db.model.Category;
import org.rockyrk.roomdemo.db.model.Monster;

@Database(entities = {Monster.class, Category.class},version = 1)
public abstract class TheWitchedDB extends RoomDatabase {
    public abstract BestiaryDAO bestiaryDAO();
}
