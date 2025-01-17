package org.milaifontanals.thewitcher.viewmodel;

import android.app.Application;
import android.util.Log;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.MutableLiveData;
import androidx.room.Room;

import org.milaifontanals.thewitcher.db.TheWitcherDB;
import org.milaifontanals.thewitcher.model.Artifact;
import org.milaifontanals.thewitcher.model.Ingredient;
import org.milaifontanals.thewitcher.model.Tuple;

import java.util.List;
import java.util.concurrent.Callable;

import io.reactivex.rxjava3.android.schedulers.AndroidSchedulers;
import io.reactivex.rxjava3.core.Observable;
import io.reactivex.rxjava3.schedulers.Schedulers;

public class EditorViewModel extends AndroidViewModel {

    private TheWitcherDB db;
    private MutableLiveData<Artifact> artifact=new MutableLiveData<>();
    private MutableLiveData<List<Ingredient>> ingredients=new MutableLiveData<>();
    private MutableLiveData<List<Tuple<Ingredient,Integer>>> selIngredients=new MutableLiveData<>();

    public EditorViewModel(@NonNull Application application) {
        super(application);
        db= Room.databaseBuilder(
                this.getApplication(),
                TheWitcherDB.class,"database-witcher").build();

        getIngredientsDB();
    }

    public void getIngredientsDB(){
        Callable<Boolean> callable=() -> {
            List<Ingredient> ingredientList=db.theWitcherDAO().getAllIngredientsSync();
            ingredients.postValue(ingredientList);
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

    public void getArtifactById(int id){
        Callable<Artifact> callable=() -> db.theWitcherDAO().getArtifactById(id);

        Observable<Artifact> o=Observable.fromCallable(callable);
        o.subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(
                        (success)->{
                            artifact.setValue(success);
                        },
                        error->{
                            Log.e("TWError","Error: ",error);
                            artifact.setValue(null);
                        }
                );
    }

    public void updateArtifact(Artifact artifact){
        Callable<Boolean> callable=() -> {
            db.theWitcherDAO().updateArtifact(artifact);
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

    public MutableLiveData<Artifact> getArtifact() {
        return artifact;
    }

    public MutableLiveData<List<Ingredient>> getIngredients() {
        return ingredients;
    }

    public MutableLiveData<List<Tuple<Ingredient,Integer>>> getSelIngredients() {
        return selIngredients;
    }
}
