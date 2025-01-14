
package org.rockyrk.examenuf1.model;

import androidx.annotation.NonNull;
import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.PrimaryKey;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

@Entity(tableName = "product")
public class Product {

    @SerializedName("id")
    @Expose
    @PrimaryKey()
    @NonNull()
    private Integer id;
    @SerializedName("catId")
    @Expose
    @ColumnInfo(name = "catId")
    private Integer catId;
    @SerializedName("name")
    @Expose
    @ColumnInfo(name = "name")
    private String name;
    @SerializedName("price")
    @Expose
    @ColumnInfo(name = "price")
    private Double price;
    @SerializedName("stock")
    @Expose
    @ColumnInfo(name = "stock")
    private Integer stock;

    @ColumnInfo(name = "qty")
    private Integer qtySelected=0;



    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Integer getCatId() {
        return catId;
    }

    public void setCatId(Integer catId) {
        this.catId = catId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Double getPrice() {
        return price;
    }

    public void setPrice(Double price) {
        this.price = price;
    }

    public Integer getStock() {
        return stock;
    }

    public void setStock(Integer stock) {
        this.stock = stock;
    }

    public Integer getQtySelected() {
        return qtySelected;
    }

    public void setQtySelected(Integer qtySelected) {
        this.qtySelected = qtySelected;
    }
}
