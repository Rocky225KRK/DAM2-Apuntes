
package org.milaifontanals.thewitcher.model;

import java.util.List;
import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Vulnerabilities {

    @SerializedName("bombs")
    @Expose
    private List<String> bombs;
    @SerializedName("oils")
    @Expose
    private List<String> oils;
    @SerializedName("potions")
    @Expose
    private List<String> potions;
    @SerializedName("signs")
    @Expose
    private List<String> signs;

    public List<String> getBombs() {
        return bombs;
    }

    public void setBombs(List<String> bombs) {
        this.bombs = bombs;
    }

    public List<String> getOils() {
        return oils;
    }

    public void setOils(List<String> oils) {
        this.oils = oils;
    }

    public List<String> getPotions() {
        return potions;
    }

    public void setPotions(List<String> potions) {
        this.potions = potions;
    }

    public List<String> getSigns() {
        return signs;
    }

    public void setSigns(List<String> signs) {
        this.signs = signs;
    }

}
