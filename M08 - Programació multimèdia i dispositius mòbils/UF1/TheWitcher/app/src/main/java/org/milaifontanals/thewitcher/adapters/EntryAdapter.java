package org.milaifontanals.thewitcher.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.RecyclerView;

import org.milaifontanals.thewitcher.R;
import org.milaifontanals.thewitcher.model.Entry;

import java.util.List;

public class EntryAdapter extends RecyclerView.Adapter<EntryAdapter.ViewHolder> {
    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View row= LayoutInflater.from(parent.getContext()).inflate(R.layout.row_entry,null);
        return new ViewHolder(row);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        Entry current=entries.get(holder.getAdapterPosition());
        holder.txtEntry.setText(current.getTitle());
        int drawableID=this.context.getResources().getIdentifier(current.getImage(),"drawable",this.context.getPackageName());
        holder.imvPhotoEntry.setImageResource(drawableID);
    }

    @Override
    public int getItemCount() {
        return entries.size();
    }

    public List<Entry> entries;
    private Context context;

    public EntryAdapter(Context context, List<Entry> entries) {
        this.context = context;
        this.entries = entries;
    }

    public class ViewHolder extends RecyclerView.ViewHolder{
        LinearLayout llyEntryRow;
        ConstraintLayout llyRowConstraint;
        TextView txtEntry;
        ImageView imvPhotoEntry;

        public ViewHolder(@NonNull View row) {
            super(row);
            llyEntryRow=row.findViewById(R.id.llyEntryRow);
            llyRowConstraint=row.findViewById(R.id.llyRowConstraint);
            txtEntry=row.findViewById(R.id.txtEntry);
            imvPhotoEntry=row.findViewById(R.id.imvPhotoEntry);
        }
    }
}
