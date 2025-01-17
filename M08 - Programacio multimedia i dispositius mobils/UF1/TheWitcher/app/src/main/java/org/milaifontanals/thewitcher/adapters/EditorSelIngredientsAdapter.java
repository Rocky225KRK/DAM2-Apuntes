package org.milaifontanals.thewitcher.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import org.milaifontanals.thewitcher.R;
import org.milaifontanals.thewitcher.model.Ingredient;
import org.milaifontanals.thewitcher.model.Tuple;

import java.util.List;

public class EditorSelIngredientsAdapter extends RecyclerView.Adapter<EditorSelIngredientsAdapter.ViewHolder>{
    public interface SelIngredientAdapterListener {
        void onSelIngredientSelected(Ingredient ingredient);
    }

    private List<Tuple<Ingredient,Integer>> ingredients;
    private SelIngredientAdapterListener listener;
    private Context context;


    public static final int NO_SELECCIONAT=-1;
    private int posSelect=NO_SELECCIONAT;

    public EditorSelIngredientsAdapter(Context context, List<Tuple<Ingredient,Integer>> ingredients, SelIngredientAdapterListener listener) {
        this.context = context;
        this.ingredients = ingredients;
        this.listener=listener;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View row= LayoutInflater.from(parent.getContext()).inflate(R.layout.row_selected_ingredients,null);
        return new EditorSelIngredientsAdapter.ViewHolder(row);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int NOT_USE) {
        Tuple<Ingredient,Integer> tuple=ingredients.get(holder.getAdapterPosition());
        Ingredient current= tuple.getFirst();
        holder.txtName.setText(current.name);
        holder.txtQty.setText(tuple.getSecond());
        int drawableID=this.context.getResources().getIdentifier(current.image,"drawable",this.context.getPackageName());
        holder.imvPhoto.setImageResource(drawableID);
        holder.llySelIngredientsRow.setOnClickListener(view -> {
            int position=holder.getAdapterPosition();
            if (this.posSelect==position){
                this.posSelect=NO_SELECCIONAT;
                this.notifyItemChanged(position);
            }else {
                int posicioAnteriormentSeleccionada= this.posSelect;
                this.posSelect=position;
                this.notifyItemChanged(posSelect);
                this.notifyItemChanged(posicioAnteriormentSeleccionada);
                if(listener!=null){
                    listener.onSelIngredientSelected(current);
                }
            }
        });
    }

    @Override
    public int getItemCount() {
        return ingredients.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder{
        TextView txtName, txtQty;
        ImageView imvPhoto;
        LinearLayout llySelIngredientsRow;

        public ViewHolder(@NonNull View row) {
            super(row);
            txtName =row.findViewById(R.id.txtName);
            txtQty =row.findViewById(R.id.txtQty);
            imvPhoto =row.findViewById(R.id.imvPhoto);
            llySelIngredientsRow=row.findViewById(R.id.llySelIngredientsRow);
        }
    }
}
