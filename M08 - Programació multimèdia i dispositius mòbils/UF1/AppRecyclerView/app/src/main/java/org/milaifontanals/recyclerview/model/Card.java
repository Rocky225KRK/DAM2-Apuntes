package org.milaifontanals.recyclerview.model;

import android.graphics.Bitmap;

import org.milaifontanals.recyclerview.R;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

public class Card implements Serializable
{
    Rarity rarity;
    int id;
    String name;
    //int drawable;
    String desc;
    int elixirCost;
    boolean selected;
    String imageURL;

    public Bitmap getBitmap() {
        return bitmap;
    }

    public void setBitmap(Bitmap bitmap) {
        this.bitmap = bitmap;
        imageURL = null;
    }

    Bitmap bitmap;


    public Card(int id,  String nom, Rarity raresa, String imageURL,  String desc, int elixirCost) {
        this.rarity = raresa;
        this.id = id;
        this.name = nom;
        //this.drawable = drawable;
        this.imageURL = imageURL;
        this.bitmap = null;
        this.desc = desc;
        this.elixirCost = elixirCost;
    }

    private static ArrayList<Card> _cartes ;



    public static List<Card> getCartes(){

        if(_cartes==null) {
            _cartes = new ArrayList<Card>();
            _cartes.add(new Card(1, "Prince", Rarity.EPIC,
                    "http://raw.githubusercontent.com/bernatorellana/ICB0_M08_PMDM_Samples_21_22/main/UF1/20220211_RecyclerView/app/src/main/res/drawable/prince.png",
                    "Don't let the little pony fool you. Once the Prince gets a running start, you WILL be trampled. Deals double damage once he gets charging. ",
                    5 ));
            _cartes.add(new Card(2, "Skeleton Army", Rarity.RARE,
                    "http://raw.githubusercontent.com/bernatorellana/ICB0_M08_PMDM_Samples_21_22/main/UF1/20220211_RecyclerView/app/src/main/res/drawable/skeletons.png",
                    " Spawns an army of Skeletons. Meet Larry and his friends Harry, Gerry, Terry, Mary, etc. ",
                    3 ));
            _cartes.add(new Card(3, "Giant", Rarity.RARE, "http://raw.githubusercontent.com/bernatorellana/ICB0_M08_PMDM_Samples_21_22/main/UF1/20220211_RecyclerView/app/src/main/res/drawable/giant.png",
                    " Slow but durable, only attacks buildings. A real one-man wrecking crew!  ",
                    5 ));
            _cartes.add(new Card(4, "Spear Goblins", Rarity.COMMON, "http://raw.githubusercontent.com/bernatorellana/ICB0_M08_PMDM_Samples_21_22/main/UF1/20220211_RecyclerView/app/src/main/res/drawable/spear_goblins.png",
                    " Three unarmored ranged attackers. Who the heck taught these guys to throw spears!? Who thought that was a good idea?!   ",
                    2 ));
            _cartes.add(new Card(1, "Prince", Rarity.EPIC,
                    "http://raw.githubusercontent.com/bernatorellana/ICB0_M08_PMDM_Samples_21_22/main/UF1/20220211_RecyclerView/app/src/main/res/drawable/prince.png",
                    "Don't let the little pony fool you. Once the Prince gets a running start, you WILL be trampled. Deals double damage once he gets charging. ",
                    5 ));
            _cartes.add(new Card(2, "Skeleton Army", Rarity.RARE,
                    "http://raw.githubusercontent.com/bernatorellana/ICB0_M08_PMDM_Samples_21_22/main/UF1/20220211_RecyclerView/app/src/main/res/drawable/skeletons.png",
                    " Spawns an army of Skeletons. Meet Larry and his friends Harry, Gerry, Terry, Mary, etc. ",
                    3 ));
            _cartes.add(new Card(3, "Giant", Rarity.RARE, "http://raw.githubusercontent.com/bernatorellana/ICB0_M08_PMDM_Samples_21_22/main/UF1/20220211_RecyclerView/app/src/main/res/drawable/giant.png",
                    " Slow but durable, only attacks buildings. A real one-man wrecking crew!  ",
                    5 ));
            _cartes.add(new Card(4, "Spear Goblins", Rarity.COMMON, "http://raw.githubusercontent.com/bernatorellana/ICB0_M08_PMDM_Samples_21_22/main/UF1/20220211_RecyclerView/app/src/main/res/drawable/spear_goblins.png",
                    " Three unarmored ranged attackers. Who the heck taught these guys to throw spears!? Who thought that was a good idea?!   ",
                    2 ));
        }

        return _cartes;

    }

    public Rarity getRarity() {
        return rarity;
    }

    public void setRarity(Rarity rarity) {
        this.rarity = rarity;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getImageURL() {
        return this.imageURL;
    }


    public String getDesc() {
        return desc;
    }

    public void setDesc(String desc) {
        this.desc = desc;
    }

    public int getElixirCost() {
        return elixirCost;
    }

    public void setElixirCost(int elixirCost) {
        this.elixirCost = elixirCost;
    }

    public boolean isSelected() {
        return selected;
    }

    public void setSelected(boolean selected) {
        this.selected = selected;
    }

    public void switchSelected() {
        this.selected = !selected;
    }

}