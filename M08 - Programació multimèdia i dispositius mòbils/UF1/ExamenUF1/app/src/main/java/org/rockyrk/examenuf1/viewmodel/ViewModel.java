package org.rockyrk.examenuf1.viewmodel;

import android.app.Application;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.MutableLiveData;
import androidx.room.Room;

import org.rockyrk.examenuf1.api.ExamAPI;
import org.rockyrk.examenuf1.api.ExamAPIService;
import org.rockyrk.examenuf1.db.ExamDAO;
import org.rockyrk.examenuf1.db.ExamDB;
import org.rockyrk.examenuf1.model.Categories;
import org.rockyrk.examenuf1.model.CategoryEntry;
import org.rockyrk.examenuf1.model.Product;

import java.util.List;
import java.util.concurrent.Callable;

import io.reactivex.rxjava3.android.schedulers.AndroidSchedulers;
import io.reactivex.rxjava3.core.Observable;
import io.reactivex.rxjava3.schedulers.Schedulers;

public class ViewModel extends AndroidViewModel {
    private MutableLiveData<Categories> allCategories;
    private MutableLiveData<CategoryEntry> category;
    private MutableLiveData<List<Product>> products;

    private ExamDB db;

    public ViewModel(@NonNull Application application) {
        super(application);
        allCategories=new MutableLiveData<>();
        category=new MutableLiveData<>();
        downloadData();

        db= Room.databaseBuilder(application, ExamDB.class,"exam").build();
    }

    public MutableLiveData<Categories> getAllCategories() {
        return allCategories;
    }

    public MutableLiveData<CategoryEntry> getCategory() {
        return category;
    }

    public ExamDB getDb() {
        return db;
    }

    public void downloadData(){
        if(allCategories.getValue()!=null) return;
        ExamAPI service= ExamAPIService.getAPI();

        service.getCategories().subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(
                        (result)->{
                            allCategories.setValue(result);
                        },
                        error->{
                            allCategories.setValue(null);
                        }
                );
    }

    public void downloadData(int id_cat){
        ExamAPI service= ExamAPIService.getAPI();
        ExamDAO examDAO=db.examDAO();

        service.getCategory(id_cat).subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(
                        (result)->{
                            category.setValue(result);
                        },
                        error->{
                            category.setValue(null);
                        }
                );


        //Callable<CategoryEntry> callable=() -> {
        //    CategoryEntry ce=new CategoryEntry();
        //    ce.setProducts(examDAO.getAllProductsSyncByIdCat(id_cat));
        //    return ce;
        //};

        //Observable<CategoryEntry> o = Observable.fromCallable(callable);
        //o.subscribeOn(Schedulers.io())
        //    .observeOn(AndroidSchedulers.mainThread())
        //    .subscribe(
        //            (result)->{
        //                category.setValue(result);
        //            },
        //            error->{
        //                category.setValue(null);
        //            }
        //    );



    }
}
