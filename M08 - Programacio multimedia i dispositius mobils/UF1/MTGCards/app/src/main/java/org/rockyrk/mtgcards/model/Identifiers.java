
package org.rockyrk.mtgcards.model;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Identifiers {

    @SerializedName("scryfallId")
    @Expose
    private String scryfallId;
    @SerializedName("multiverseId")
    @Expose
    private Integer multiverseId;

    public String getScryfallId() {
        return scryfallId;
    }

    public void setScryfallId(String scryfallId) {
        this.scryfallId = scryfallId;
    }

    public Integer getMultiverseId() {
        return multiverseId;
    }

    public void setMultiverseId(Integer multiverseId) {
        this.multiverseId = multiverseId;
    }

}
