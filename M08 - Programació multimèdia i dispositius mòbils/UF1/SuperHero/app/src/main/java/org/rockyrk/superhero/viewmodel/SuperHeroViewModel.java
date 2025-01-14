package org.rockyrk.superhero.viewmodel;

import android.app.Application;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.MutableLiveData;

import org.rockyrk.superhero.api.SuperHeroAPI;
import org.rockyrk.superhero.api.SuperHeroAPIService;
import org.rockyrk.superhero.model.SuperheroSet;

import io.reactivex.rxjava3.android.schedulers.AndroidSchedulers;
import io.reactivex.rxjava3.schedulers.Schedulers;

public class SuperHeroViewModel extends AndroidViewModel {
    private MutableLiveData<SuperheroSet> superhero;


    public SuperHeroViewModel(@NonNull Application application) {
        super(application);
        superhero=new MutableLiveData<>();
    }

    public MutableLiveData<SuperheroSet> getSuperhero() {
        return superhero;
    }

    public void downloadData(int id){
        SuperHeroAPI service= SuperHeroAPIService.getSuperHeroAPI();

        service.getSuperhero(id+"").subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(
                        (result)->{
                            superhero.setValue(result);
                        },
                        error->{
                            superhero.setValue(null);
                        }
                );
    }
}
