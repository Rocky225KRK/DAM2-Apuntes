package org.rockyrk.examenuf1.db;


import androidx.room.Database;
import androidx.room.RoomDatabase;

import org.rockyrk.examenuf1.model.Product;

@Database(entities = {Product.class},version = 1)
public abstract class ExamDB extends RoomDatabase {
    public abstract ExamDAO examDAO();
}
