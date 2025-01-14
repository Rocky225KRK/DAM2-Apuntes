package org.milaifontanals.thewitcher.api;

import org.milaifontanals.thewitcher.model.SectionEntrySet;
import org.milaifontanals.thewitcher.model.SectionsSet;

import io.reactivex.rxjava3.core.Single;
import retrofit2.http.GET;
import retrofit2.http.Path;

public interface TheWitcherAPI {
    @GET("sections.json")
    Single<SectionsSet> getSections();

    @GET("sections/{section}.json")
    Single<SectionEntrySet> getSection(@Path("section") String section);
}
