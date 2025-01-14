package org.milaifontanals.thewitcher.adapters;

import android.content.Context;
import android.content.res.ColorStateList;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.RecyclerView;

import org.milaifontanals.thewitcher.R;
import org.milaifontanals.thewitcher.model.Section;
import org.milaifontanals.thewitcher.model.SectionsSet;

public class SectionAdapter extends RecyclerView.Adapter<SectionAdapter.ViewHolder> {
    public interface SectionAdapterListener {
        void onSectionSelected(Section sect);
    }

    private SectionsSet sectionsSet;
    private SectionAdapterListener listener;
    private Context context;

    public static final int NO_SELECCIONAT=-1;
    private int posSelect=NO_SELECCIONAT;

    public SectionAdapter(SectionsSet sectionsSet,Context context, SectionAdapterListener listener) {
        this.sectionsSet=sectionsSet;
        this.context = context;
        this.listener = listener;
    }

    @NonNull
    @Override
    public SectionAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View row= LayoutInflater.from(parent.getContext()).inflate(R.layout.row_section,null);
        return new ViewHolder(row);
    }

    @Override
    public void onBindViewHolder(@NonNull SectionAdapter.ViewHolder holder, int NO_UTILITZAR) {
        Section current= sectionsSet.getSections().get(holder.getAdapterPosition());
        holder.txtSection.setText(current.getTitle());
        int drawableID=this.context.getResources().getIdentifier(current.getImage(),"drawable",this.context.getPackageName());
        holder.txtSection.setBackgroundResource(drawableID);

        if(holder.getAdapterPosition()==posSelect){
            holder.llySectionRow.setBackgroundTintList(ColorStateList.valueOf(context.getColor(R.color.selected)));
        }else{
            holder.llySectionRow.setBackgroundTintList(null);
        }

        holder.llySectionRow.setOnClickListener(view -> {
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
                    listener.onSectionSelected(current);
                }
            }
        });
    }

    @Override
    public int getItemCount() {
        return sectionsSet.getSections().size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder{
        LinearLayout llySectionRow;
        ConstraintLayout llyRowConstraint;
        TextView txtSection;

        public ViewHolder(@NonNull View row) {
            super(row);
            llySectionRow=row.findViewById(R.id.llySectionRow);
            llyRowConstraint=row.findViewById(R.id.llyRowConstraint);
            txtSection=row.findViewById(R.id.txtSection);
        }
    }
}
