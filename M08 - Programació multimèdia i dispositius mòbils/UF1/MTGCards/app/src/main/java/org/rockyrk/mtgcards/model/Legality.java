
package org.rockyrk.mtgcards.model;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Legality {

    @SerializedName("format")
    @Expose
    private String format;
    @SerializedName("legality")
    @Expose
    private String legality;

    public String getFormat() {
        return format;
    }

    public void setFormat(String format) {
        this.format = format;
    }

    public String getLegality() {
        return legality;
    }

    public void setLegality(String legality) {
        this.legality = legality;
    }

}
