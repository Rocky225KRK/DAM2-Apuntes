package org.rockyrk.mtgcards.viewmodel;

import android.app.Application;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;

import com.google.gson.Gson;

import org.rockyrk.mtgcards.MainActivity;
import org.rockyrk.mtgcards.model.Card;
import org.rockyrk.mtgcards.model.Example;
import org.rockyrk.mtgcards.utils.NetworkUtils;

import java.util.List;
import java.util.concurrent.Callable;

import io.reactivex.rxjava3.android.schedulers.AndroidSchedulers;
import io.reactivex.rxjava3.core.Observable;
import io.reactivex.rxjava3.schedulers.Schedulers;

public class MainActivityViewModel extends AndroidViewModel {

    private MutableLiveData<List<Card>> cardList;

    public MainActivityViewModel(@NonNull Application application) {
        super(application);
        cardList = new MutableLiveData<>();
        descarregaCartes();
    }

    public LiveData<List<Card>> getCardList() {
        return cardList;
    }

    private void descarregaCartes(){
        if(cardList.getValue()!=null) return;

        Callable<List<Card>> callable = () -> {
            String json = NetworkUtils.downloadResource("https://api.magicthegathering.io/v1/cards");

            Gson gson = new Gson();
            Example e = gson.fromJson(json, Example.class);
            return e.getCards();
        };

        Observable<List<Card>> observable = Observable.fromCallable(callable);
        observable.subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(
                        (result) -> {
                            cardList.setValue(result);
                        },
                        error -> {
                            cardList.setValue(null);
                        }

                );
    }

}
