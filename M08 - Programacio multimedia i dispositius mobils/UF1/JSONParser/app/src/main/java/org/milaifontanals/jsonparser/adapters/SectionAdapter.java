package org.milaifontanals.jsonparser.adapters;

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

import org.milaifontanals.jsonparser.R;
import org.milaifontanals.jsonparser.model.BestiaryParser;
import org.milaifontanals.jsonparser.model.Section;

import java.util.List;

public class SectionAdapter extends RecyclerView.Adapter<SectionAdapter.ViewHolder> {
    public interface SectionAdapterListener {
        void onSectionSelected(Section section);
    }

    private SectionAdapterListener listener;
    public List<Section> sections;
    private Context context;

    public static final int NO_SELECCIONAT=-1;
    private int posSelect=NO_SELECCIONAT;

    public SectionAdapter(Context context, SectionAdapterListener listener) {
        sections =BestiaryParser.getBestiary(context);
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
        Section current= sections.get(holder.getAdapterPosition());
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
        return sections.size();
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
