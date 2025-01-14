
package org.milaifontanals.thewitcher.model;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Entry {

    @SerializedName("title")
    @Expose
    private String title;
    @SerializedName("intro")
    @Expose
    private String intro;
    @SerializedName("author")
    @Expose
    private String author;
    @SerializedName("detail")
    @Expose
    private String detail;
    @SerializedName("image")
    @Expose
    private String image;
    @SerializedName("vulnerabilities")
    @Expose
    private Vulnerabilities vulnerabilities;
    @SerializedName("expansion")
    @Expose
    private String expansion;

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getIntro() {
        return intro;
    }

    public void setIntro(String intro) {
        this.intro = intro;
    }

    public String getAuthor() {
        return author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public String getDetail() {
        return detail;
    }

    public void setDetail(String detail) {
        this.detail = detail;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
    }

    public Vulnerabilities getVulnerabilities() {
        return vulnerabilities;
    }

    public void setVulnerabilities(Vulnerabilities vulnerabilities) {
        this.vulnerabilities = vulnerabilities;
    }

    public String getExpansion() {
        return expansion;
    }

    public void setExpansion(String expansion) {
        this.expansion = expansion;
    }

}
