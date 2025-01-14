
package org.rockyrk.superhero.model;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Work {

    @SerializedName("occupation")
    @Expose
    private String occupation;
    @SerializedName("base")
    @Expose
    private String base;

    public String getOccupation() {
        return occupation;
    }

    public void setOccupation(String occupation) {
        this.occupation = occupation;
    }

    public String getBase() {
        return base;
    }

    public void setBase(String base) {
        this.base = base;
    }

}
