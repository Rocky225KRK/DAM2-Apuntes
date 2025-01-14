package org.rockyrk.paintonview;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.util.AttributeSet;
import android.view.View;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

public class Pissarra extends View {
    public Pissarra(Context context) {
        super(context);
    }

    public Pissarra(Context context, @Nullable AttributeSet attrs) {
        super(context, attrs);
    }

    @Override
    protected void onDraw(@NonNull Canvas canvas) {
        super.onDraw(canvas);
        Paint paint=new Paint();
        paint.setColor(Color.parseColor("#ff4000"));
        paint.setStyle(Paint.Style.FILL);
        canvas.drawCircle(100,100,50,paint);
        paint.setColor(Color.GREEN);
        canvas.drawRect(100,100,200,200,paint);
        paint.setColor(Color.parseColor("#663399"));
        paint.setStrokeWidth(6);

        float r=200;
        float xCentre=300,yCentre=300;
        float xA=-1,yA=-1;
        int lap=10;

        for(float angle=0;angle<=360*lap;angle+=10){
            float x=(float) (r*Math.cos(Math.toRadians(angle)))+xCentre;
            float y=(float) (r*Math.sin(Math.toRadians(angle)))+yCentre;

            if(xA!=-1){
                canvas.drawLine(xA,yA,x,y,paint);
            }

            // Espiral
            //r-=1;

            // Golden ratio (espiral millorada)
            r-= 200.0f /((360.0f*lap)/10.0f);
            xA=x;
            yA=y;
        }
    }
}
