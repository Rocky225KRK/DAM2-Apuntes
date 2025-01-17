package org.rockyrk.roomdemo.viewmodel;

import android.app.Application;
import android.util.Log;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.MutableLiveData;
import androidx.room.Room;

import org.rockyrk.roomdemo.db.BestiaryDAO;
import org.rockyrk.roomdemo.db.TheWitchedDB;
import org.rockyrk.roomdemo.db.model.Category;
import org.rockyrk.roomdemo.db.model.Monster;

import java.util.List;
import java.util.concurrent.Callable;

import io.reactivex.rxjava3.android.schedulers.AndroidSchedulers;
import io.reactivex.rxjava3.core.Observable;
import io.reactivex.rxjava3.schedulers.Schedulers;

public class ActivityMainViewModel extends AndroidViewModel {
    MutableLiveData<List<Monster>> monsters=new MutableLiveData<>();
    TheWitchedDB db;
    public ActivityMainViewModel(@NonNull Application application) {
        super(application);
        db= Room.databaseBuilder(
                this.getApplication(),
                TheWitchedDB.class,"database-witcher").build();
        initDB();
    }

    public void initDB(){

        Callable<Boolean> callable = () -> {

            Log.d("XXX", "Abans de fer la consulta");

            int count = db.bestiaryDAO().getMonstersCount();

            Log.d("XXX", "Ciount val:"+count);
            if(count==0) {

                Category category = new Category();
                category.name="Serpentics";
                category .description="Serpents and Co.";
                category.id = (int) db.bestiaryDAO().insertCategory(category);

                Monster golem = new Monster();
                golem.name = "Golem";
                golem.description = "Un golem";
                golem.category_id = category.id;
                db.bestiaryDAO().insertMonster(golem);

                Monster crystallineSerpent = new Monster();
                crystallineSerpent.name = "Crystalline Serpent";
                crystallineSerpent.description = "A serpentine creature formed from shimmering crystals...";
                crystallineSerpent.category_id = category.id;
                db.bestiaryDAO().insertMonster(crystallineSerpent);
            }

            List<Monster> monstersFromDb = db.bestiaryDAO().getAllSync();
            monsters.postValue(monstersFromDb);

            return true;
        };
        Observable<Boolean> o = Observable.fromCallable(callable);

        o.subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(
                        (success) -> {
                            //this.monsters.setValue(queryResult);
                        },
                        error -> {
                            Log.e("XXX", "Error query", error);
                            //this.monsters.setValue(null);
                        }

                );

    }

    public MutableLiveData<List<Monster>> getMonsters() {
        return monsters;
    }
}
