package org.milaifontanals.thewitcher.viewmodel;

import android.app.Application;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.MutableLiveData;

import org.milaifontanals.thewitcher.api.TheWitcherAPI;
import org.milaifontanals.thewitcher.api.TheWitcherAPIService;
import org.milaifontanals.thewitcher.model.SectionEntrySet;
import org.milaifontanals.thewitcher.model.SectionsSet;

import io.reactivex.rxjava3.android.schedulers.AndroidSchedulers;
import io.reactivex.rxjava3.schedulers.Schedulers;

public class BestiaryViewModel extends AndroidViewModel {

    private MutableLiveData<SectionsSet> bestiary;
    private MutableLiveData<SectionEntrySet> section;

    public BestiaryViewModel(@NonNull Application application) {
        super(application);
        bestiary=new MutableLiveData<>();
        section=new MutableLiveData<>();
        downloadData();
    }

    public void downloadData(){
        if(bestiary.getValue()!=null) return;;

        TheWitcherAPI service= TheWitcherAPIService.getTheWitcherAPI();

        service.getSections().subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(
                        (result)->{
                            bestiary.setValue(result);
                        },
                        error->{
                            bestiary.setValue(null);
                        }
                );
    }

    public void downloadData(String sectionPath){
        TheWitcherAPI service= TheWitcherAPIService.getTheWitcherAPI();

        service.getSection(sectionPath).subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(
                        (result)->{
                            section.setValue(result);
                        },
                        error->{
                            bestiary.setValue(null);
                        }
                );
    }

    public MutableLiveData<SectionsSet> getBestiary(){
        return bestiary;
    }

    public MutableLiveData<SectionEntrySet> getSection() {
        return section;
    }
}
