package org.milaifontanals.thewitcher.viewmodel;

import android.app.Application;
import android.util.Log;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.MutableLiveData;
import androidx.room.Room;

import org.milaifontanals.thewitcher.db.TheWitcherDB;
import org.milaifontanals.thewitcher.model.Artifact;

import java.util.List;
import java.util.concurrent.Callable;

import io.reactivex.rxjava3.android.schedulers.AndroidSchedulers;
import io.reactivex.rxjava3.core.Observable;
import io.reactivex.rxjava3.schedulers.Schedulers;

public class ArtifactViewModel extends AndroidViewModel {

    private TheWitcherDB db;
    private MutableLiveData<List<Artifact>> artifacts=new MutableLiveData<>();

    public ArtifactViewModel(@NonNull Application application) {
        super(application);
        initDB();
    }

    private void initDB() {
        Callable<Boolean> callable=() -> {
            //db= Room.databaseBuilder(
            //        this.getApplication(),
            //        TheWitcherDB.class,"database-witcher").build();
//
            //if(db.theWitcherDAO().getArtifactsCount()==0||db.theWitcherDAO().getIngredientsCount()==0){
                db= Room.databaseBuilder(
                        this.getApplication(),
                        TheWitcherDB.class,"database-witcher").createFromAsset("artifact_database.db").build();
            //}

            return true;
        };

        Observable<Boolean> o=Observable.fromCallable(callable);
        o.subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(
                        (success)->{

                        },
                        error->{
                            Log.e("TWError","Error: ",error);
                        }
                );
    }

    public void updateData(int type){
        Callable<Boolean> callable=() -> {
            List<Artifact> list=db.theWitcherDAO().getArtifactByType(type);
            artifacts.postValue(list);

            return true;
        };

        Observable<Boolean> o=Observable.fromCallable(callable);
        o.subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(
                        (success)->{
                            Log.d("TWSuccess","Success on updating with type "+type);
                        },
                        error->{
                            Log.e("TWError","Error: ",error);
                        }
                );
    }

    public MutableLiveData<List<Artifact>> getArtifacts() {
        return artifacts;
    }
}
