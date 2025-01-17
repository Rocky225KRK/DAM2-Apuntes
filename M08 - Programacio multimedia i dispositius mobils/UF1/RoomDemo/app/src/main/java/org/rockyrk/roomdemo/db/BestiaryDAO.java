package org.rockyrk.roomdemo.db;

import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.Query;
import androidx.room.Update;

import org.rockyrk.roomdemo.db.model.Category;
import org.rockyrk.roomdemo.db.model.Monster;

import java.util.List;

import io.reactivex.rxjava3.core.Single;

@Dao
public interface BestiaryDAO {
    @Query("SELECT count(id) FROM monster")
    int getMonstersCount();

    @Query("SELECT * FROM monster")
    Single<List<Monster>> getAll();

    @Query("SELECT * FROM monster")
    List<Monster> getAllSync();

    @Query("SELECT * FROM monster WHERE id LIKE :id")
    List<Monster> getMonsterById(String id);

    @Query("SELECT * FROM monster WHERE name LIKE :name")
    List<Monster> getMonsterByName(String name);

    @Delete
    void deleteMonster(Monster monster);

    @Update
    void updateMonster(Monster monster);

    @Insert
    void insertMonster(Monster monster);

    @Query("SELECT * FROM category")
    List<Category> getAllCategories();

    @Query("SELECT * FROM category WHERE id = :id")
    List<Category> getCategoryById(int id);

    @Delete
    void deleteCategory(Category category);

    @Update
    void updateCategory(Category category);

    @Insert
    long insertCategory(Category category);
}
