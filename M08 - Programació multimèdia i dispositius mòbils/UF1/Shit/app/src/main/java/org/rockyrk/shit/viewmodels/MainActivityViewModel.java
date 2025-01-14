package org.rockyrk.shit.viewmodels;

import android.app.Application;
import android.content.Context;
import android.content.SharedPreferences;
import android.util.Log;

import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import java.util.Date;

public class MainActivityViewModel extends AndroidViewModel {
    public static final String LOCAL = "LOCAL"; // Si voleu context, cal heretar de AndroidViewModel: ViewModel no té accés al context
    public static final String VISITANT = "VISITANT";
    public static final String TIME = "TIME";

    private Thread t;
    boolean timerFinalitzat =false;

    private long time=0;
    /* // millisegons
    public Date getTime() {
        return new Date(time);
    }*/
    private MutableLiveData<Date> timeDate = new MutableLiveData<>();

    public MainActivityViewModel(Application app){
        super(app);

        SharedPreferences sp = this.getApplication().getSharedPreferences("DADES",
                Context.MODE_PRIVATE );

        this.scoreLocal = sp.getInt(LOCAL,0 );
        this.scoreVisitant = sp.getInt(VISITANT, 0);
        this.time = sp.getLong(TIME, 0);



        timeDate.setValue(new Date(time));
    }

    public MutableLiveData<Date> getTime(){
        return timeDate;
    }

    public void incTime_1Second(){
        time+=1000;
    }
    public void resetTime(){
        time = 0;
    }


    private int scoreLocal=0;
    private int scoreVisitant=0;

    public int getScoreLocal() {
        return scoreLocal;
    }

    public void incScoreLocal(int inc){
        if(scoreLocal+inc>=0) {
            this.scoreLocal += inc;
        }
    }

    public void setScoreLocal(int scoreLocal) {
        this.scoreLocal = scoreLocal;
    }

    public void incScoreVisitant(int inc){
        if(scoreVisitant+inc>=0) {
            this.scoreVisitant += inc;
        }
    }

    public int getScoreVisitant() {
        return scoreVisitant;
    }

    public void setScoreVisitant(int scoreVisitant) {
        this.scoreVisitant = scoreVisitant;
    }

    public void resumeTimer() {
        if(t==null || timerFinalitzat){
            timerFinalitzat = false;
            t = new Thread(() -> {
                while(!timerFinalitzat){
                    try {
                        Thread.sleep(1000);
                    } catch (InterruptedException e) {
                        throw new RuntimeException(e);
                    }
                    incTime_1Second();
                    timeDate.postValue(new Date(time));
                }
            });
            t.start();
        }
    }

    @Override
    protected void onCleared() {
        super.onCleared();
        System.out.println("onCleared");
        Log.d("XXX", "onCleared");
        timerFinalitzat= true;
        t = null; // Ajudem al garbage collector.

        SharedPreferences sp = this.getApplication().getSharedPreferences("DADES",
                Context.MODE_PRIVATE );
        SharedPreferences.Editor ed = sp.edit();
        ed.putInt(LOCAL, this.scoreLocal);
        ed.putInt(VISITANT, this.scoreVisitant);
        ed.putLong(TIME, this.time);
        ed.commit();

        // this.scoreLocal = sp.getInt("LOCAL",0);

    }
}
