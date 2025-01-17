package org.milaifontanals.recyclerview.adapters;

import android.content.Context;
import android.content.res.ColorStateList;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;

import org.milaifontanals.recyclerview.R;
import org.milaifontanals.recyclerview.model.Card;
import org.milaifontanals.recyclerview.model.Rarity;

import java.util.HashMap;
import java.util.List;

public class CardAdapter extends RecyclerView.Adapter<CardAdapter.ViewHolder> {
    public void deleteSelectedItem() {
        if(posSelect!=NO_SELECCIONAT){
            int pos=posSelect;
            cartes.remove(pos);
            posSelect=NO_SELECCIONAT;
            notifyItemRemoved(pos);
        }
    }

    public void moveSelectedItem(int i) {
        if(posSelect!=NO_SELECCIONAT){
            Card carta=cartes.get(posSelect);
            int fromPos=this.posSelect;
            int toPos=posSelect+i;
            if(toPos>=0&&toPos<cartes.size()){
                cartes.set(fromPos,cartes.get(toPos));
                cartes.set(toPos,carta);
                posSelect=toPos;
                notifyItemMoved(fromPos,toPos);
            }
        }
    }

    public interface CardAdapterListener{
        void onCardSelected(Card selected);
    }

    private CardAdapterListener listener;

    public List<Card> cartes;
    private Context context;
    private HashMap<Rarity,Integer> backgroundColor=new HashMap<>();

    public static final int NO_SELECCIONAT=-1;
    private int posSelect=NO_SELECCIONAT;

    /**
     * Posició del caracter seleccionat. Serà -1 si no n'hi ha cap
     */

    public CardAdapter(Context context,CardAdapterListener listener){
        cartes=Card.getCartes();
        this.context =context;
        backgroundColor.put(Rarity.COMMON,R.color.common);
        backgroundColor.put(Rarity.RARE,R.color.rare);
        backgroundColor.put(Rarity.EPIC,R.color.epic);
        this.listener=listener;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View fila;
        if(viewType==0)
            fila=LayoutInflater.from(parent.getContext()).inflate(R.layout.row,null);
        else
            fila=LayoutInflater.from(parent.getContext()).inflate(R.layout.row_epic,null);
        return new ViewHolder(fila);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int XXX_DO_NOT_USE_ME) {
        Card current=cartes.get(holder.getAdapterPosition());
        holder.txvName.setText(current.getName());
        holder.txvDesc.setText(current.getDesc());
        holder.txvCost.setText(current.getElixirCost()+"");
        holder.llyRow.setBackgroundColor(context.getColor(backgroundColor.get(current.getRarity())));
        //holder.imvPhoto.setImageResource(current.getDrawable());
        Glide.with(context).load(current.getImageURL()).into(holder.imvPhoto);

        Log.d("CLASH_ROYALE","Estic passant per onBind");

        if(holder.getAdapterPosition()==posSelect){
            holder.llyRow.setBackgroundTintList(ColorStateList.valueOf(context.getColor(R.color.selected)));
            holder.llyRowConstraint.setBackgroundTintList(ColorStateList.valueOf(context.getColor(R.color.selected)));
        }else{
            holder.llyRow.setBackgroundTintList(null);
            holder.llyRowConstraint.setBackgroundTintList(null);
        }

        holder.llyRow.setOnClickListener(view -> {
            int position=holder.getAdapterPosition();
            if (this.posSelect==position){
                this.posSelect=NO_SELECCIONAT;
                this.notifyItemChanged(position);
                if(listener!=null){
                    listener.onCardSelected(null);
                }
            }else {
                int posicioAnteriormentSeleccionada= this.posSelect;
                this.posSelect=position;
                this.notifyItemChanged(posSelect);
                this.notifyItemChanged(posicioAnteriormentSeleccionada);
                if(listener!=null){
                    listener.onCardSelected(current);
                }
            }
        });
    }

    @Override
    public int getItemCount() {
        return cartes.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        LinearLayout llyRow;
        ImageView imvPhoto;
        TextView txvCost;
        TextView txvName;
        TextView txvDesc;
        ConstraintLayout llyRowConstraint;

        public ViewHolder(@NonNull View fila) {
            super(fila);
            llyRow=fila.findViewById(R.id.llyRow);
            imvPhoto=fila.findViewById(R.id.imvPhoto);
            txvCost=fila.findViewById(R.id.txvCost);
            txvName=fila.findViewById(R.id.txvName);
            txvDesc=fila.findViewById(R.id.txvDesc);
            llyRowConstraint=fila.findViewById(R.id.llyRowConstraint);
        }
    }

    @Override
    public int getItemViewType(int position) { Rarity r=this.cartes.get(position).getRarity(); if(r==Rarity.EPIC) return 1; else return 0;}
}
