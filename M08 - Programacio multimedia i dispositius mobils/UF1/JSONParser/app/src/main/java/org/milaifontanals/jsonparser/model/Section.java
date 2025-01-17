package org.milaifontanals.jsonparser.model;

import java.util.ArrayList;
import java.util.List;

public class Section {
    private String title;
    private String subtitle;
    private String image;
    private List<Entry> entries;

    public Section(String title, String subtitle, String image) {
        this.title = title;
        this.subtitle = subtitle;
        this.image = image;

        entries=new ArrayList<>();
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getSubtitle() {
        return subtitle;
    }

    public void setSubtitle(String subtitle) {
        this.subtitle = subtitle;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
    }

    public List<Entry> getEntries() {
        return entries;
    }

    @Override
    public String toString() {
        return "- Section:" +
                "\n\t- Title: "+title+
                "\n\t- Subtitle: "+title+
                "\n\t- Image: "+image+
                "\n\t- Entries: "+entries+"\n";
    }
}
