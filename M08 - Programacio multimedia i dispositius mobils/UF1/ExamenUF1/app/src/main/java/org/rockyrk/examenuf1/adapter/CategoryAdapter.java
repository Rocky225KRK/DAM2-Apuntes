package org.rockyrk.examenuf1.adapter;

import android.content.Context;
import android.content.res.ColorStateList;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;

import org.rockyrk.examenuf1.R;
import org.rockyrk.examenuf1.model.Categories;
import org.rockyrk.examenuf1.model.Category;

public class CategoryAdapter extends RecyclerView.Adapter<CategoryAdapter.ViewHolder> {

    private Categories categories;
    private CategoryAdapterListener listener;
    private Context context;

    public static final int NO_SELECCIONAT=-1;
    private int posSelect=NO_SELECCIONAT;

    public interface CategoryAdapterListener {
        void onCategorySelected(Category category);
    }

    public CategoryAdapter(Categories categories, CategoryAdapterListener listener, Context context) {
        this.categories = categories;
        this.listener = listener;
        this.context = context;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view= LayoutInflater.from(parent.getContext()).inflate(R.layout.category_card,parent,false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull CategoryAdapter.ViewHolder holder, int NOUSAR) {
        Category current= categories.getCategories().get(holder.getAdapterPosition());
        if (current.getImageURL() != null) {
            Glide.with(context).load(current.getImageURL()).into(holder.imgCat);
        }

        if(holder.getAdapterPosition()==posSelect){
            holder.llyCategoryCard.setBackgroundTintList(ColorStateList.valueOf(context.getColor(R.color.selected)));
        }else{
            holder.llyCategoryCard.setBackgroundTintList(null);
        }

        holder.llyCategoryCard.setOnClickListener(view -> {
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
                    listener.onCategorySelected(current);
                }
            }
        });
    }

    @Override
    public int getItemCount() {
        return categories.getCategories().size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        LinearLayout llyCategoryCard;
        ImageView imgCat;

        public ViewHolder(@NonNull View row) {
            super(row);
            llyCategoryCard=row.findViewById(R.id.llyCategoryCard);
            imgCat=row.findViewById(R.id.imgCat);
        }
    }
}
