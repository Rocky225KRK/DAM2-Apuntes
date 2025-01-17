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
import org.milaifontanals.thewitcher.model.Artifact;

import java.util.List;

public class ArtifactAdapter extends RecyclerView.Adapter<ArtifactAdapter.ViewHolder>{
    public interface ArtifactAdapterListener{
        void onArtifactSelected(Artifact artifact);
    }

    private List<Artifact> artifacts;
    private ArtifactAdapterListener listener;
    private Context context;

    public static final int NO_SELECCIONAT=-1;
    private int posSelect=NO_SELECCIONAT;

    public ArtifactAdapter(Context context, List<Artifact> artifacts,ArtifactAdapterListener listener) {
        this.context = context;
        this.artifacts = artifacts;
        this.listener=listener;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View row= LayoutInflater.from(parent.getContext()).inflate(R.layout.row_alchemy,null);
        return new ArtifactAdapter.ViewHolder(row);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int NOT_USE) {
        Artifact current= artifacts.get(holder.getAdapterPosition());
        holder.txtName.setText(current.name);
        holder.txtDesc.setText(current.effect);
        int drawableID=this.context.getResources().getIdentifier(current.image,"drawable",this.context.getPackageName());
        holder.imvPhoto.setImageResource(drawableID);
        holder.llyArtifactRow.setOnClickListener(view -> {
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
                    listener.onArtifactSelected(current);
                }
            }
        });
    }

    @Override
    public int getItemCount() {
        return artifacts.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder{
        TextView txtName, txtDesc;
        ImageView imvPhoto;
        LinearLayout llyArtifactRow;

        public ViewHolder(@NonNull View row) {
            super(row);
            txtName =row.findViewById(R.id.txtName);
            txtDesc =row.findViewById(R.id.txtDesc);
            imvPhoto =row.findViewById(R.id.imvPhoto);
            llyArtifactRow=row.findViewById(R.id.llyAlchemyRow);
        }
    }
}
