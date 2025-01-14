package org.milaifontanals.thewitcher.model;

import androidx.room.ColumnInfo;
import androidx.room.Entity;
import androidx.room.Index;
import androidx.room.PrimaryKey;

@Entity(tableName = "artifact",
        indices = {@Index(value = "key",unique = true)}
)
public class Artifact {
    public static int BOMBS=1;
    public static int OILS=2;
    public static int POTIONS=3;

    @PrimaryKey
    public int id;

    @ColumnInfo(name = "key")
    public String key;

    @ColumnInfo(name = "name")
    public String name;

    @ColumnInfo(name = "effect")
    public String effect;

    @ColumnInfo(name = "id_type")
    public int id_type;

    @ColumnInfo(name = "image")
    public String image;

    @ColumnInfo(name = "charges")
    public Integer charges;

    @ColumnInfo(name = "duration")
    public Integer duration;

    @ColumnInfo(name = "fire_damage")
    public Integer fire_damage;

    @ColumnInfo(name = "silver_damage")
    public Integer silver_damage;

    @ColumnInfo(name = "phy_damage")
    public Integer phy_damage;

    @Override
    public String toString() {
        return "Artifact{" +
                "key='" + key + '\'' +
                ", name='" + name + '\'' +
                '}';
    }
}
