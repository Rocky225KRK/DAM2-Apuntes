package org.rockyrk.paintonview;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Path;
import android.graphics.Rect;
import android.util.AttributeSet;
import android.view.MotionEvent;
import android.view.View;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

public class Pissarra extends View {
    private Bitmap ghost;
    private int frame=0;

    public Pissarra(Context context) {
        this(context,null);
    }

    public Pissarra(Context context, @Nullable AttributeSet attrs) {
        super(context, attrs);
        ghost =BitmapFactory.decodeResource(this.getResources(),R.drawable.red);
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

        Path p=new Path();
        paint.setStyle(Paint.Style.STROKE);
        paint.setStrokeWidth(5);

        float r=200;
        float xCentre=300,yCentre=300;
        float xA=-1,yA=-1;
        int lap=5;

        for(float angle=0;angle<=360*lap;angle+=10) {
            float x = (float) (r * Math.cos(Math.toRadians(angle))) + xCentre;
            float y = (float) (r * Math.sin(Math.toRadians(angle))) + yCentre;

            if (xA != -1) {
                //canvas.drawLine(xA,yA,x,y,paint);
                p.lineTo(x, y);
            } else {
                p.moveTo(x, y);
            }

            // Espiral
            //r-=1;

            // Golden ratio (espiral millorada)
            r -= 200.0f / ((360.0f * lap) / 10.0f);
            xA = x;
            yA = y;
        }
        p.quadTo(0,2200,800,2200);

        canvas.drawPath(p,paint);

        //canvas.drawBitmap(ghost,100,100,paint);
        int ghostX;
        ghostX=frame*ghost.getWidth()/2;
        canvas.drawBitmap(ghost,new Rect(ghostX,0, ghost.getWidth()/2, ghost.getHeight()),
                new Rect(0,0,ghost.getWidth()/2,ghost.getHeight()),
                paint);
        frame=(frame+1)%2;
    }

    @Override
    public boolean onTouchEvent(MotionEvent event) {
        invalidate();
        return true;
    }
}
