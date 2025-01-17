package org.rockyrk.examenuf1.db;

import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.Query;
import androidx.room.Update;

import org.rockyrk.examenuf1.model.Product;

import java.util.List;

import io.reactivex.rxjava3.core.Single;

@Dao
public interface ExamDAO {
    @Query("select * from product")
    List<Product> getAllProductsSync();

    @Query("select * from product where catId=:catId")
    Single<List<Product>> getAllProductsByIdCat(int catId);

    @Query("select * from product where catId=:catId")
    List<Product> getAllProductsSyncByIdCat(int catId);

    @Query("select * from product where id=:id")
    Product getProductByIDSync(int id);

    @Insert
    void insertProduct(Product product);

    @Update
    void updateProduct(Product product);

    @Delete
    void deleteProduct(Product product);
}
