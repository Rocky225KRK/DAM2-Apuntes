package org.milaifontanals.jsonparser.model;

public class Entry {
    private String title;
    private String image;

    public Entry(String title, String image) {
        this.title = title;
        this.image = image;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
    }
    @Override
    public String toString() {
        return "\n\t\t- Title: "+title+
                "\n\t\t- Image: "+image+"\n";
    }
}
